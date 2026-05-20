# Mediator centralizes object communication so participants do not call each other directly.
# Modern Python note: event buses, controllers, queues, and service layers often play
# this role. Avoid a mediator that becomes a dumping ground for unrelated behavior.
class ChatRoom:
    def __init__(self):
        self.users = []

    def join(self, user):
        self.users.append(user)
        user.room = self

    def send(self, sender, message):
        return [user.receive(sender.name, message) for user in self.users if user != sender]


class User:
    def __init__(self, name):
        self.name = name
        self.room = None

    def send(self, message):
        return self.room.send(self, message)

    def receive(self, sender, message):
        return f"{self.name} got '{message}' from {sender}"


if __name__ == "__main__":
    room = ChatRoom()
    ada = User("Ada")
    grace = User("Grace")
    room.join(ada)
    room.join(grace)
    print(ada.send("hello"))
