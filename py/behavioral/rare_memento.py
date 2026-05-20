# Memento captures state in a separate object so it can be restored later.
# Modern Python note: snapshots are useful, but dataclasses, copy, persistence, or
# event logs are often clearer than a dedicated Memento type.
class EditorMemento:
    def __init__(self, text):
        self.text = text


class Editor:
    def __init__(self):
        self.text = ""

    def type(self, words):
        self.text += words

    def save(self):
        return EditorMemento(self.text)

    def restore(self, memento):
        self.text = memento.text


if __name__ == "__main__":
    editor = Editor()
    editor.type("draft")
    saved = editor.save()
    editor.type(" with edits")
    editor.restore(saved)
    print(editor.text)
