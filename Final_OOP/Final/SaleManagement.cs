using System;
using System.Data.SqlClient;
using NPL.SMS.R2S.Training.Dao;
using NPL.SMS.R2S.Training.Entities;
using NPL.SMS.R2S.Training.Connect;

namespace NPL.SMS.R2S.Training.Main
{
    class SaleManagement
    {
        private static void CreateMenu()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Please select the admin area you acquire: ");
            Console.WriteLine("1. Display all Customers");
            Console.WriteLine("2. Search an Order by CustomerID");
            Console.WriteLine("3. Search a LineItem by OrderID");
            Console.WriteLine("4. Compute Order Total by OrderID");
            Console.WriteLine("5. Add a Customer");
            Console.WriteLine("6. Delete a Customer by CustomerID ");
            Console.WriteLine("7. Update a Customer");
            Console.WriteLine("8. Add an Order");
            Console.WriteLine("9. Add a LineItem");
            Console.WriteLine("10. Update Order Total");
            Console.WriteLine("11. Exit");

            Console.Write("Your choice: ");
        }
        static void Main(string[] args)
        {
            string option;
            do
            {
                CreateMenu();
                option = Console.ReadLine();

                switch (option)
                {
                    case "1": //Display all Customers                       
                        CustomerDAO customerDAO = new CustomerDAO();   //execute object                       

                        try
                        {
                            foreach (Customer t in customerDAO.GetAllCustomer())
                                Console.WriteLine(t);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2": //Search Orders by CustomerID
                        Order order = new Order();
                        OrderDAO orderDAO = new OrderDAO();

                        Console.Write("Enter CustomerID: ");
                        order.CustomerId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            foreach (Order t in orderDAO.GetAllOrdersByCustomerId(order.CustomerId))
                                Console.WriteLine(t);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3": //Search LineItems by OrderID
                        LineItem lineItem = new LineItem();
                        LineItemDAO lineItemDAO = new LineItemDAO(); //execute object

                        Console.Write("Enter OrderID: ");
                        lineItem.OrderId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            foreach (LineItem t in lineItemDAO.GetAllItemsByOrderId(lineItem.OrderId))
                                Console.WriteLine(t);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "4": // Compute Order Total By OrderID
                        lineItem = new LineItem();
                        lineItemDAO = new LineItemDAO();

                        Console.Write("Enter OrderID: ");
                        lineItem.OrderId = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            Console.WriteLine("Order Total:  {0}", lineItemDAO.ComputeOrderTotal(lineItem.OrderId));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "5": //Add a customer
                        Customer customer = new Customer();
                        customerDAO = new CustomerDAO();

                        Console.Write("Enter CustomerID: ");
                        customer.CustomerId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter CustomerName: ");
                        customer.CustomerName = Console.ReadLine();

                        try
                        {
                            if (customerDAO.AddCustomer(customer))
                                Console.WriteLine("Successfully!");
                            else Console.WriteLine("Failed!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "6": //Delete a Customer
                        customer = new Customer();
                        customerDAO = new CustomerDAO();

                        Console.Write("Enter CustomerID: ");
                        customer.CustomerId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            if (customerDAO.DeleteCustomer(customer.CustomerId))
                                Console.WriteLine("Successfully!");
                            else
                                Console.WriteLine("Failed!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "7": //Update a Customer
                        customer = new Customer();
                        customerDAO = new CustomerDAO();

                        Console.Write("Enter CustomerID: ");
                        customer.CustomerId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new name for Customer: ");
                        customer.CustomerName = Console.ReadLine();

                        try
                        {
                            if (customerDAO.UpdateCustomer(customer))
                                Console.WriteLine("Successfully!");
                            else
                                Console.WriteLine("Failed!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "8": //Add an Order
                        order = new Order();
                        orderDAO = new OrderDAO();

                        Console.Write("Enter OrderID: ");
                        order.OrderId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter OrderDate: ");
                        order.OrderDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter CustomerID: ");
                        order.CustomerId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter EmployeeID: ");
                        order.EmployeeId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Total: ");
                        order.Total = Convert.ToDouble(Console.ReadLine());

                        try
                        {
                            if (orderDAO.AddOrder(order))
                                Console.WriteLine("Successfully!");
                            else
                                Console.WriteLine("Failed!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case "9": //Add a LineItem
                        lineItem = new LineItem();
                        lineItemDAO = new LineItemDAO();

                        Console.Write("Enter OrderID: ");
                        lineItem.OrderId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter ProductID: ");
                        lineItem.ProductId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Quantity: ");
                        lineItem.Quantity = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Price: ");
                        lineItem.Price = Convert.ToDouble(Console.ReadLine());

                        try
                        {
                            if (lineItemDAO.AddLineItem(lineItem))
                                Console.WriteLine("Successfully!");
                            else
                                Console.WriteLine("Failed!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "10": // Update Order Total
                        order = new Order();
                        orderDAO = new OrderDAO();

                        Console.Write("Enter OrderID: ");
                        order.OrderId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            if (orderDAO.UpdateOrderTotal(order.OrderId))
                                Console.WriteLine("Successfully!");
                            else
                                Console.WriteLine("Failed!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        if (option != "11")
                            Console.WriteLine("Invalid!!");
                        break;
                }

            } while (option != "11");

        }
    }
}
