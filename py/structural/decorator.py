# Decorator wraps an object to add behavior while preserving its public interface.
# Modern Python note: function decorators cover callable wrapping; object decorators
# still matter when behavior is composed around runtime objects.
class Coffee:
    def cost(self):
        return 3

    def description(self):
        return "coffee"


class MilkDecorator:
    def __init__(self, drink):
        self.drink = drink

    def cost(self):
        return self.drink.cost() + 1

    def description(self):
        return f"{self.drink.description()} with milk"


if __name__ == "__main__":
    drink = MilkDecorator(Coffee())
    print(drink.description(), drink.cost())
