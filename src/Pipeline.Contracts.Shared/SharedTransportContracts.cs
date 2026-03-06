namespace Pipeline.Contracts.Shared;
public sealed record PipelineMessageEndpointV1(
    string ClientId,
    string AdapterId,
    string Channel,
    string Topic = "");
public sealed record PipelineRetryPolicyV1(
    int MaxAttempts,
    int InitialBackoffMs,
    int MaxBackoffMs);
public sealed record PipelineEnvelopeCoreV1(
    string SchemaVersion,
    string MessageId,
    string CorrelationId,
    DateTimeOffset TimestampUtc,
    PipelineMessageEndpointV1 Source,
    PipelineMessageEndpointV1 Target,
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
