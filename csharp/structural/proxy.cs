namespace Gof.ModernCSharp.Structural;

// Proxy controls access to another object, here delaying expensive creation.
// Modern C# note: useful for lazy loading, access checks, caching, remoting, and
// instrumentation when callers should keep the same interface.
public static class Proxy
{
    interface IImage { string Display(); }
    sealed class LargeImage(string path) : IImage
    {
        public string Display() => $"displaying {path}";
    }

    sealed class ImageProxy(string path) : IImage
    {
        readonly Lazy<LargeImage> _image = new(() => new LargeImage(path));
        public string Display() => _image.Value.Display();
    }

    public static string Run() => new ImageProxy("photo.jpg").Display();
}
