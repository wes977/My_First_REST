/*
 * Project Name :       SOA A4
 * Project Author :     Wes Thompson, Jen Klimova, Niels Lindeboom and Alex Martin
 * Date :               November 10, 2016.
 * Description :        The purpose of this assignment is to give practice at creating and calling a RESTful web-service.
 *                      The service mimics an online shopping website.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace WebApplication1
{
    /*
     *  Class Name :    OrderQuery()
     *  Purpose :       This class includes the methods that perform the queries on the data base for the cart table
     */

    public class OrderQuery
    {
        private SqlConnection conn;
        Logger logger = new Logger();

        /*
         *  Function Name :     OrderQuery() - Constructor
         *  Parameters :        none
         *  Returns :           n/a
         *  Description :       This is the constructor to the OrderQuery class. Its purpose is to
         *                      initialize the connection to the dbase.
         */

        public OrderQuery()
        {
            string connString;
            connString = @"Password=Conestoga1;Persist Security Info=True;User ID=sa;Initial Catalog=Shop;Data Source=2A314-E08\SQLDEVELOPER";
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
            }
            catch(SqlException ex)
            {
                logger.Log("Could not connect | " + ex.Message);
            }
        }

        /*
         *  Function Name :     SelectAllOrder()
         *  Parameters :        none
         *  Returns :           ArrayList
         *  Description :       returns all of the rows of the order table, stored in an arraylist
         */

        public ArrayList SelectAllOrder()
        {
            logger.Log("GET | Order table");

            ArrayList orders = new ArrayList();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM [dbo].[Order]");
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;
            int numOfRows = adp.Fill(ds);

            for (int i = 0; i < numOfRows; i++)
            {
                Orders o = new Orders();
                o.orderID = Convert.ToInt32(ds.Tables[0].Rows[i]["orderID"]);
                o.custID = Convert.ToInt32(ds.Tables[0].Rows[i]["custID"]);
                o.poNumber = Convert.ToString(ds.Tables[0].Rows[i]["poNumber"]);
                o.orderDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["orderDate"]);
                orders.Add(o);
            }

            return orders;
        }

        /*
         *  Function Name :     SelectOrder()
         *  Parameters :        string id, string param
         *  Returns :           ArrayList
         *  Description :       returns the rows that the query came back with based on the table columna and
         *                      value passed in by the user.
         */

        public ArrayList SelectOrder(string id, string param)
        {
            ArrayList order = new ArrayList();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM [dbo].[Order] WHERE {0} = '{1}'", param, id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;
            int numOfRows = adp.Fill(ds);

            if (numOfRows > 0)
            {
                for (int i = 0; i < numOfRows; i++)
                {
                    Orders o = new Orders();
                    o.orderID = Convert.ToInt32(ds.Tables[0].Rows[i]["orderID"]);
                    o.custID = Convert.ToInt32(ds.Tables[0].Rows[i]["custID"]);
                    o.poNumber = Convert.ToString(ds.Tables[0].Rows[i]["poNumber"]);
                    o.orderDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["orderDate"]);
                    order.Add(o);
                }

                logger.Log("GET | Order table | " + param);
            }
            else
            {
                order = null;
                logger.Log("GET | Order table | could not select cart");
            }

            conn.Close();
            return order;
        }

        /*  
         *  Function Name :     InsertOrder()
         *  Parameters :        Orders newOrder
         *  Returns :           bool
         *  Description :       inserts a new order into the orders table. The values are passed in through
         *                      the newOrder object.
         */     

        public bool InsertOrder(Orders newOrder)
        {
            bool success = false;
            string sqlString = string.Format("INSERT INTO [dbo].[Order] VALUES ({0}, '{1}', '{2}')", newOrder.custID, newOrder.poNumber, newOrder.orderDate);
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Connection = conn;
            int numOfRowsAffected = cmd.ExecuteNonQuery();

            if (numOfRowsAffected > 0)
            {
                success = true;
                logger.Log("POST | Order table | orderID " + newOrder.orderID + " added");
            }
            else
            {
                logger.Log("POST | Order table | could not add order");
            }

            conn.Close();
            return success;
        }

        /*
         *  Function Name :     DeleteOrder()
         *  Parameters :        string id, string param
         *  Returns :           bool
         *  Description :       Attempts to delete an order row from the table based on the column and value
         *                      the user passes in
         */

        public bool DeleteOrder(string id, string param)
        {
            bool ret = true;
            Orders o = new Orders();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM [dbo].[Order] WHERE {0} = '{1}'", param, id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;

            if (adp.Fill(ds) > 0)
            {
                CartQuery c = new CartQuery();
                c.DeleteCart(id, "orderID");

                sqlString = string.Format("DELETE FROM [dbo].[Order] WHERE {0} = '{1}'", param, id);
                cmd = new SqlCommand(sqlString);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                logger.Log("DELETE | Order table | deleted orderID " + id);
            }
            else
            {
                ret = false;
                logger.Log("DELETE | Order table | could not delete orderID " + id);
            }

            conn.Close();
            return ret;
        }

        /*
         *  Function Name :     UpdateOrder()
         *  Parameters :        int id, Orders newOrder
         *  Returns :           bool
         *  Description :       updates a order in the table based on the orderID, the new values are
         *                      passed in through the newOrder object
         */

        public bool UpdateOrder(int id, Orders newOrder)
        {
            bool ret = true;
            Orders o = new Orders();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM [dbo].[Order] WHERE orderID={0}", id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;
            string temp = "";
            int counter = 0;

            //The newOrders needs to be processed and the values that did not change need to be
            //saved as the values previously in the dbase.
            if (adp.Fill(ds) > 0)
            {
                if (newOrder.custID != 0)
                {
                    temp += string.Format("custID='{0}'", newOrder.custID);
                    counter++;
                }
                if (newOrder.poNumber != "")
                {
                    
                    if (counter == 1)
                    {
                        temp += ",";
                    }
                    temp += string.Format("poNumber='{0}'", newOrder.poNumber); 
                    counter++;
                }
                if (newOrder.orderDate != Convert.ToDateTime("1/1/0001 5:00:00 AM"))
                {
                    if (counter == 2 ||counter == 1 )
                    {
                        temp += ",";
                    }
                    temp += string.Format("orderDate='{0}'", newOrder.orderDate);
                }


                sqlString = string.Format("UPDATE [dbo].[Order] SET {0} WHERE orderID={1}", temp,newOrder.orderID);
                cmd = new SqlCommand(sqlString);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                logger.Log("PUT | Order table | updated orderID " + id);
            }
            else
            {
                ret = false;
                logger.Log("PUT | Order table | could not update orderID " + id);
            }

            conn.Close();
            return ret;
        }
    }
}