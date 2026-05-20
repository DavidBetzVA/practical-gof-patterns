namespace Gof.ModernCSharp.Behavioral;

// Memento captures state in a separate object so it can be restored later.
// Modern C# note: records, snapshots, persistence, or event sourcing may be
// clearer than a dedicated Memento type.
public static class RareMemento
{
    sealed record EditorMemento(string Text);
    sealed class Editor
    {
        public string Text { get; private set; } = "";
        public void Type(string words) => Text += words;
        public EditorMemento Save() => new(Text);
        public void Restore(EditorMemento memento) => Text = memento.Text;
    }

    public static string Run()
    {
        var editor = new Editor();
        editor.Type("draft");
        var saved = editor.Save();
        editor.Type(" with edits");
        editor.Restore(saved);
        return editor.Text;
    }
}
