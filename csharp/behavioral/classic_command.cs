namespace Gof.ModernCSharp.Behavioral;

// Command turns an action into an object that can be passed around and executed.
// Modern C# note: Action, Func<T>, and lambdas are often enough. Classes help
// when commands need undo, queues, metadata, serialization, or authorization.
public static class ClassicCommand
{
    sealed class Light { public string TurnOn() => "light on"; }
    interface ICommand { string Execute(); }
    sealed class LightOnCommand(Light light) : ICommand
    {
        public string Execute() => light.TurnOn();
    }
    sealed class Button(ICommand command)
    {
        public string Press() => command.Execute();
    }

    public static string Run() => new Button(new LightOnCommand(new Light())).Press();
}
