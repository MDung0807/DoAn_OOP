using System;
using System.Collections.Generic;
using System.Text;

namespace NPL.SMS.R2S.Training.Entities
{
    class Order
    {
        int orderId;
        DateTime orderDate;
        int customerId;
        int employeeId;
        double total;

        public int OrderId { get => orderId; set => orderId = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public double Total { get => total; set => total = value; }

        public Order()
        { }
        public Order(int orderId,DateTime orderDate, int customerId,int employeeId,double total)
        {
            this.OrderId = orderId;
            this.OrderDate = orderDate;
            this.CustomerId = customerId;
            this.EmployeeId = employeeId;
            this.Total = total;
        }
        public override string ToString()
        {
            return string.Format("OrderID: {0}, OrderDate: {1}, CustomerID: {2}, EmployeeID: {3}, Total: {4}",OrderId,OrderDate.ToString("dd/MM/yyyy"),CustomerId,EmployeeId,Total);
        }
    }
}
