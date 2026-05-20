# C# Code Shapes

These are intentionally incomplete sketches. They show the shape of the design,
not a framework to copy blindly.

## 1. Stable Handler Contract

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

## 2. Versioned Request and Response

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

## 3. Adapter for an Older Team Implementation

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

## 4. Facade for the Shared Workflow

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

## 5. Strategy for Business Variation

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

## 6. Transaction Envelope

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
