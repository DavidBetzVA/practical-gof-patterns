# GoF Patterns in Modern C#

This project keeps tiny examples of the Gang of Four design patterns, but it
does not treat the classic class-heavy form as the default recommendation.

Modern C# has delegates, lambdas, records, pattern matching, LINQ,
`IEnumerable<T>`, events, `Lazy<T>`, dependency injection, and async primitives.
Those features often express the original pattern intent with less ceremony.

Use these samples to learn the pressure each pattern responds to, then choose
the smallest C# shape that solves the problem.

## Run

```bash
dotnet run --project csharp
```

## Applied Guides

| Guide | Purpose |
| --- | --- |
| [Contract Evolution](contract-evolution/README.md) | Interfaces, adapters, facades, and strategies for multi-team shared C# systems. |

## Problem-First Index

Use this table when you know the design pressure but not the pattern name. The
last column is deliberately skeptical; it points to modern C# features before
adding old GoF ceremony.

| If you need to... | Consider | C#-first check |
| --- | --- | --- |
| Adapt a third-party, legacy, or external API to your application's shape | Adapter | Normalize package, HTTP, SDK, or legacy boundaries once. |
| Add behavior around an object without changing its interface | Decorator | Service decorators, middleware, and streams fit; avoid unreadable wrapper stacks. |
| Add operations across a stable object hierarchy | Visitor | Try pattern matching, polymorphic methods, or discriminated-union-style records first. |
| Build a complex object step by step | Builder | Prefer object initializers, records, optional parameters, or options binding unless construction has ordered validation. |
| Capture undo or restore points | Memento | Consider records, snapshots, persistence, or event sourcing. |
| Choose between interchangeable algorithms | Strategy | Use delegates, lambdas, or `Func<T>` unless the strategy carries state or dependencies. |
| Control access, lifecycle, latency, caching, or remoting for an object | Proxy | Make hidden I/O, caching, lazy loading, and authorization behavior visible to callers. |
| Coordinate peers without direct references between all of them | Mediator | Message buses, controllers, queues, and application services may play this role; avoid a god object. |
| Create related families of objects consistently | Abstract Factory | A DI-registered factory service may be enough. |
| Defer object creation inside a reusable workflow | Factory Method | Passing `Func<T>`, a constructor delegate, or a DI dependency is often simpler. |
| Define an algorithm outline with replaceable steps | Template Method | Prefer composition with injected collaborators when inheritance hooks get fragile. |
| Ensure one shared instance | Singleton | Prefer DI singleton lifetime over static global access. |
| Hide a messy subsystem behind a simpler API | Facade | A clean service, client, or application-layer API is often the C# form. |
| Interpret a small language or grammar | Interpreter | Parser libraries, expression trees, pattern matching, or functions may be better. |
| Model behavior that changes with state | State | Start with conditionals, switch expressions, or a transition table. |
| Notify dependents when something changes | Observer | Use events, `IObservable<T>`, channels, or a message bus with clear unsubscription. |
| Represent whole/part tree structures | Composite | Use it when leaves and groups genuinely share operations. |
| Reuse a configured object as a template | Prototype | Records with `with` expressions usually cover this. |
| Route a request through ordered handlers | Chain of Responsibility | ASP.NET Core middleware, filters, validators, and pipelines fit; keep order explicit. |
| Share many repeated small objects | Flyweight | Use only after profiling shows real memory pressure. |
| Traverse a collection uniformly | Iterator | Prefer `IEnumerable<T>`, `yield return`, LINQ, and `foreach`. |
| Vary an abstraction and its implementation independently | Bridge | Collaborator injection is common; a named Bridge hierarchy is rare. |

## Category Map

| Category | High-Level Focus | Core Question It Solves |
| --- | --- | --- |
| Creational | How objects are created | How should this object or family of objects be instantiated? |
| Structural | How objects and classes are composed | How should these pieces be organized and connected? |
| Behavioral | How objects communicate and coordinate | How should responsibilities and interactions be distributed? |

## Filename Signals

| Prefix | Meaning |
| --- | --- |
| No prefix | Still common enough as a direct design idea in C#. |
| `classic_` | The sample shows the GoF shape, but modern C# often has a lighter native form. |
| `rare_` | Direct use is uncommon in everyday C#; reach for it only when the pressure is real. |

These prefixes are warnings against over-engineering, not claims that the
patterns are obsolete.

## Samples

| Category | Pattern | File | Modern C# Note |
| --- | --- | --- | --- |
| Creational | Abstract Factory | `creational/abstract_factory.cs` | Often a factory service registered in DI. |
| Creational | Builder | `creational/builder.cs` | Prefer object initializers, records, and optional parameters unless construction needs ordered validation. |
| Creational | Factory Method | `creational/factory_method.cs` | Passing `Func<T>` or using DI is often simpler than subclassing. |
| Creational | Prototype | `creational/rare_prototype.cs` | Records with `with` expressions usually cover this need. |
| Creational | Singleton | `creational/rare_singleton.cs` | Prefer DI singleton lifetime over static global access. |
| Structural | Adapter | `structural/adapter.cs` | Still useful at package, HTTP, cloud SDK, and legacy boundaries. |
| Structural | Bridge | `structural/rare_bridge.cs` | Collaborator injection is common; a named Bridge hierarchy is rare. |
| Structural | Composite | `structural/composite.cs` | Useful for trees where leaves and groups share operations. |
| Structural | Decorator | `structural/decorator.cs` | Common in streams, middleware, pipelines, and DI service wrappers. |
| Structural | Facade | `structural/facade.cs` | Often a clean service, client, or application-layer API. |
| Structural | Flyweight | `structural/rare_flyweight.cs` | Use only when profiling shows duplicate object memory pressure. |
| Structural | Proxy | `structural/proxy.cs` | Useful for lazy loading, access checks, caching, remoting, and instrumentation. |
| Behavioral | Chain of Responsibility | `behavioral/chain_of_responsibility.cs` | Common as ASP.NET Core middleware, validators, filters, and pipelines. |
| Behavioral | Command | `behavioral/classic_command.cs` | `Action`, `Func<T>`, and lambdas are often enough; classes help with undo, queues, and metadata. |
| Behavioral | Interpreter | `behavioral/rare_interpreter.cs` | Parser libraries, expression trees, pattern matching, or functions are often better unless building a DSL. |
| Behavioral | Iterator | `behavioral/classic_iterator.cs` | Iteration is language-native through `IEnumerable<T>`, `yield return`, LINQ, and `foreach`. |
| Behavioral | Mediator | `behavioral/mediator.cs` | Often appears as a message bus, controller, queue, or application service. |
| Behavioral | Memento | `behavioral/rare_memento.cs` | Records, snapshots, persistence, or event sourcing may be clearer. |
| Behavioral | Observer | `behavioral/observer.cs` | Usually events, `IObservable<T>`, channels, or message buses. |
| Behavioral | State | `behavioral/state.cs` | Start with simple conditionals or switch expressions; split when transitions grow. |
| Behavioral | Strategy | `behavioral/strategy.cs` | Delegates, lambdas, and `Func<T>` are usually the simplest Strategy. |
| Behavioral | Template Method | `behavioral/classic_template_method.cs` | Composition is often easier to test than inheritance hooks. |
| Behavioral | Visitor | `behavioral/rare_visitor.cs` | Consider pattern matching or polymorphic methods first. |
