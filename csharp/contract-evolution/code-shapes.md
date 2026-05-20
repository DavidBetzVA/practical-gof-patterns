# C# Code Shapes

These are intentionally incomplete sketches. They show the shape of the design,
not a framework to copy blindly.

## 1. Interfaces Define Behavior

Interfaces should name the behavior a caller needs, not the concrete class,
vendor, environment, or implementation detail behind it.

Worst: implementation-named interfaces.

```csharp
public sealed class LocalStackStorage
{
    public Task PutAsync(string key, Stream content, CancellationToken cancellationToken);
}

public interface ILocalStackStorage
{
    Task PutAsync(string key, Stream content, CancellationToken cancellationToken);
}

public sealed class S3Storage
{
    public Task PutAsync(string key, Stream content, CancellationToken cancellationToken);
}

public interface IS3Storage
{
    Task PutAsync(string key, Stream content, CancellationToken cancellationToken);
}
```

The interfaces above just copy implementation names. Callers now depend on the
storage product instead of the capability they need.

Better: a broader category interface.

```csharp
public interface ICloudStorage
{
    Task PutAsync(string key, Stream content, CancellationToken cancellationToken);
    Task<Stream> GetAsync(string key, CancellationToken cancellationToken);
}

public sealed class LocalStackStorage : ICloudStorage
{
    public Task PutAsync(string key, Stream content, CancellationToken cancellationToken)
    {
        // LocalStack-backed implementation.
        throw new NotImplementedException();
    }

    public Task<Stream> GetAsync(string key, CancellationToken cancellationToken)
    {
        // LocalStack-backed implementation.
        throw new NotImplementedException();
    }
}

public sealed class S3Storage : ICloudStorage
{
    public Task PutAsync(string key, Stream content, CancellationToken cancellationToken)
    {
        // AWS S3-backed implementation.
        throw new NotImplementedException();
    }

    public Task<Stream> GetAsync(string key, CancellationToken cancellationToken)
    {
        // AWS S3-backed implementation.
        throw new NotImplementedException();
    }
}
```

`ICloudStorage` is better than `IS3Storage` because it does not name the vendor
or emulator. The implementation can be LocalStack in development and S3 in
production without changing the caller.

But `ICloudStorage` is still a category, not a precise behavior. It can become
too broad if some callers only read, some only write, and some need delete,
listing, retention, replication, or lifecycle behavior.

Best when possible: capability interfaces.

```csharp
public interface IReadableStorage
{
    Task<Stream> GetAsync(string key, CancellationToken cancellationToken);
}

public interface IWritableStorage
{
    Task PutAsync(string key, Stream content, CancellationToken cancellationToken);
}
```

These interfaces say exactly what the caller can do. A class can implement both
when it supports both capabilities:

```csharp
public sealed class S3Storage : IReadableStorage, IWritableStorage
{
    public Task<Stream> GetAsync(string key, CancellationToken cancellationToken)
    {
        // AWS S3-backed read implementation.
        throw new NotImplementedException();
    }

    public Task PutAsync(string key, Stream content, CancellationToken cancellationToken)
    {
        // AWS S3-backed write implementation.
        throw new NotImplementedException();
    }
}
```

Use a broader category interface only when callers genuinely need the whole
category contract.

## 2. Stable Handler Contract

```csharp
public interface ITransactionHandler<TRequest, TResponse>
{
    Task<TResponse> HandleAsync(
        TRequest request,
        ProcessingContext context,
        CancellationToken cancellationToken);
}
```

Use this when teams need a stable entry point for transaction handling.

## 3. Versioned Request and Response

```csharp
public sealed record ClaimRequestV1(
    string MemberId,
    string PayerId,
    string RawX12);

public sealed record ClaimRequestV2(
    string MemberId,
    string PayerId,
    string PopulationCode,
    string RawX12);

public sealed record ClaimResultV2(
    string Status,
    IReadOnlyList<string> Messages);
```

Adding a required field to a shared request is a breaking change. Versioned
contracts make that break explicit.

## 4. Adapter for an Older Team Implementation

```csharp
public sealed class LegacyTeamBHandlerAdapter
    : ITransactionHandler<ClaimRequestV2, ClaimResultV2>
{
    private readonly TeamBLegacyProcessor _legacy;

    public LegacyTeamBHandlerAdapter(TeamBLegacyProcessor legacy)
    {
        _legacy = legacy;
    }

    public async Task<ClaimResultV2> HandleAsync(
        ClaimRequestV2 request,
        ProcessingContext context,
        CancellationToken cancellationToken)
    {
        var oldRequest = TeamBMapper.ToV1(request);
        var oldResult = await _legacy.ProcessAsync(oldRequest, cancellationToken);
        return TeamBMapper.ToV2(oldResult);
    }
}
```

Use adapters to bridge old and new contracts. Do not let adapters become
permanent dumping grounds.

## 5. Facade for the Shared Workflow

```csharp
public interface ITransactionProcessingFacade
{
    Task<ProcessingResult> ProcessAsync(
        TransactionEnvelope envelope,
        CancellationToken cancellationToken);
}
```

The facade keeps callers away from the internal sequence of parsing,
normalization, validation, routing, policy execution, response generation, and
auditing.

## 6. Strategy for Business Variation

```csharp
public interface IEligibilityPolicy
{
    EligibilityDecision Evaluate(
        MemberContext member,
        TransactionEnvelope transaction);
}

public sealed class TeamAEligibilityPolicy : IEligibilityPolicy
{
    public EligibilityDecision Evaluate(
        MemberContext member,
        TransactionEnvelope transaction)
    {
        // Team A rules live here.
        return EligibilityDecision.Approved();
    }
}
```

Use a strategy or policy when behavior varies by team, payer, group, population,
or program.

## 7. Transaction Envelope

```csharp
public sealed record TransactionEnvelope(
    string TransactionType,
    string ContractVersion,
    string OwningTeam,
    IReadOnlyDictionary<string, string> Metadata,
    BinaryData Payload);
```

An envelope gives the platform stable routing and audit data while allowing the
payload contract to evolve deliberately.
