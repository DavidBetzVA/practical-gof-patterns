namespace Gof.ModernCSharp.Behavioral;

// Visitor puts operations in a separate object that each element type can accept.
// Modern C# note: consider pattern matching or polymorphic methods first. Visitor
// helps when new operations must be added without changing element classes.
public static class RareVisitor
{
    interface IShape { double Accept(IShapeVisitor visitor); }
    sealed record Circle(double Radius) : IShape
    {
        public double Accept(IShapeVisitor visitor) => visitor.Visit(this);
    }
    sealed record Rectangle(double Width, double Height) : IShape
    {
        public double Accept(IShapeVisitor visitor) => visitor.Visit(this);
    }
    interface IShapeVisitor
    {
        double Visit(Circle circle);
        double Visit(Rectangle rectangle);
    }
    sealed class AreaVisitor : IShapeVisitor
    {
        public double Visit(Circle circle) => Math.PI * circle.Radius * circle.Radius;
        public double Visit(Rectangle rectangle) => rectangle.Width * rectangle.Height;
    }

    public static string Run()
    {
        IShape[] shapes = [new Circle(2), new Rectangle(3, 4)];
        return string.Join(", ", shapes.Select(shape => shape.Accept(new AreaVisitor()).ToString("0.##")));
    }
}
