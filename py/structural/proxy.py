# Proxy controls access to another object, here delaying expensive creation.
# Modern Python note: proxies are useful for lazy loading, access checks, caching,
# remoting, and instrumentation when callers should keep the same interface.
class LargeImage:
    def __init__(self, path):
        print(f"loading {path}")
        self.path = path

    def display(self):
        return f"displaying {self.path}"


class ImageProxy:
    def __init__(self, path):
        self.path = path
        self._image = None

    def display(self):
        if self._image is None:
            self._image = LargeImage(self.path)
        return self._image.display()


if __name__ == "__main__":
    image = ImageProxy("photo.jpg")
    print("proxy created")
    print(image.display())
