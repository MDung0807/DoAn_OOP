using System;
using System.Collections.Generic;
using System.Text;

namespace NPL.SMS.R2S.Training.Entities
{
    class LineItem
    {
        int orderId;
        int productId;
        int quantity;
        double price;
        public int OrderId { get => orderId; set => orderId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }

        public LineItem() 
        { }
        public LineItem(int orderId,int productId,int quantity,double price)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
        }
        public override string ToString()
        {
            return string.Format("OrderId: {0}, ProductId: {1}, Quantity: {2}, Price: {3}", OrderId, ProductId,Quantity,Price);
        }
    }
}
