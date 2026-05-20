namespace Gof.ModernCSharp.Behavioral;

// Interpreter models a tiny language as expression objects that evaluate themselves.
// Modern C# note: rare unless building a DSL. Parser libraries, expression trees,
// pattern matching, or simple functions are often better.
public static class RareInterpreter
{
    interface IExpression { int Interpret(); }
    sealed record Number(int Value) : IExpression { public int Interpret() => Value; }
    sealed record Add(IExpression Left, IExpression Right) : IExpression
    {
        public int Interpret() => Left.Interpret() + Right.Interpret();
    }

    public static string Run() => new Add(new Number(2), new Add(new Number(3), new Number(4))).Interpret().ToString();
}
