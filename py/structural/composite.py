# Composite treats individual objects and object groups through the same interface.
# Modern Python note: this remains useful for trees, documents, menus, filesystems,
# and UI structures where leaves and groups should share operations.
class File:
    def __init__(self, name, size):
        self.name = name
        self.size = size

    def total_size(self):
        return self.size


class Folder:
    def __init__(self, name):
        self.name = name
        self.children = []

    def add(self, child):
        self.children.append(child)

    def total_size(self):
        return sum(child.total_size() for child in self.children)


if __name__ == "__main__":
    root = Folder("root")
    root.add(File("readme.txt", 2))
    assets = Folder("assets")
    assets.add(File("logo.png", 10))
    root.add(assets)
    print(root.total_size())
