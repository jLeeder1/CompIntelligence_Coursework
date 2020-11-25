using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public interface IOrder
    {
        public List<OrderItem> OrderItemsList { get; set; }
    }
}