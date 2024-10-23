using System;

namespace FacadePatternExample
{
    // Subsystem classes
    public class Projector
    {
        public void On() => Console.WriteLine("Projector is on.");
        public void Off() => Console.WriteLine("Projector is off.");
    }

    public class SoundSystem
    {
        public void On() => Console.WriteLine("Sound system is on.");
        public void Off() => Console.WriteLine("Sound system is off.");
    }

    public class DvdPlayer
    {
        public void Play() => Console.WriteLine("DVD is playing.");
        public void Stop() => Console.WriteLine("DVD stopped.");
    }

    // Facade class
    public class HomeTheaterFacade
    {
        private readonly Projector _projector;
        private readonly SoundSystem _soundSystem;
        private readonly DvdPlayer _dvdPlayer;

        public HomeTheaterFacade(Projector projector, SoundSystem soundSystem, DvdPlayer dvdPlayer)
        {
            _projector = projector;
            _soundSystem = soundSystem;
            _dvdPlayer = dvdPlayer;
        }

        public void StartMovie()
        {
            _projector.On();
            _soundSystem.On();
            _dvdPlayer.Play();
            Console.WriteLine("Movie started.");
        }

        public void EndMovie()
        {
            _dvdPlayer.Stop();
            _soundSystem.Off();
            _projector.Off();
            Console.WriteLine("Movie ended.");
        }
    }

    // Example client code using the facade
    class Program
    {
        static void Main(string[] args)
        {
            // Facade simplifies the interaction with complex subsystems
            var homeTheater = new HomeTheaterFacade(new Projector(), new SoundSystem(), new DvdPlayer());

            // Start a movie
            homeTheater.StartMovie();

            // End the movie
            homeTheater.EndMovie();
        }
    }
}