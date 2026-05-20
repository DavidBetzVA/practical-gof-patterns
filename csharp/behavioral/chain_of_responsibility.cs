namespace Gof.ModernCSharp.Behavioral;

// Chain of Responsibility passes a request through handlers until one can answer.
// Modern C# note: common as ASP.NET Core middleware, validators, filters, and
// pipelines. Keep ordering explicit.
public static class ChainOfResponsibility
{
    sealed record Request(string? User, string Role);
    abstract class Handler(Handler? next = null)
    {
        public virtual string? Handle(Request request) => next?.Handle(request);
    }

    sealed class AuthHandler(Handler next) : Handler(next)
    {
        public override string? Handle(Request request) =>
            request.User is null ? "missing user" : base.Handle(request);
    }

    sealed class RoleHandler : Handler
    {
        public override string? Handle(Request request) => request.Role == "admin" ? "approved" : "forbidden";
    }

    public static string Run() => new AuthHandler(new RoleHandler()).Handle(new("Ada", "admin"))!;
}
