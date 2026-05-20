namespace Gof.ModernCSharp.Behavioral;

// Observer notifies subscribers whenever the subject publishes a change.
// Modern C# note: events, IObservable<T>, channels, and message buses are common.
// Be explicit about unsubscription in long-lived systems.
public static class Observer
{
    sealed class NewsFeed
    {
        public event Action<string>? Published;
        public void Publish(string headline) => Published?.Invoke(headline);
    }

    public static string Run()
    {
        var messages = new List<string>();
        var feed = new NewsFeed();
        feed.Published += headline => messages.Add($"email: {headline}");
        feed.Published += headline => messages.Add($"sms: {headline}");
        feed.Publish("Pattern examples released");
        return string.Join(", ", messages);
    }
}
