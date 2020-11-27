using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public interface IOrder
    {
        public Dictionary<double, double> OrderItems { get; }
    }
}