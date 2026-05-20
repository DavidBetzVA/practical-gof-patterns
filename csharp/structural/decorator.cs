namespace Gof.ModernCSharp.Structural;

// Decorator wraps an object to add behavior while preserving its public interface.
// Modern C# note: attributes are not this pattern by themselves. This remains
// common in streams, middleware, pipelines, and DI-registered service wrappers.
public static class Decorator
{
    interface IDrink { int Cost(); string Description(); }
    sealed class Coffee : IDrink
    {
        public int Cost() => 3;
        public string Description() => "coffee";
    }

    sealed class MilkDecorator(IDrink drink) : IDrink
    {
        public int Cost() => drink.Cost() + 1;
        public string Description() => $"{drink.Description()} with milk";
    }

    public static string Run()
    {
        IDrink drink = new MilkDecorator(new Coffee());
        return $"{drink.Description()} costs {drink.Cost()}";
    }
}
