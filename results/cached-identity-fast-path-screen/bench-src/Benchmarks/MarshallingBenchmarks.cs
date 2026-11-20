using System.Net;
using System.Text;
using Amazon.Runtime;
using Amazon.Runtime.EventStreams;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using BenchmarkDotNet.Attributes;

namespace CoreBenchmarks.Benchmarks;

// Marshalling and unmarshalling hot paths in AWSSDK.Core (Amazon.Runtime.Internal.Transform,
// Amazon.Runtime.Internal.Util). Every benchmark drives the public unmarshaller/marshaller
// entry points the generated service code calls, over in-memory documents shaped like real
// responses, so they compile against any Core commit.
[MemoryDiagnoser]
public class MarshallingBenchmarks
{
    private const int Items = 50;

    private byte[] _xmlListObjects;
    private byte[] _xmlDates;
    private byte[] _jsonDateStrings;
    private byte[] _jsonEpochDates;
    private byte[] _jsonBools;
    private byte[] _jsonStrings;
    private DateTime _date;
    private byte[] _jsonError;
    private byte[] _jsonErrorNoMessage;
    private byte[] _cachedBody;
    private byte[] _readBuffer;
    private ErrorResponseData _errorResponseData;
    private ErrorResponseData _errorNoMessageResponseData;

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        var baseDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // S3 ListObjectsV2-shaped XML response body.
        var sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<ListBucketResult xmlns=\"http://s3.amazonaws.com/doc/2006-03-01/\">");
        var dates = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<R>");
        var jsonDates = new StringBuilder("[");
        var jsonEpoch = new StringBuilder("[");
        var jsonBools = new StringBuilder("[");
        var jsonStrings = new StringBuilder("[");
        for (int i = 0; i < Items; i++)
        {
            var d = baseDate.AddSeconds(rnd.Next(0, 300_000_000)).AddMilliseconds(rnd.Next(0, 1000));
            var iso = d.ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", System.Globalization.CultureInfo.InvariantCulture);
            sb.Append("<Contents><Key>photos/2024/album-").Append(i).Append("/IMG_").Append(rnd.Next(1000, 9999)).Append(".jpg</Key>")
              .Append("<LastModified>").Append(iso).Append("</LastModified>")
              .Append("<ETag>&quot;").Append(rnd.Next().ToString("x8")).Append(rnd.Next().ToString("x8")).Append("&quot;</ETag>")
              .Append("<Size>").Append(rnd.Next(1, int.MaxValue)).Append("</Size>")
              .Append("<StorageClass>STANDARD</StorageClass></Contents>");
            dates.Append("<LastModified>").Append(iso).Append("</LastModified>");
            if (i > 0) { jsonDates.Append(','); jsonEpoch.Append(','); jsonBools.Append(','); jsonStrings.Append(','); }
            jsonDates.Append('"').Append(iso).Append('"');
            jsonEpoch.Append((d - DateTime.UnixEpoch).TotalSeconds.ToString("F3", System.Globalization.CultureInfo.InvariantCulture));
            jsonBools.Append(i % 3 == 0 ? "true" : "false");
            jsonStrings.Append("\"arn:aws:iam::123456789012:role/service-role/name-").Append(i).Append('"');
        }
        sb.Append("</ListBucketResult>");
        dates.Append("</R>");
        _xmlListObjects = Encoding.UTF8.GetBytes(sb.ToString());
        _xmlDates = Encoding.UTF8.GetBytes(dates.ToString());
        _jsonDateStrings = Encoding.UTF8.GetBytes(jsonDates.Append(']').ToString());
        _jsonEpochDates = Encoding.UTF8.GetBytes(jsonEpoch.Append(']').ToString());
        _jsonBools = Encoding.UTF8.GetBytes(jsonBools.Append(']').ToString());
        _jsonStrings = Encoding.UTF8.GetBytes(jsonStrings.Append(']').ToString());
        _date = new DateTime(2024, 5, 17, 13, 45, 12, 345, DateTimeKind.Utc);

        _jsonError = Encoding.UTF8.GetBytes("{\"__type\":\"com.amazonaws.dynamodb.v20120810#ConditionalCheckFailedException\",\"message\":\"The conditional request failed\"}");
        _jsonErrorNoMessage = Encoding.UTF8.GetBytes("{\"__type\":\"com.amazonaws.dynamodb.v20120810#ThrottlingException\"}");
        _errorResponseData = new ErrorResponseData(_jsonError.Length);
        _errorNoMessageResponseData = new ErrorResponseData(_jsonErrorNoMessage.Length);

        _cachedBody = new byte[16 * 1024];
        rnd.NextBytes(_cachedBody);
        _readBuffer = new byte[4096];
    }

    // End-to-end: an S3 ListObjectsV2-like body unmarshalled the way generated code does it.
    [Benchmark]
    public long Xml_ListObjectsLike()
    {
        long total = 0;
        using var ctx = new XmlUnmarshallerContext(new MemoryStream(_xmlListObjects, false), false, null);
        while (ctx.Read())
        {
            if (!ctx.IsStartElement) continue;
            if (ctx.TestExpression("Key", 3)) total += StringUnmarshaller.Instance.Unmarshall(ctx).Length;
            else if (ctx.TestExpression("LastModified", 3)) total += NullableDateTimeUnmarshaller.Instance.Unmarshall(ctx).Value.Ticks;
            else if (ctx.TestExpression("ETag", 3)) total += StringUnmarshaller.Instance.Unmarshall(ctx).Length;
            else if (ctx.TestExpression("Size", 3)) total += LongUnmarshaller.Instance.Unmarshall(ctx);
            else if (ctx.TestExpression("StorageClass", 3)) total += StringUnmarshaller.Instance.Unmarshall(ctx).Length;
        }
        return total;
    }

    // ISO 8601 timestamps in an XML body (S3, EC2, IAM, CloudFormation, ... query/XML protocols).
    [Benchmark]
    public long Xml_DateTimes()
    {
        long total = 0;
        using var ctx = new XmlUnmarshallerContext(new MemoryStream(_xmlDates, false), false, null);
        while (ctx.Read())
        {
            if (ctx.IsStartElement && ctx.TestExpression("LastModified", 2))
                total += DateTimeUnmarshaller.Instance.Unmarshall(ctx).Ticks;
        }
        return total;
    }

    // ISO 8601 timestamps as JSON strings.
    [Benchmark]
    public int Json_DateTimeStrings() => UnmarshallJsonList(_jsonDateStrings, new JsonListUnmarshaller<DateTime?, NullableDateTimeUnmarshaller>(NullableDateTimeUnmarshaller.Instance));

    // Epoch-seconds timestamps as JSON numbers (the default for JSON protocols).
    [Benchmark]
    public int Json_DateTimeEpoch() => UnmarshallJsonList(_jsonEpochDates, new JsonListUnmarshaller<DateTime, DateTimeUnmarshaller>(DateTimeUnmarshaller.Instance));

    [Benchmark]
    public int Json_Bools() => UnmarshallJsonList(_jsonBools, new JsonListUnmarshaller<bool, BoolUnmarshaller>(BoolUnmarshaller.Instance));

    [Benchmark]
    public int Json_Strings() => UnmarshallJsonList(_jsonStrings, new JsonListUnmarshaller<string, StringUnmarshaller>(StringUnmarshaller.Instance));

    // Request side: timestamp members formatted for query/XML/REST protocols.
    [Benchmark]
    public string Format_ISO8601() => StringUtils.FromDateTimeToISO8601(_date);

    [Benchmark]
    public string Format_ISO8601NoMs() => StringUtils.FromDateTimeToISO8601NoMs(_date);

    [Benchmark]
    public string Format_RFC822() => StringUtils.FromDateTimeToRFC822(_date);

    // First-pass JSON error unmarshalling, as on every failed attempt (throttling, conditional checks, 4xx).
    [Benchmark]
    public string Error_Json() => UnmarshallJsonError(_jsonError, _errorResponseData);

    [Benchmark]
    public string Error_JsonNoMessage() => UnmarshallJsonError(_jsonErrorNoMessage, _errorNoMessageResponseData);

    // Reading a body through CachingWrapperStream, which the unmarshaller contexts use for error
    // responses and when response logging is on.
    [Benchmark]
    public int CachingStream_Read16K()
    {
        using var stream = new CachingWrapperStream(new MemoryStream(_cachedBody, false));
        int total = 0, n;
        while ((n = stream.Read(_readBuffer, 0, _readBuffer.Length)) > 0) total += n;
        return total + stream.AllReadBytes.Count;
    }

    private static string UnmarshallJsonError(byte[] body, IWebResponseData responseData)
    {
        using var ctx = new JsonUnmarshallerContext(new MemoryStream(body, false), false, responseData, isException: true);
        var reader = new StreamingUtf8JsonReader(ctx.Stream);
        return JsonErrorResponseUnmarshaller.GetInstance().Unmarshall(ctx, ref reader).Message;
    }

    private sealed class ErrorResponseData : IWebResponseData
    {
        private readonly Dictionary<string, string> _headers;

        public ErrorResponseData(long contentLength)
        {
            ContentLength = contentLength;
            _headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["Content-Length"] = contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture),
                ["Content-Type"] = "application/x-amz-json-1.0",
                ["x-amzn-RequestId"] = "6PFOQQ7JQ0JQ4R8KG6S1QJ8V0BVV4KQNSO5AEMVJF66Q9ASUAAJG",
            };
        }

        public long ContentLength { get; }
        public string ContentType => "application/x-amz-json-1.0";
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public bool IsSuccessStatusCode => false;
        public string[] GetHeaderNames() => _headers.Keys.ToArray();
        public bool IsHeaderPresent(string headerName) => _headers.ContainsKey(headerName);
        public string GetHeaderValue(string headerName) => _headers.TryGetValue(headerName, out var v) ? v : null;
        public IHttpResponseBody ResponseBody => null;
        public IEventStreamHeader GetEventStreamHeader(string headerName) => null;
        public bool IsEventHeaderPresent(string headerName) => false;
    }

    private static int UnmarshallJsonList<T, TU>(byte[] body, JsonListUnmarshaller<T, TU> unmarshaller)
        where TU : IJsonUnmarshaller<T, JsonUnmarshallerContext>
    {
        using var ctx = new JsonUnmarshallerContext(new MemoryStream(body, false), false, null);
        var reader = new StreamingUtf8JsonReader(ctx.Stream);
        return unmarshaller.Unmarshall(ctx, ref reader).Count;
    }
}
