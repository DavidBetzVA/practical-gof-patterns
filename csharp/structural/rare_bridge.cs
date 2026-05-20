namespace Gof.ModernCSharp.Structural;

// Bridge separates an abstraction from the implementation object it controls.
// Modern C# note: collaborator injection is common; a named Bridge hierarchy is
// rarer unless both sides truly vary independently.
public static class RareBridge
{
    interface IDevice { bool Enabled { get; set; } }
    sealed class Tv : IDevice { public bool Enabled { get; set; } }
    sealed class Remote(IDevice device)
    {
        public void TogglePower() => device.Enabled = !device.Enabled;
    }

    public static string Run()
    {
        var tv = new Tv();
        new Remote(tv).TogglePower();
        return tv.Enabled.ToString();
    }
}
