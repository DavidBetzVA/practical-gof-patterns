namespace Gof.ModernCSharp.Behavioral;

// Iterator lets clients traverse a collection without exposing how it stores items.
// Modern C# note: iteration is language-native through IEnumerable<T>, yield
// return, LINQ, and foreach. Custom iterator classes are usually unnecessary.
public static class ClassicIterator
{
    sealed class Playlist(IEnumerable<string> songs) : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator() => songs.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static string Run() => string.Join(" > ", new Playlist(["Intro", "Main Theme", "Finale"]));
}
