# Facade hides subsystem details behind a smaller, easier entry point.
# Modern Python note: this is often just a well-designed module, service, or client
# API that keeps messy subsystem coordination out of callers.
class Amplifier:
    def on(self):
        return "amp on"


class Projector:
    def on(self):
        return "projector on"


class Player:
    def play(self, movie):
        return f"playing {movie}"


class HomeTheaterFacade:
    def __init__(self):
        self.amp = Amplifier()
        self.projector = Projector()
        self.player = Player()

    def watch_movie(self, movie):
        return [self.amp.on(), self.projector.on(), self.player.play(movie)]


if __name__ == "__main__":
    print(HomeTheaterFacade().watch_movie("Casablanca"))
