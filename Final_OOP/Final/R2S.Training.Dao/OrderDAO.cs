using System;
using System.Collections.Generic;
using System.Text;
using NPL.SMS.R2S.Training.Entities;
using System.Data.SqlClient;
using NPL.SMS.R2S.Training.Connect;

namespace NPL.SMS.R2S.Training.Dao
{
    class OrderDAO : IOrderDAO
    {
        private const string INSERT = "Insert into Orders (order_id,order_date,customer_id,employee_id,total) values (@order_id,@order_date,@customer_id,@employee_id,@total)";
        private const string SELECT = "Select * from Orders where customer_id=@customer_id";
        private const string UPDATE = "Update Orders Set total=@total where order_id=@order_id";

        public List<Order> GetAllOrdersByCustomerId(int customerId)
        {
            using SqlConnection conn = Connection.GetSqlConnection();

            // open SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Connection.GetSqlCommand(SELECT, conn);

            //add a Parameter to Sqlcommand
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@customer_id",
                Value = customerId
            };
            cmd.Parameters.Add(param);

            using SqlDataReader dataReader = cmd.ExecuteReader();

            List<Order> list = new List<Order>();

            while (dataReader.Read())
            {
                //Create a new customer
                Order order = new Order
                {
                    OrderId = dataReader.GetInt32(0),
                    OrderDate = dataReader.GetDateTime(1),
                    CustomerId = dataReader.GetInt32(2),
                    EmployeeId = dataReader.GetInt32(3),
                    Total=dataReader.GetDouble(4),
                };
                //Add to list
                list.Add(order);
            }
            return list;
        }
        public bool AddOrder(Order order)
        {
            using SqlConnection conn = Connection.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Connection.GetSqlCommand(INSERT, conn);

            //add multiple parameters 
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@order_id",order.OrderId),
                new SqlParameter("@order_date",order.OrderDate),
                new SqlParameter("@customer_id",order.CustomerId),
                new SqlParameter("@employee_id",order.EmployeeId),
                new SqlParameter("@total",order.Total),
            });

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }
        public bool UpdateOrderTotal(int orderId)
        {
            using SqlConnection conn = Connection.GetSqlConnection();

            // open SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Connection.GetSqlCommand(UPDATE, conn);

            Console.Write("Enter a new Total: ");
            double orderTotal = Convert.ToDouble(Console.ReadLine());

            // Add multiple parameters to SQLCommand
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@order_id",orderId),
                new SqlParameter("@total",orderTotal),
            });

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }
    }
}
