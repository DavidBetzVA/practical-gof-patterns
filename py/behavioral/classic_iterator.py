# Iterator lets clients traverse a collection without exposing how it stores items.
# Modern Python note: iteration is language-native. Most code should use iterables,
# generators, or __iter__ rather than custom iterator class hierarchies.
class Playlist:
    def __init__(self, songs):
        self.songs = songs

    def __iter__(self):
        return iter(self.songs)


if __name__ == "__main__":
    playlist = Playlist(["Intro", "Main Theme", "Finale"])
    for song in playlist:
        print(song)
