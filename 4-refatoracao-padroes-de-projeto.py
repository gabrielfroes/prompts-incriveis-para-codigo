class PaymentProcessor:
    def __init__(self, method):
        self.method = method

    def process_payment(self, amount):
        if self.method == 'credit_card':
            print(f"Processing credit card payment of ${amount}")
        elif self.method == 'paypal':
            print(f"Processing PayPal payment of ${amount}")
        elif self.method == 'bank_transfer':
            print(f"Processing bank transfer of ${amount}")
        else:
            raise ValueError("Unsupported payment method")
