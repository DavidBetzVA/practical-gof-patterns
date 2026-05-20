namespace Gof.ModernCSharp.Behavioral;

// Mediator centralizes object communication so participants do not call each other directly.
// Modern C# note: often appears as a message bus, controller, queue, or application
// service. Avoid letting it become a dumping ground.
public static class Mediator
{
    sealed class ChatRoom
    {
        readonly List<User> _users = [];
        public void Join(User user) { _users.Add(user); user.Room = this; }
        public IEnumerable<string> Send(User sender, string message) =>
            _users.Where(user => user != sender).Select(user => user.Receive(sender.Name, message));
    }

    sealed class User(string name)
    {
        public string Name => name;
        public ChatRoom? Room { get; set; }
        public IEnumerable<string> Send(string message) => Room!.Send(this, message);
        public string Receive(string sender, string message) => $"{Name} got '{message}' from {sender}";
    }

    public static string Run()
    {
        var room = new ChatRoom();
        var ada = new User("Ada");
        room.Join(ada);
        room.Join(new User("Grace"));
        return string.Join(", ", ada.Send("hello"));
    }
}
