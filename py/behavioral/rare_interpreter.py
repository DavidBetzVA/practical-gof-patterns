# Interpreter models a tiny language as expression objects that evaluate themselves.
# Modern Python note: this is uncommon unless you are building a DSL. Parser
# libraries, pattern matching, or plain functions are often simpler.
class Number:
    def __init__(self, value):
        self.value = value

    def interpret(self):
        return self.value


class Add:
    def __init__(self, left, right):
        self.left = left
        self.right = right

    def interpret(self):
        return self.left.interpret() + self.right.interpret()


if __name__ == "__main__":
    expression = Add(Number(2), Add(Number(3), Number(4)))
    print(expression.interpret())
