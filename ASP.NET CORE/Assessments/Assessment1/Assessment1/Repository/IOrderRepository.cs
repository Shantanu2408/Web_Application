using System.Collections.Generic;
using Assessment1.Models;

namespace Assessment1.Repository
{
    public interface IOrderRepository
    {
        public void PlaceOrder(Order order);
        Order GetOrderDetails(int orderId);
        public decimal DisplayBill(int orderId);
        List<Order> GetOrdersByDate(string orderDate);
        Customer GetCustomerWithHighestOrder();
    }
}
