namespace Pipeline.Contracts.Shared;

public record PipelineMessageSourceV1(
    string ClientId,
    string AdapterId,
    string Channel);

public record PipelineMessageTargetV1(
    string? AdapterId,
    string? ClientId,
    string? Topic);

public class PipelineMessageEndpointV1
{
    public PipelineMessageEndpointV1()
    {
    }

    public PipelineMessageEndpointV1(string clientId, string adapterId, string channel, string topic = "")
    {
        ClientId = clientId;
        AdapterId = adapterId;
        Channel = channel;
        Topic = topic;
    }

    public string ClientId { get; set; } = "";
    public string AdapterId { get; set; } = "";
    public string Channel { get; set; } = "";
    public string Topic { get; set; } = "";
}

public record PipelineRetryPolicyV1(
    int MaxAttempts,
    int BackoffMs);

public class PipelineRetryPolicyRangeV1
{
    public PipelineRetryPolicyRangeV1()
    {
    }

    public PipelineRetryPolicyRangeV1(int maxAttempts, int initialBackoffMs, int maxBackoffMs)
    {
        MaxAttempts = maxAttempts;
        InitialBackoffMs = initialBackoffMs;
        MaxBackoffMs = maxBackoffMs;
    }

    public int MaxAttempts { get; set; }
    public int InitialBackoffMs { get; set; }
    public int MaxBackoffMs { get; set; }
}

public sealed record PipelineEnvelopeCoreV1(
    string SchemaVersion,
    string MessageId,
    string CorrelationId,
    DateTimeOffset TimestampUtc,
    PipelineMessageSourceV1 Source,
    PipelineMessageTargetV1 Target,
    string Kind,
    int TtlMs,
    int Priority,
    PipelineRetryPolicyV1 RetryPolicy,
    int HopCount = 0);

public sealed record PipelineResultCoreV1(
    bool Ok,
    string Code,
    string Message,
    bool Retryable,
    long LatencyMs);

public sealed record AdapterAuthorityEntryV1(
    string AdapterId,
    string AuthorityOwner,
    string ConsumerOwner,
    bool Enabled = true,
    string Notes = "");

public sealed record AdapterAuthorityMapV1(
    string SchemaVersion,
    IReadOnlyList<AdapterAuthorityEntryV1> Entries);
