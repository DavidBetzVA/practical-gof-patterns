# Builder assembles a complex object step by step behind a fluent construction API.
# Modern Python note: dataclasses, keyword arguments, or helper functions are often
# enough. A builder helps when construction has many validated or ordered steps.
class Sandwich:
    def __init__(self):
        self.parts = []

    def __str__(self):
        return ", ".join(self.parts)


class SandwichBuilder:
    def __init__(self):
        self.sandwich = Sandwich()

    def bread(self, kind):
        self.sandwich.parts.append(f"{kind} bread")
        return self

    def filling(self, item):
        self.sandwich.parts.append(item)
        return self

    def sauce(self, name):
        self.sandwich.parts.append(f"{name} sauce")
        return self

    def build(self):
        return self.sandwich


if __name__ == "__main__":
    lunch = SandwichBuilder().bread("rye").filling("turkey").sauce("mustard").build()
    print(lunch)
