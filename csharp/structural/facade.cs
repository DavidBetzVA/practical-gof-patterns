namespace Gof.ModernCSharp.Structural;

// Facade hides subsystem details behind a smaller, easier entry point.
// Modern C# note: often just a clean service, client, or application-layer API.
public static class Facade
{
    sealed class Amplifier { public string On() => "amp on"; }
    sealed class Projector { public string On() => "projector on"; }
    sealed class Player { public string Play(string movie) => $"playing {movie}"; }

    sealed class HomeTheater
    {
        readonly Amplifier _amp = new();
        readonly Projector _projector = new();
        readonly Player _player = new();

        public string WatchMovie(string movie) => $"{_amp.On()}, {_projector.On()}, {_player.Play(movie)}";
    }

    public static string Run() => new HomeTheater().WatchMovie("Casablanca");
}
