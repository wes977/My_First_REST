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
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using WebApplication1.Models;

namespace WebApplication1
{

    /*
     *  Class Name :    CartQuery()
     *  Purpose :       This class includes the methods that perform the queries on the data base for the cart table
     */

    public class CartQuery
    {
        private SqlConnection conn;
        Logger logger = new Logger();


        /*
         *  Function Name :     CartQuery() - Constructor
         *  Parameters :        none
         *  Returns :           n/a
         *  Description :       This is the constructor to the CartQuery class. Its purpose is to
         *                      initialize the connection to the dbase.
         */

        public CartQuery()
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
         *  Function Name :     SelectAllCart()
         *  Parameters :        none
         *  Returns :           ArrayList
         *  Description :       Queries the cart table in the dbase and returns all of the rows in the cart table
         *                      to rows are stored in an ArrayList
         */

        public ArrayList SelectAllCart()
        {
            logger.Log("GET | Cart table");

            ArrayList cart = new ArrayList();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Cart");
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;
            int numOfRows = adp.Fill(ds);

            for (int i = 0; i < numOfRows; i++)
            {
                Cart c = new Cart();
                c.cartID = Convert.ToInt32(ds.Tables[0].Rows[i]["cartID"]);
                c.orderID = Convert.ToInt32(ds.Tables[0].Rows[i]["orderID"]);
                c.prodID = Convert.ToInt32(ds.Tables[0].Rows[i]["prodID"]);
                c.quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["quantity"]);
                cart.Add(c);
            }

            return cart;
        }

        /*
         *  Function Name :     SelectCart()
         *  Parameters :        int id, string param
         *  Returns :           ArrayList
         *  Description :       Does the same thing as SelectAllCart except the user is able to specify
         *                      the cart by a column value
         */

        public ArrayList SelectCart(int id, string param)
        {
            ArrayList cart = new ArrayList();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Cart WHERE {0}='{1}'", param, id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;
            int numOfRows = adp.Fill(ds);

            if (numOfRows > 0)
            {
                for (int i = 0; i < numOfRows; i++)
                {
                    Cart c = new Cart();
                    c.cartID = Convert.ToInt32(ds.Tables[0].Rows[i]["cartID"]);
                    c.orderID = Convert.ToInt32(ds.Tables[0].Rows[i]["orderID"]);
                    c.prodID = Convert.ToInt32(ds.Tables[0].Rows[i]["prodID"]);
                    c.quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["quantity"]);
                    cart.Add(c);
                }
                
                logger.Log("GET | Cart table | " + param);

            }
            else
            {
                cart = null;
                logger.Log("GET | could not select cart");
            }

            conn.Close();
            return cart;
        }

        /*
         *  Function Name :     InsertCart()
         *  Parameters :        Cart newCart
         *  Returns :           bool
         *  Description :       Attempts to add a new cart row to the cart table. The values are passed using a 
         *                      cart object.
         */

        public bool InsertCart(Cart newCart)
        {
            bool success = false;
            string sqlString = string.Format("INSERT INTO Cart VALUES ('{0}', '{1}', '{2}')", newCart.orderID, newCart.prodID, newCart.quantity);
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Connection = conn;
            int numOfRowsAffected = cmd.ExecuteNonQuery();

            if (numOfRowsAffected > 0)
            {
                success = true;
                logger.Log("POST | Cart table");
            }
            else
            {
                logger.Log("POST | could not add cart");
            }

            conn.Close();
            return success;
        }

        /*
         *  Function Name :     UpdateCart()
         *  Parameters :        int id, Cart newCart
         *  Returns :           bool
         *  Description :       Attempts to update a row in the cart table with the new values passed in through the
         *                      newCart object.
         */

        public bool UpdateCart(int id, Cart newCart)
        {
            bool ret = true;
            Cart c = new Cart();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Cart WHERE cartID={0}", id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;

            if (adp.Fill(ds) > 0)
            {
                sqlString = string.Format("UPDATE Cart SET orderID='{0}', prodID='{1}', quantity='{2}' WHERE cartID={3}", newCart.orderID, newCart.prodID, newCart.quantity, id);
                cmd = new SqlCommand(sqlString);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                logger.Log("PUT | Cart table | updated cartID " + id);
            }
            else
            {
                ret = false;
                logger.Log("PUT | Cart table | could not update cartID " + id);
            }

            conn.Close();
            return ret;
        }

        /*
         *  Function Name :     DeleteCart()
         *  Parameters :        string id, string param
         *  Returns :           bool
         *  Description :       Attempts to delete the row in the cart table based on the
         *                      column and value the user passes in.
         */

        public bool DeleteCart(string id, string param)
        {
            bool ret = true;
            Cart c = new Cart();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Cart WHERE {0} = '{1}'", param, id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;

            if (adp.Fill(ds) > 0)
            {
                sqlString = string.Format("DELETE FROM Cart WHERE {0} = '{1}'", param, id);
                cmd = new SqlCommand(sqlString);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                logger.Log("DELETE | Cart table | deleted cartID " + id);
            }
            else
            {
                ret = false;
                logger.Log("DELETE | Cart table | could not delete cartID " + id);
            }

            conn.Close();
            return ret;
        }
    }
}