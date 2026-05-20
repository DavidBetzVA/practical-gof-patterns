# Adapter wraps an incompatible object and exposes the interface a client expects.
# Modern Python note: duck typing reduces the need, but adapters are still valuable
# at API, library, network, and legacy-system boundaries.
class EuropeanSocket:
    def voltage(self):
        return 230


class PhoneCharger:
    def charge(self, usb_power_source):
        return f"charging at {usb_power_source.usb_voltage()}V"


class EuropeanToUsbAdapter:
    def __init__(self, socket):
        self.socket = socket

    def usb_voltage(self):
        wall_voltage = self.socket.voltage()
        return wall_voltage // 46


if __name__ == "__main__":
    charger = PhoneCharger()
    adapter = EuropeanToUsbAdapter(EuropeanSocket())
    print(charger.charge(adapter))
