using System;
using System.Collections.Generic;
using System.Text;

namespace NPL.SMS.R2S.Training.Entities
{
    class Product
    {
        int productId;
        string productName;
        double productPrice;

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double ProductPrice { get => productPrice; set => productPrice = value; }

        public Product()
        { }
        public Product(int productId, string productName,double productPrice)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductPrice = productPrice;
        }
    }
}
