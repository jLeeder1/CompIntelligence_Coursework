using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.Models
{
    public class OrderItem
    {
        public double PieceLength { get; }

        public double QuantityOfPieceLength { get; set;}

        public OrderItem(double pieceLength)
        {
            PieceLength = pieceLength;
        }
    }
}
