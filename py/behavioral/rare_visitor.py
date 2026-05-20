# Visitor puts operations in a separate object that each element type can accept.
# Modern Python note: consider pattern matching, singledispatch, or polymorphic
# methods first. Visitor helps when new operations must be added without changing
# the element classes.
class Circle:
    def __init__(self, radius):
        self.radius = radius

    def accept(self, visitor):
        return visitor.visit_circle(self)


class Rectangle:
    def __init__(self, width, height):
        self.width = width
        self.height = height

    def accept(self, visitor):
        return visitor.visit_rectangle(self)


class AreaVisitor:
    def visit_circle(self, circle):
        return 3.14 * circle.radius * circle.radius

    def visit_rectangle(self, rectangle):
        return rectangle.width * rectangle.height


if __name__ == "__main__":
    shapes = [Circle(2), Rectangle(3, 4)]
    print([shape.accept(AreaVisitor()) for shape in shapes])
