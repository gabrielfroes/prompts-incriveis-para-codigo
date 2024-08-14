using System;
using System.Collections.Generic;

namespace OnlineStore
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderItem> Items { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsShipped { get; set; }
        
        public Order()
        {
            Items = new List<OrderItem>();
            OrderDate = DateTime.Now;
            IsShipped = false;
        }

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.Find(i => i.Product.ProductId == product.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new OrderItem { Product = product, Quantity = quantity });
            }
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Product.Price * item.Quantity;
            }

            if (total > 100)
            {
                total -= 10; // Discount for orders over $100
            }

            return total;
        }

        public void MarkAsShipped()
        {
            IsShipped = true;
        }
    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderService
    {
        private List<Order> _orders = new List<Order>();

        public void PlaceOrder(Order order)
        {
            if (order.Items.Count == 0)
            {
                throw new InvalidOperationException("Cannot place an order with no items.");
            }

            // Simulating saving to a database
            _orders.Add(order);
            SendConfirmationEmail(order.CustomerEmail);
        }

        private void SendConfirmationEmail(string email)
        {
            // Simulating sending an email
            Console.WriteLine($"Sending confirmation email to {email}");
        }

        public Order GetOrderById(int orderId)
        {
            return _orders.Find(o => o.OrderId == orderId);
        }

        public void ShipOrder(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order == null)
            {
                throw new Exception("Order not found.");
            }

            if (order.IsShipped)
            {
                throw new InvalidOperationException("Order is already shipped.");
            }

            order.MarkAsShipped();
            Console.WriteLine($"Order {orderId} has been shipped.");
        }
    }
}
