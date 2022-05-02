using System;
using System.Collections.Generic;
using System.Text;
using NPL.SMS.R2S.Training.Entities;
namespace NPL.SMS.R2S.Training.Dao
{
    interface ILineItemDAO
    {
        List<LineItem> GetAllItemsByOrderId(int orderId); //3 
        bool AddLineItem(LineItem item); //9
        double ComputeOrderTotal(int orderId); //4
    }
}
