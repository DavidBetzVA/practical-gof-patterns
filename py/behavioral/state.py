# State moves behavior into state objects so an object can react differently over time.
# Modern Python note: start with simple conditionals for small state machines. Split
# states into objects when transitions and behavior are growing together.
class DraftState:
    def publish(self, document):
        document.state = PublishedState()
        return "published"


class PublishedState:
    def publish(self, document):
        return "already published"


class Document:
    def __init__(self):
        self.state = DraftState()

    def publish(self):
        return self.state.publish(self)


if __name__ == "__main__":
    doc = Document()
    print(doc.publish())
    print(doc.publish())
