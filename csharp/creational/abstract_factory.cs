namespace Gof.ModernCSharp.Creational;

// Abstract Factory creates related objects without naming their concrete classes.
// Modern C# note: this is often a small factory service registered in DI. Keep
// the formal shape when related products must be created consistently.
public static class AbstractFactory
{
    interface IButton { string Render(); }
    interface ICheckbox { string Render(); }
    interface IWidgetFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    sealed class DarkButton : IButton { public string Render() => "dark button"; }
    sealed class DarkCheckbox : ICheckbox { public string Render() => "dark checkbox"; }
    sealed class DarkFactory : IWidgetFactory
    {
        public IButton CreateButton() => new DarkButton();
        public ICheckbox CreateCheckbox() => new DarkCheckbox();
    }

    public static string Run()
    {
        IWidgetFactory factory = new DarkFactory();
        return $"{factory.CreateButton().Render()}, {factory.CreateCheckbox().Render()}";
    }
}
