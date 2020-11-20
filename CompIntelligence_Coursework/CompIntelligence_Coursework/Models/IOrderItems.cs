using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public interface IOrderItems
    {
        public List<OrderItem> OrderItemsList { get; set; }
    }
}