using System;
using System.Collections.Generic;
using System.Text;
using NPL.SMS.R2S.Training.Entities;
using System.Data.SqlClient;
using NPL.SMS.R2S.Training.Connect;

namespace NPL.SMS.R2S.Training.Dao
{
    class LineItemDAO : ILineItemDAO
    {
        //Sql Command
        private const string SELECT = "Select * from LineItem Where order_id=@order_id";
        private const string INSERT = "Insert into LineItem (order_id,product_id,quantity,price) values (@order_id,@product_id,@quantity,@price)";
        private const string COUNT = "Select dbo.fn_count_total (@id)";


        public List<LineItem> GetAllItemsByOrderId(int orderId)
        {
            using SqlConnection conn = Connection.GetSqlConnection();

            // open SqlConnection
            conn.Open();
           
            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Connection.GetSqlCommand(SELECT, conn);
            
            //add a parameter
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@id",
                Value = orderId,
            };
            cmd.Parameters.Add(param);

            using SqlDataReader dataReader = cmd.ExecuteReader();
            List<LineItem> list = new List<LineItem>();
            while (dataReader.Read())
            {
                // Create a new line item
                LineItem lineItem = new LineItem
                {
                    OrderId= dataReader.GetInt32(0),
                    ProductId = dataReader.GetInt32(1),
                    Quantity=dataReader.GetInt32(2),
                    Price=dataReader.GetDouble(3)
                };

                // Add into list
                list.Add(lineItem);
            }
            return list;
        }

        public bool AddLineItem(LineItem item)
        {
            using SqlConnection conn = Connection.GetSqlConnection();

            // open SqlConnection
            conn.Open();

            // The following code uses a SqlCommand based on the SqlConnection
            using SqlCommand cmd = Connection.GetSqlCommand(INSERT, conn);

            //add multiple parameters 
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@order_id", item.OrderId),
                new SqlParameter("@product_id", item.ProductId),
                new SqlParameter("@quantity",item.Quantity),
                new SqlParameter("@price",item.Price),
            });

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }

        public double ComputeOrderTotal(int orderId)
        {
            using SqlConnection conn = Connection.GetSqlConnection();

            // open SqlConnection
            conn.Open();

            // Create a sql command
            using SqlCommand cmd = Connection.GetSqlCommand(COUNT, conn);

            //add a Parameter to Sqlcommand
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@id",
                Value = orderId,
            };
            cmd.Parameters.Add(param);
            double total = Convert.ToDouble(cmd.ExecuteScalar());

            return total;
        }
    }
}
