# Flyweight shares reusable intrinsic state across many small objects.
# Modern Python note: use this only when profiling shows many duplicate objects or
# real memory pressure. Caches, interning, and value objects often cover the need.
class Glyph:
    def __init__(self, char):
        self.char = char

    def draw(self, position):
        return f"{self.char}@{position}"


class GlyphFactory:
    def __init__(self):
        self._glyphs = {}

    def get(self, char):
        if char not in self._glyphs:
            self._glyphs[char] = Glyph(char)
        return self._glyphs[char]


if __name__ == "__main__":
    factory = GlyphFactory()
    first = factory.get("A")
    second = factory.get("A")
    print(first is second)
    print(first.draw((10, 20)))
