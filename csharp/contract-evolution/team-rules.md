# Team Rules for Contract Evolution

These rules keep contract evolution from becoming a 20-team negotiation.

## Contract Rules

- Shared method signatures are stable by default.
- Additive contract changes are preferred.
- Removing, renaming, or adding required fields requires a new contract version.
- Versioned contracts need an owner and a deprecation timeline.
- Every breaking change must include a migration path.

## Adapter Rules

- An adapter has a named owner.
- An adapter exists at a boundary, not in the middle of business logic.
- An adapter should translate between contracts, not accumulate new policy rules.
- Temporary adapters should have retirement criteria.

## Facade Rules

- Callers use the facade instead of reaching into workflow internals.
- The facade owns orchestration, not every business rule.
- Internal workflow changes should not force caller changes.

## Strategy / Policy Rules

- Team-specific behavior belongs behind a strategy, policy, handler, or module.
- New team variation should not automatically become a new shared parameter.
- Strategies should be testable without running the whole transaction platform.
- Shared contracts define the entry point; teams own their implementation behind it.

## Review Checklist

Before approving a shared contract change, ask:

- Is this change specific to one team or truly shared?
- Can this be represented as a new strategy or policy instead of a new parameter?
- Is this additive, or does it break existing implementations?
- Does an older implementation need an adapter?
- Who owns the migration and retirement plan?
- Can the facade absorb this change without exposing more internals?
