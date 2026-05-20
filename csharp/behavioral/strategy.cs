namespace Gof.ModernCSharp.Behavioral;

// Strategy injects interchangeable algorithms behind the same calling shape.
// Modern C# note: delegates, lambdas, and Func<T> are usually the simplest form.
// Classes help when strategies carry state, dependencies, or lifecycle.
public static class Strategy
{
    static int FreeOver50Shipping(int orderTotal) => orderTotal >= 50 ? 0 : 5;

    sealed class Checkout(Func<int, int> shippingStrategy)
    {
        public int Total(int subtotal) => subtotal + shippingStrategy(subtotal);
    }

    public static string Run() => new Checkout(FreeOver50Shipping).Total(60).ToString();
}
