# Singleton ensures repeated construction returns the same shared instance.
# Modern Python note: prefer module-level objects or explicit dependency injection.
# Direct Singleton classes hide dependencies and can make tests harder to isolate.
class Settings:
    _instance = None

    def __new__(cls):
        if cls._instance is None:
            cls._instance = super().__new__(cls)
            cls._instance.theme = "light"
        return cls._instance


if __name__ == "__main__":
    first = Settings()
    second = Settings()
    second.theme = "dark"
    print(first is second)
    print(first.theme)
