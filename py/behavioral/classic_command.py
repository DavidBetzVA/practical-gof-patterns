# Command turns an action into an object that can be passed around and executed.
# Modern Python note: a function or closure is often enough. A class earns its keep
# when commands need metadata, undo, queuing, serialization, or authorization.
class Light:
    def turn_on(self):
        return "light on"

    def turn_off(self):
        return "light off"


class LightOnCommand:
    def __init__(self, light):
        self.light = light

    def execute(self):
        return self.light.turn_on()


class Button:
    def __init__(self, command):
        self.command = command

    def press(self):
        return self.command.execute()


if __name__ == "__main__":
    print(Button(LightOnCommand(Light())).press())
