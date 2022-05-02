using System;
using System.Collections.Generic;
using System.Text;
using NPL.SMS.R2S.Training.Entities;

namespace NPL.SMS.R2S.Training.Dao
{
    interface IOrderDAO
    {
        List<Order> GetAllOrdersByCustomerId(int customerId); //2
        bool AddOrder(Order order); //8
        bool UpdateOrderTotal(int orderId);  //10
    }
}
