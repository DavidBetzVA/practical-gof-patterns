namespace Gof.ModernCSharp.Creational;

// Builder assembles a complex object step by step behind a fluent construction API.
// Modern C# note: object initializers, records, and optional parameters are often
// enough. A builder helps when construction has ordered steps or validation.
public static class Builder
{
    sealed record Sandwich(List<string> Parts)
    {
        public override string ToString() => string.Join(", ", Parts);
    }

    sealed class SandwichBuilder
    {
        readonly List<string> _parts = [];

        public SandwichBuilder Bread(string kind) { _parts.Add($"{kind} bread"); return this; }
        public SandwichBuilder Filling(string item) { _parts.Add(item); return this; }
        public SandwichBuilder Sauce(string name) { _parts.Add($"{name} sauce"); return this; }
        public Sandwich Build() => new([.. _parts]);
    }

    public static string Run() =>
        new SandwichBuilder().Bread("rye").Filling("turkey").Sauce("mustard").Build().ToString();
}
