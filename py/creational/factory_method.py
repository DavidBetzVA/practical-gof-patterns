# Factory Method lets a superclass workflow defer object creation to subclasses.
# Modern Python note: passing a constructor or callable is often simpler than a
# subclass hierarchy unless the whole workflow is meant to be specialized.
from abc import ABC, abstractmethod


class Document(ABC):
    @abstractmethod
    def open(self):
        pass


class PdfDocument(Document):
    def open(self):
        return "opening PDF"


class TextDocument(Document):
    def open(self):
        return "opening text file"


class Application(ABC):
    def open_document(self):
        document = self.create_document()
        return document.open()

    @abstractmethod
    def create_document(self):
        pass


class PdfApplication(Application):
    def create_document(self):
        return PdfDocument()


class TextApplication(Application):
    def create_document(self):
        return TextDocument()


if __name__ == "__main__":
    print(PdfApplication().open_document())
