using System;

namespace BridgePatternExample
{
    // Implementor interface (device control interface)
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
        void SetVolume(int volume);
    }

    // Concrete implementor (TV)
    public class TV : IDevice
    {
        public void TurnOn() => Console.WriteLine("TV is turned on.");
        public void TurnOff() => Console.WriteLine("TV is turned off.");
        public void SetVolume(int volume) => Console.WriteLine($"TV volume set to {volume}.");
    }

    // Concrete implementor (Radio)
    public class Radio : IDevice
    {
        public void TurnOn() => Console.WriteLine("Radio is turned on.");
        public void TurnOff() => Console.WriteLine("Radio is turned off.");
        public void SetVolume(int volume) => Console.WriteLine($"Radio volume set to {volume}.");
    }

    // Abstraction (Remote Control)
    public class RemoteControl
    {
        protected IDevice _device;

        public RemoteControl(IDevice device)
        {
            _device = device;
        }

        public void TurnOn() => _device.TurnOn();
        public void TurnOff() => _device.TurnOff();
        public void SetVolume(int volume) => _device.SetVolume(volume);
    }

    // Refined abstraction (Advanced Remote Control)
    public class AdvancedRemoteControl : RemoteControl
    {
        public AdvancedRemoteControl(IDevice device) : base(device) { }

        public void Mute()
        {
            Console.WriteLine("Muting the device.");
            _device.SetVolume(0);
        }
    }

    // Example client code
    class Program
    {
        static void Main(string[] args)
        {
            // Controlling a TV with basic remote
            RemoteControl tvRemote = new RemoteControl(new TV());
            tvRemote.TurnOn();
            tvRemote.SetVolume(20);
            tvRemote.TurnOff();

            // Controlling a Radio with advanced remote
            AdvancedRemoteControl radioRemote = new AdvancedRemoteControl(new Radio());
            radioRemote.TurnOn();
            radioRemote.SetVolume(15);
            radioRemote.Mute();
            radioRemote.TurnOff();
        }
    }
}
