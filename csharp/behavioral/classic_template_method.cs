namespace Gof.ModernCSharp.Behavioral;

// Template Method fixes an algorithm's outline while subclasses fill in selected steps.
// Modern C# note: composition with injected functions or collaborators is often
// easier to test than inheritance hooks.
public static class ClassicTemplateMethod
{
    abstract class DataImporter
    {
        public string Import(string source)
        {
            var rows = Parse(source);
            return $"saved {rows.Count} rows";
        }

        protected abstract IReadOnlyList<string[]> Parse(string raw);
    }

    sealed class CsvImporter : DataImporter
    {
        protected override IReadOnlyList<string[]> Parse(string raw) =>
            raw.Split('\n').Select(line => line.Split(',')).ToList();
    }

    public static string Run() => new CsvImporter().Import("name,role\nAda,admin");
}
