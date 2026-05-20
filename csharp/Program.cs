using Gof.ModernCSharp.Behavioral;
using Gof.ModernCSharp.Creational;
using Gof.ModernCSharp.Structural;

var samples = new (string Name, Func<string> Run)[]
{
    ("Abstract Factory", AbstractFactory.Run),
    ("Builder", Builder.Run),
    ("Factory Method", FactoryMethod.Run),
    ("Prototype", RarePrototype.Run),
    ("Singleton", RareSingleton.Run),
    ("Adapter", Adapter.Run),
    ("Bridge", RareBridge.Run),
    ("Composite", Composite.Run),
    ("Decorator", Decorator.Run),
    ("Facade", Facade.Run),
    ("Flyweight", RareFlyweight.Run),
    ("Proxy", Proxy.Run),
    ("Chain of Responsibility", ChainOfResponsibility.Run),
    ("Command", ClassicCommand.Run),
    ("Interpreter", RareInterpreter.Run),
    ("Iterator", ClassicIterator.Run),
    ("Mediator", Mediator.Run),
    ("Memento", RareMemento.Run),
    ("Observer", Observer.Run),
    ("State", State.Run),
    ("Strategy", Strategy.Run),
    ("Template Method", ClassicTemplateMethod.Run),
    ("Visitor", RareVisitor.Run),
};

foreach (var (name, run) in samples)
{
    Console.WriteLine($"{name}: {run()}");
}
