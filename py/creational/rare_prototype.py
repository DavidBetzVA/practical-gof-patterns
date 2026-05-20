# Prototype creates new objects by cloning an existing configured instance.
# Modern Python note: this is rare; copy/deepcopy is useful, but explicit constructors
# or dataclass replacement are usually clearer than a formal prototype registry.
import copy


class Shape:
    def __init__(self, kind, color):
        self.kind = kind
        self.color = color

    def clone(self):
        return copy.deepcopy(self)

    def __repr__(self):
        return f"Shape(kind={self.kind!r}, color={self.color!r})"


if __name__ == "__main__":
    original = Shape("circle", "blue")
    duplicate = original.clone()
    duplicate.color = "green"
    print(original)
    print(duplicate)
