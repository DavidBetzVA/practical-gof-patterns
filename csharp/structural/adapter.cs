namespace Gof.ModernCSharp.Structural;

// Adapter wraps an incompatible object and exposes the interface a client expects.
// Modern C# note: still useful at package, HTTP, cloud SDK, and legacy boundaries.
public static class Adapter
{
    sealed class EuropeanSocket { public int Voltage() => 230; }
    interface IUsbPowerSource { int UsbVoltage(); }
    sealed class PhoneCharger { public string Charge(IUsbPowerSource source) => $"charging at {source.UsbVoltage()}V"; }

    sealed class EuropeanToUsbAdapter(EuropeanSocket socket) : IUsbPowerSource
    {
        public int UsbVoltage() => socket.Voltage() / 46;
    }

    public static string Run() => new PhoneCharger().Charge(new EuropeanToUsbAdapter(new EuropeanSocket()));
}
