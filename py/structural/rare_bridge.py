# Bridge separates an abstraction from the implementation object it controls.
# Modern Python note: this exact class hierarchy is uncommon; passing a collaborator
# object is useful, but it does not always need to be named as Bridge.
class Remote:
    def __init__(self, device):
        self.device = device

    def toggle_power(self):
        if self.device.enabled:
            self.device.disable()
        else:
            self.device.enable()


class Device:
    def __init__(self):
        self.enabled = False

    def enable(self):
        self.enabled = True

    def disable(self):
        self.enabled = False


class Tv(Device):
    pass


class Radio(Device):
    pass


if __name__ == "__main__":
    tv = Tv()
    remote = Remote(tv)
    remote.toggle_power()
    print(tv.enabled)
