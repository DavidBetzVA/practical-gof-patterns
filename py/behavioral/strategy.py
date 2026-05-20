# Strategy injects interchangeable algorithms behind the same calling shape.
# Modern Python note: first-class functions are usually the simplest Strategy. Use
# classes when a strategy carries state, dependencies, or lifecycle.
def standard_shipping(order_total):
    return 5


def free_over_50_shipping(order_total):
    return 0 if order_total >= 50 else 5


class Checkout:
    def __init__(self, shipping_strategy):
        self.shipping_strategy = shipping_strategy

    def total(self, subtotal):
        return subtotal + self.shipping_strategy(subtotal)


if __name__ == "__main__":
    checkout = Checkout(free_over_50_shipping)
    print(checkout.total(60))
