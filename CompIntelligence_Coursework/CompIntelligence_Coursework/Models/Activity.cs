using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.Models
{
    public class Activity
    {
        public StockItem StockItemUsed { get; set; }
        public List<double> PositionsToCutAt { get; set; }
        public double Offcut { get; set; }

        public Activity()
        {
            PositionsToCutAt = new List<double>();
        }
    }
}
