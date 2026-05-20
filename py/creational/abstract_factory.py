# Abstract Factory creates related objects without naming their concrete classes.
# Modern Python note: this can often be a small factory function or config map.
# Keep the formal shape when related products must be created consistently.
from abc import ABC, abstractmethod


class Button(ABC):
    @abstractmethod
    def render(self):
        pass


class Checkbox(ABC):
    @abstractmethod
    def render(self):
        pass


class LightButton(Button):
    def render(self):
        return "light button"


class LightCheckbox(Checkbox):
    def render(self):
        return "light checkbox"


class DarkButton(Button):
    def render(self):
        return "dark button"


class DarkCheckbox(Checkbox):
    def render(self):
        return "dark checkbox"


class WidgetFactory(ABC):
    @abstractmethod
    def create_button(self):
        pass

    @abstractmethod
    def create_checkbox(self):
        pass


class LightFactory(WidgetFactory):
    def create_button(self):
        return LightButton()

    def create_checkbox(self):
        return LightCheckbox()


class DarkFactory(WidgetFactory):
    def create_button(self):
        return DarkButton()

    def create_checkbox(self):
        return DarkCheckbox()


def build_screen(factory):
    return [factory.create_button().render(), factory.create_checkbox().render()]


if __name__ == "__main__":
    print(build_screen(DarkFactory()))
