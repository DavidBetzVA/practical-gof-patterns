namespace Gof.ModernCSharp.Creational;

// Prototype creates new objects by cloning an existing configured instance.
// Modern C# note: records with `with` expressions usually cover this. Formal
// prototype registries are rare unless cloning behavior is central to the domain.
public static class RarePrototype
{
    sealed record Shape(string Kind, string Color);

    public static string Run()
    {
        var original = new Shape("circle", "blue");
        var copy = original with { Color = "green" };
        return $"{original} -> {copy}";
    }
}
