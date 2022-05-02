﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NPL.SMS.R2S.Training.Entities
{
    class Customer
    {
        int customerId;
        string customerName;

        public int CustomerId { get => customerId; set => customerId = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        
        public Customer()
        { }
        public Customer(int customerId,string customerName)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
        }
        public override string ToString()
        {
            return string.Format("CustomerId: {0}, CustomerName: {1}", CustomerId, CustomerName);
        }
    }
}
