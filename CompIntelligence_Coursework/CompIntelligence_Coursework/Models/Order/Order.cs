using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    /*
     * Represents an order given to the factory in terms of what lengths the client needs and in what quantity
     */
    public class Order : IOrder
    {
        
        public Dictionary<double, double> OrderItems { get; }

        public Order()
        {
            OrderItems = new Dictionary<double, double>();
        }
    }
}
