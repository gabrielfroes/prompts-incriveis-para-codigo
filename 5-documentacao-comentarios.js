function calculateTotalPrice(cartItems) {
  let total = 0;
  for (let i = 0; i < cartItems.length; i++) {
    let item = cartItems[i];
    let price = item.price;
    let quantity = item.quantity;
    total += price * quantity;
  }
  return total;
}
