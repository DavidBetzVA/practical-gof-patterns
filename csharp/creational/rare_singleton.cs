namespace Gof.ModernCSharp.Creational;

// Singleton ensures repeated access returns the same shared instance.
// Modern C# note: prefer DI lifetimes such as AddSingleton over static global
// access. Direct Singleton classes hide dependencies and complicate tests.
public static class RareSingleton
{
    sealed class Settings
    {
        public static Settings Instance { get; } = new();
        public string Theme { get; set; } = "light";
        private Settings() { }
    }

    public static string Run()
    {
        Settings.Instance.Theme = "dark";
        return Settings.Instance.Theme;
    }
}
