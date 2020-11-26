using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.Models
{
    public class OrderItem
    {
        public double PieceLength { get; }

        public double QuantityOfPieceLength { get; set;}

        public int OrderItemID { get; }

        public OrderItem(double pieceLength, int orderItemID)
        {
            PieceLength = pieceLength;
            OrderItemID = orderItemID;
        }
    }
}
