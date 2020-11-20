using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public class OrderItems : IOrderItems
    {
        
        public List<OrderItem> OrderItemsList { get; set; }

        public OrderItems()
        {
            OrderItemsList = new List<OrderItem>();
        }
    }
}
