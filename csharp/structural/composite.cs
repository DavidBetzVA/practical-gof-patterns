namespace Gof.ModernCSharp.Structural;

// Composite treats individual objects and object groups through the same interface.
// Modern C# note: useful for trees such as menus, documents, ASTs, filesystems,
// and UI structures.
public static class Composite
{
    interface INode { int TotalSize(); }
    sealed record FileNode(string Name, int Size) : INode { public int TotalSize() => Size; }
    sealed class FolderNode(string name) : INode
    {
        readonly List<INode> _children = [];
        public void Add(INode child) => _children.Add(child);
        public int TotalSize() => _children.Sum(child => child.TotalSize());
        public override string ToString() => name;
    }

    public static string Run()
    {
        var root = new FolderNode("root");
        root.Add(new FileNode("readme.txt", 2));
        var assets = new FolderNode("assets");
        assets.Add(new FileNode("logo.png", 10));
        root.Add(assets);
        return root.TotalSize().ToString();
    }
}
