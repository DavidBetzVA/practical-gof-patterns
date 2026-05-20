# Chain of Responsibility passes a request through handlers until one can answer.
# Modern Python note: this is common as middleware, hooks, pipelines, and validators.
# Keep each handler small and make ordering explicit.
class Handler:
    def __init__(self, next_handler=None):
        self.next_handler = next_handler

    def handle(self, request):
        if self.next_handler:
            return self.next_handler.handle(request)
        return None


class AuthHandler(Handler):
    def handle(self, request):
        if not request.get("user"):
            return "missing user"
        return super().handle(request)


class RoleHandler(Handler):
    def handle(self, request):
        if request.get("role") != "admin":
            return "forbidden"
        return "approved"


if __name__ == "__main__":
    chain = AuthHandler(RoleHandler())
    print(chain.handle({"user": "Ada", "role": "admin"}))
