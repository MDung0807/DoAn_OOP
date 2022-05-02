using System;
using System.Collections.Generic;
using System.Text;
using NPL.SMS.R2S.Training.Entities;
using System.Data;
using System.Data.SqlClient;
using NPL.SMS.R2S.Training.Connect;
namespace NPL.SMS.R2S.Training.Dao
{
    class CustomerDAO : ICustomerDAO
    {
        //SQL Command
        private const string SELECT = "Select * From Customer";
        private const string INSERT = "sp_insert_customer";
        private const string DELETE = "sp_delete_customer";
        private const string UPDATE = "sp_update_customer";

        public bool AddCustomer(Customer customer)
        {
            using SqlConnection conn = Connection.GetSqlConnection();

            // open SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Connection.GetSqlCommand(INSERT, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //add parameters (customerName,customerId) to SqlCommand
            cmd.Parameters.AddRange(new[]
            {               
                new SqlParameter("@id", customer.CustomerId),
                new SqlParameter("@name", customer.CustomerName),
            });

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }

        public bool DeleteCustomer(int customerId)
        {
            using SqlConnection conn = Connection.GetSqlConnection();

            // open SqlConnection
            conn.Open();

            //Use procedure
            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Connection.GetSqlCommand(DELETE, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //add a parameter (customerId)
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@id",
                Value = customerId
            };
            cmd.Parameters.Add(param);

            if (cmd.ExecuteNonQuery() > 0)
                    return true;
                return false;
        }

        public List<Customer> GetAllCustomer()
        {
            using SqlConnection conn = Connection.GetSqlConnection();

            // open SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Connection.GetSqlCommand(SELECT, conn);
            using SqlDataReader dataReader = cmd.ExecuteReader();

            List<Customer> list = new List<Customer>();

            while(dataReader.Read())
            {
                //Create a new customer
                Customer customer = new Customer
                {
                    CustomerId = dataReader.GetInt32(0), //customer_id
                    CustomerName = dataReader.GetString(1),
                };
                //Add to list
                list.Add(customer);
            }
            return list;
        }

        public bool UpdateCustomer(Customer customer)
        {
            using SqlConnection conn = Connection.GetSqlConnection();

            // open SqlConnection
            conn.Open();

            //Use procedure store
            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Connection.GetSqlCommand(UPDATE, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Add parameters
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@id", customer.CustomerId),
                new SqlParameter("@name", customer.CustomerName),
            });

             if ((int) cmd.ExecuteNonQuery() > 0)
                    return true;
                else return false;
        }
    }
}
