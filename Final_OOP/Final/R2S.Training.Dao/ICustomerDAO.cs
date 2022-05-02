using System;
using System.Collections.Generic;
using System.Text;
using NPL.SMS.R2S.Training.Entities;

namespace NPL.SMS.R2S.Training.Dao
{
    interface ICustomerDAO
    {
        List<Customer> GetAllCustomer(); //1
        bool AddCustomer(Customer customer); //5
        bool DeleteCustomer(int customerId); //6
        bool UpdateCustomer(Customer customer);  //7
    }
}
