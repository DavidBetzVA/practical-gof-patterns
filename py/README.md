# GoF Patterns in Modern Python

This project keeps tiny examples of the Gang of Four design patterns, but it
does not treat the classic class-heavy form as the default recommendation.

Many GoF patterns came from a C++/Java era. In Python, the same design intent is
often better expressed with modules, functions, closures, protocols, generators,
decorators, dataclasses, context managers, dependency injection, or small service
objects.

Use these samples to learn the pressure each pattern responds to, then choose
the smallest Python shape that solves the problem.

## Problem-First Index

Use this table when you know the design pressure but not the pattern name. The
last column is deliberately skeptical; it helps avoid translating old GoF
ceremony directly into Python.

| If you need to... | Consider | Python-first check |
| --- | --- | --- |
| Adapt a third-party, legacy, or external API to your application's shape | Adapter | Normalize the boundary once; duck typing may remove the need for a formal interface. |
| Add behavior around an object without changing its interface | Decorator | Use a function decorator for callables; keep object wrapper chains shallow. |
| Add operations across a stable object hierarchy | Visitor | Try `match`, `functools.singledispatch`, or polymorphic methods first. |
| Build a complex object step by step | Builder | Prefer dataclasses, keyword arguments, or helper functions unless construction has ordered validation. |
| Capture undo or restore points | Memento | Consider immutable values, `copy`, persistence, or event logs. |
| Choose between interchangeable algorithms | Strategy | Pass a function or closure unless the strategy carries state or dependencies. |
| Control access, lifecycle, latency, caching, or remoting for an object | Proxy | Make hidden I/O, caching, and authorization behavior visible to callers. |
| Coordinate peers without direct references between all of them | Mediator | Event buses, queues, controllers, or service layers may play this role; avoid a god object. |
| Create related families of objects consistently | Abstract Factory | A factory function, config map, or dependency container may be enough. |
| Defer object creation inside a reusable workflow | Factory Method | Passing a constructor or callable is often simpler than subclassing. |
| Define an algorithm outline with replaceable steps | Template Method | Prefer composition with injected functions or collaborators when possible. |
| Ensure one shared instance | Singleton | Prefer module-level ownership or explicit dependency injection. |
| Hide a messy subsystem behind a simpler API | Facade | A clean module, package, or service API is often the Pythonic form. |
| Interpret a small language or grammar | Interpreter | Parser libraries, `ast`, pattern matching, or plain functions may be clearer. |
| Model behavior that changes with state | State | Start with simple conditionals or a table; split states when behavior grows. |
| Notify dependents when something changes | Observer | Use callbacks, signals, async queues, or pub/sub with clear unsubscribe ownership. |
| Represent whole/part tree structures | Composite | Use it when leaves and groups genuinely share operations. |
| Reuse a configured object as a template | Prototype | `copy`, `deepcopy`, or dataclass replacement is usually enough. |
| Route a request through ordered handlers | Chain of Responsibility | Middleware, hooks, and validators fit; keep order explicit and tested. |
| Share many repeated small objects | Flyweight | Use only after profiling shows real memory pressure. |
| Traverse a collection uniformly | Iterator | Prefer native iteration, generators, and `__iter__`. |
| Vary an abstraction and its implementation independently | Bridge | Passing a collaborator is common; a named Bridge hierarchy is rare. |

## Category Map

| Category | High-Level Focus | Core Question It Solves |
| --- | --- | --- |
| Creational | How objects are created | How should this object or family of objects be instantiated? |
| Structural | How objects and classes are composed | How should these pieces be organized and connected? |
| Behavioral | How objects communicate and coordinate | How should responsibilities and interactions be distributed? |

## Filename Signals

| Prefix | Meaning |
| --- | --- |
| No prefix | Still common enough as a direct design idea in Python. |
| `classic_` | The sample shows the GoF shape, but Python often has a lighter native form. |
| `rare_` | Direct use is uncommon in everyday Python; reach for it only when the pressure is real. |

These prefixes are warnings against over-engineering, not claims that the
patterns are obsolete.

## Samples

| Category | Pattern | File | Modern Python Note |
| --- | --- | --- | --- |
| Creational | Abstract Factory | `creational/abstract_factory.py` | Often a factory function, config map, or dependency container is enough. |
| Creational | Builder | `creational/builder.py` | Prefer dataclasses, keyword arguments, or helpers unless construction needs ordered validation. |
| Creational | Factory Method | `creational/factory_method.py` | Passing a constructor or callable is often simpler than subclassing. |
| Creational | Prototype | `creational/rare_prototype.py` | `copy`, `deepcopy`, or dataclass replacement usually cover this need. |
| Creational | Singleton | `creational/rare_singleton.py` | Prefer module-level objects or explicit dependency injection. |
| Structural | Adapter | `structural/adapter.py` | Still useful at API, library, network, and legacy boundaries. |
| Structural | Bridge | `structural/rare_bridge.py` | Passing collaborators is common; naming a full Bridge hierarchy is rare. |
| Structural | Composite | `structural/composite.py` | Useful for trees where leaves and groups share operations. |
| Structural | Decorator | `structural/decorator.py` | Python function decorators cover many cases; object decorators still help runtime composition. |
| Structural | Facade | `structural/facade.py` | Often just a clean module, service, or client API. |
| Structural | Flyweight | `structural/rare_flyweight.py` | Use when profiling shows duplicate object memory pressure. |
| Structural | Proxy | `structural/proxy.py` | Useful for lazy loading, access checks, caching, remoting, and instrumentation. |
| Behavioral | Chain of Responsibility | `behavioral/chain_of_responsibility.py` | Common as middleware, hooks, pipelines, and validators. |
| Behavioral | Command | `behavioral/classic_command.py` | Functions or closures are often enough; classes help with undo, queues, metadata, or serialization. |
| Behavioral | Interpreter | `behavioral/rare_interpreter.py` | Parser libraries, pattern matching, or functions are often simpler unless building a DSL. |
| Behavioral | Iterator | `behavioral/classic_iterator.py` | Iteration is language-native through iterables, generators, and `__iter__`. |
| Behavioral | Mediator | `behavioral/mediator.py` | Often appears as an event bus, controller, queue, or service layer. |
| Behavioral | Memento | `behavioral/rare_memento.py` | Snapshots can be useful, but copies, persistence, or event logs may be clearer. |
| Behavioral | Observer | `behavioral/observer.py` | Usually callbacks, signals, async queues, or pub/sub. |
| Behavioral | State | `behavioral/state.py` | Start with simple conditionals; split into states when behavior and transitions grow. |
| Behavioral | Strategy | `behavioral/strategy.py` | Usually just pass a function; classes help when strategies carry state or dependencies. |
| Behavioral | Template Method | `behavioral/classic_template_method.py` | Composition is often easier to test than inheritance hooks. |
| Behavioral | Visitor | `behavioral/rare_visitor.py` | Consider `match`, `singledispatch`, or polymorphic methods first. |
