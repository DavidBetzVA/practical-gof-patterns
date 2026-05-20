# Observer notifies subscribed callbacks whenever the subject publishes a change.
# Modern Python note: callbacks, signals, async queues, and pub/sub libraries are the
# usual forms. Be explicit about ownership and unsubscription in long-lived systems.
class NewsFeed:
    def __init__(self):
        self.subscribers = []

    def subscribe(self, callback):
        self.subscribers.append(callback)

    def publish(self, headline):
        return [callback(headline) for callback in self.subscribers]


def email_subscriber(headline):
    return f"email: {headline}"


def sms_subscriber(headline):
    return f"sms: {headline}"


if __name__ == "__main__":
    feed = NewsFeed()
    feed.subscribe(email_subscriber)
    feed.subscribe(sms_subscriber)
    print(feed.publish("Pattern examples released"))
