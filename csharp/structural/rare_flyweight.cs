namespace Gof.ModernCSharp.Structural;

// Flyweight shares reusable intrinsic state across many small objects.
// Modern C# note: use only when profiling shows duplicate object memory pressure.
// Caches, string interning, records, and value types often cover the need.
public static class RareFlyweight
{
    sealed class Glyph(char value)
    {
        public string Draw((int X, int Y) position) => $"{value}@{position}";
    }

    sealed class GlyphFactory
    {
        readonly Dictionary<char, Glyph> _glyphs = [];
        public Glyph Get(char value) => _glyphs.TryGetValue(value, out var glyph)
            ? glyph
            : _glyphs[value] = new Glyph(value);
    }

    public static string Run()
    {
        var factory = new GlyphFactory();
        return ReferenceEquals(factory.Get('A'), factory.Get('A')).ToString();
    }
}
