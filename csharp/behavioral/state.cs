namespace Gof.ModernCSharp.Behavioral;

// State moves behavior into state objects so an object can react differently over time.
// Modern C# note: start with simple conditionals or switch expressions. Split
// states into objects when transitions and behavior grow together.
public static class State
{
    interface IDocumentState { string Publish(Document document); }
    sealed class DraftState : IDocumentState
    {
        public string Publish(Document document) { document.CurrentState = new PublishedState(); return "published"; }
    }
    sealed class PublishedState : IDocumentState
    {
        public string Publish(Document document) => "already published";
    }
    sealed class Document
    {
        public IDocumentState CurrentState { get; set; } = new DraftState();
        public string Publish() => CurrentState.Publish(this);
    }

    public static string Run()
    {
        var doc = new Document();
        return $"{doc.Publish()}, {doc.Publish()}";
    }
}
