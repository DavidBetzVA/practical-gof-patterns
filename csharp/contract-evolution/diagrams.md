# Contract Evolution Diagrams

These diagrams are intentionally small. They are meant for whiteboards, PR
discussions, and team onboarding.

## 1. Stable Boundary

The shared system should expose stable contracts. Team-specific behavior sits
behind those contracts.

```mermaid
flowchart LR
    Caller[Caller / Integration] --> Facade[Transaction Processing Facade]
    Facade --> Contract[Stable Handler Contract]
    Contract --> TeamA[Team A Handler]
    Contract --> TeamB[Team B Handler]
    Contract --> TeamC[Team C Handler]

    TeamA --> PolicyA[Team A Policy]
    TeamB --> PolicyB[Team B Policy]
    TeamC --> PolicyC[Team C Policy]
```

Key point: callers depend on the facade and stable contract, not on each team's
internal implementation details.

## 2. Adapter During Contract Change

Adapters let a team keep an old implementation while the shared contract moves
forward.

```mermaid
flowchart LR
    Platform[Shared Platform] --> V2[ClaimRequestV2 Contract]
    V2 --> Adapter[Team B Adapter]
    Adapter --> Mapper1[Map V2 to V1]
    Mapper1 --> Legacy[Team B Legacy Processor]
    Legacy --> Mapper2[Map V1 Result to V2]
    Mapper2 --> Result[ClaimResultV2]
```

Key point: an adapter is a boundary tool. It should have an owner and a removal
plan.

## 3. Facade plus Strategy

The facade owns the workflow. Strategies own the business variation.

```mermaid
flowchart TD
    Envelope[Transaction Envelope] --> Facade[Processing Facade]
    Facade --> Normalize[Normalize X12]
    Normalize --> Validate[Validate]
    Validate --> Route[Route]
    Route --> Policy{Select Policy}
    Policy --> PayerPolicy[Payer Policy]
    Policy --> GroupPolicy[Group Policy]
    Policy --> ProgramPolicy[Program Policy]
    PayerPolicy --> Result[Processing Result]
    GroupPolicy --> Result
    ProgramPolicy --> Result
```

Key point: new business variation should usually add or replace a policy, not
change every shared method signature.

## 4. Bad Shape: Signature Churn

This is the failure mode to avoid.

```mermaid
flowchart TD
    SharedMethod[Shared Method Signature] --> TeamA[Team A]
    SharedMethod --> TeamB[Team B]
    SharedMethod --> TeamC[Team C]
    SharedMethod --> TeamD[Team D]

    TeamA -- needs new field --> SharedMethod
    SharedMethod -- breaking change --> TeamB
    SharedMethod -- breaking change --> TeamC
    SharedMethod -- breaking change --> TeamD
```

Key point: if every team must react to every team-specific change, the contract
is too volatile or too low-level.
