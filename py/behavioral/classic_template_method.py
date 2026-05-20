# Template Method fixes an algorithm's outline while subclasses fill in selected steps.
# Modern Python note: inheritance can be too rigid; composition with injected
# functions or small collaborators is often easier to test and extend.
from abc import ABC, abstractmethod


class DataImporter(ABC):
    def import_data(self, source):
        raw = self.read(source)
        rows = self.parse(raw)
        return self.save(rows)

    def read(self, source):
        return source

    @abstractmethod
    def parse(self, raw):
        pass

    def save(self, rows):
        return f"saved {len(rows)} rows"


class CsvImporter(DataImporter):
    def parse(self, raw):
        return [line.split(",") for line in raw.splitlines()]


if __name__ == "__main__":
    print(CsvImporter().import_data("name,role\nAda,admin"))
