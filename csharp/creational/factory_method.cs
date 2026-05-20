namespace Gof.ModernCSharp.Creational;

// Factory Method lets a superclass workflow defer object creation to subclasses.
// Modern C# note: passing Func<T> or using DI is often simpler unless the whole
// workflow is intentionally specialized by inheritance.
public static class FactoryMethod
{
    interface IDocument { string Open(); }
    sealed class PdfDocument : IDocument { public string Open() => "opening PDF"; }

    abstract class Application
    {
        public string OpenDocument() => CreateDocument().Open();
        protected abstract IDocument CreateDocument();
    }

    sealed class PdfApplication : Application
    {
        protected override IDocument CreateDocument() => new PdfDocument();
    }

    public static string Run() => new PdfApplication().OpenDocument();
}
