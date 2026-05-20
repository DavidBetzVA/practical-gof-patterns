# GoF Pattern Catalog

This repository presents the Gang of Four patterns as problem-solving vocabulary,
with modern language-specific notes that discourage cargo-cult usage.

| Implementation | Notes |
| --- | --- |
| `py/` | Modern Python samples with Python-specific alternatives and caution labels. |
| `csharp/` | Modern C# samples with C#-specific alternatives and caution labels. |

## Problem-First Index

Developers usually search by the problem in front of them, not by a pattern
name. Use this table as a starting point, then check the last column before
adding structure.

| If you need to... | Consider | But first ask... |
| --- | --- | --- |
| Adapt a third-party, legacy, or external API to your application's shape | Adapter | Can the boundary be normalized once instead of patched throughout the codebase? |
| Add behavior around an object without changing its interface | Decorator | Is the wrapping order obvious and shallow enough to debug? |
| Add operations across a stable object hierarchy | Visitor | Is the hierarchy stable enough to justify coupling every visitor to every element type? |
| Build a complex object step by step | Builder | Would direct construction, named arguments, or object initialization be clearer? |
| Capture undo or restore points | Memento | Would immutable values, snapshots, persistence, or an event log be clearer? |
| Choose between interchangeable algorithms | Strategy | Would passing a function, delegate, or small collaborator be enough? |
| Control access, lifecycle, latency, caching, or remoting for an object | Proxy | Will callers be surprised by hidden work, stale data, or delayed failures? |
| Coordinate peers without direct references between all of them | Mediator | Is this avoiding coupling, or creating a central object that knows too much? |
| Create related families of objects consistently | Abstract Factory | Is there a real product family, or are you abstracting future possibilities? |
| Defer object creation inside a reusable workflow | Factory Method | Would passing a constructor, factory function, or dependency be simpler? |
| Define an algorithm outline with replaceable steps | Template Method | Would composition avoid fragile inheritance hooks? |
| Ensure one shared instance | Singleton | Should lifetime be owned by a module, process, or dependency-injection container instead? |
| Hide a messy subsystem behind a simpler API | Facade | Is the subsystem stable enough that a simplified surface will not leak constantly? |
| Interpret a small language or grammar | Interpreter | Should this be a parser, expression tree, or existing language feature instead? |
| Model behavior that changes with state | State | Is a simple conditional, state table, or switch still clearer? |
| Notify dependents when something changes | Observer | Who owns subscription cleanup, ordering, and failure handling? |
| Represent whole/part tree structures | Composite | Do leaves and groups genuinely share the same operations? |
| Reuse a configured object as a template | Prototype | Would copying, cloning, or immutable value replacement be clearer? |
| Route a request through ordered handlers | Chain of Responsibility | Is the handler order explicit, tested, and observable when nothing handles the request? |
| Share many repeated small objects | Flyweight | Have measurements shown object duplication is a real memory problem? |
| Traverse a collection uniformly | Iterator | Does the language already provide the traversal protocol you need? |
| Vary an abstraction and its implementation independently | Bridge | Do both sides truly vary independently, or is collaborator injection enough? |

## Category Map

| Category       | High-Level Focus                       | Core Question It Solves                                        |
| -------------- | -------------------------------------- | -------------------------------------------------------------- |
| **Creational** | How objects are created                | “How should this object or family of objects be instantiated?” |
| **Structural** | How objects and classes are composed   | “How should these pieces be organized and connected?”          |
| **Behavioral** | How objects communicate and coordinate | “How should responsibilities and interactions be distributed?” |

## Pattern Reference

| Category       | Pattern                 | Summary                                                                                                                |
| -------------- | ----------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| **Creational** | Abstract Factory        | Provides an interface for creating families of related objects without specifying their concrete classes.              |
| **Creational** | Builder                 | Separates the construction of a complex object from its representation so the same process can create different forms. |
| **Creational** | Factory Method          | Defines an interface for object creation while allowing subclasses to decide which class to instantiate.               |
| **Creational** | Prototype               | Creates new objects by cloning an existing prototype instance.                                                         |
| **Creational** | Singleton               | Ensures a class has only one instance and provides global access to it.                                                |
| **Structural** | Adapter                 | Converts one interface into another interface clients expect, enabling incompatible classes to work together.          |
| **Structural** | Bridge                  | Decouples an abstraction from its implementation so the two can vary independently.                                    |
| **Structural** | Composite               | Composes objects into tree structures so individual objects and groups can be treated uniformly.                       |
| **Structural** | Decorator               | Dynamically adds responsibilities or behavior to objects without modifying their class.                                |
| **Structural** | Facade                  | Provides a simplified unified interface to a larger and more complex subsystem.                                        |
| **Structural** | Flyweight               | Minimizes memory use by sharing common object state across many fine-grained objects.                                  |
| **Structural** | Proxy                   | Provides a placeholder or surrogate object that controls access to another object.                                     |
| **Behavioral** | Chain of Responsibility | Passes requests along a chain of handlers until one of them processes the request.                                     |
| **Behavioral** | Command                 | Encapsulates a request as an object so operations can be parameterized, queued, or undone.                             |
| **Behavioral** | Interpreter             | Defines a grammar and interpreter for evaluating sentences in a language.                                              |
| **Behavioral** | Iterator                | Provides a way to sequentially access elements of a collection without exposing its internal structure.                |
| **Behavioral** | Mediator                | Centralizes communication between objects to reduce direct dependencies among them.                                    |
| **Behavioral** | Memento                 | Captures and restores an object's internal state without violating encapsulation.                                      |
| **Behavioral** | Observer                | Defines a one-to-many dependency so observers are automatically notified of state changes.                             |
| **Behavioral** | State                   | Allows an object to alter its behavior when its internal state changes.                                                |
| **Behavioral** | Strategy                | Encapsulates interchangeable algorithms behind a common interface.                                                     |
| **Behavioral** | Template Method         | Defines the skeleton of an algorithm while allowing subclasses to customize specific steps.                            |
| **Behavioral** | Visitor                 | Separates operations from object structures so new operations can be added without changing the objects.               |
