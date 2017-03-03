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
     *  Class Name :    CustomerQuery
     *  Purpose :       This class includes the methods that perform the queries on the data base for the customer table
     */

    public class CustomerQuery
    {
        private SqlConnection conn;
        Logger logger = new Logger();

        /*
         *  Function Name :     CustomerQuery() - Constructor
         *  Parameters :        none
         *  Returns :           n/a
         *  Description :       This is the constructor to the CustomerQuery class. Its purpose is to
         *                      initialize the connection to the dbase.
         */

        public CustomerQuery()
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
         *  Function Name :     selectAllCustomer()
         *  Parameters :        none
         *  Returns :           ArrayList - An array list of the customers in the dbase
         *  Description :       This method queries the data base for all customers in the customer table
         *                      and returns an array list filled with all of the customers
         */

        public ArrayList selectAllCustomer()
        {
            
            logger.Log("GET | Customer table");

            ArrayList customers = new ArrayList();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Customer");
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;
            int numOfRows = adp.Fill(ds);

            for (int i = 0; i < numOfRows; i++ )
            {
                Customer c = new Customer();
                c.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["custID"]);
                c.fname = Convert.ToString(ds.Tables[0].Rows[i]["firstName"]);
                c.lname = Convert.ToString(ds.Tables[0].Rows[i]["lastName"]);
                c.phone = Convert.ToString(ds.Tables[0].Rows[i]["phoneNumber"]);
                customers.Add(c);
            }

            return customers;
        }

        /*
         *  Function Name :     selectCustomer()
         *  Parameters :        string id - the value the user wants to query the dbase for, string param - the table column
         *  Returns :           ArryaList - returns an array list of all the customers that match the query
         *  Description :       This function queries the dbase for a value the user enters
         */

        public Customer selectCustomer(string id, string param)
        {
            Customer c = new Customer();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Customer WHERE {0}='{1}'", param, id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;

            if (adp.Fill(ds) > 0)
            {
                c.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["custID"]);
                c.fname = Convert.ToString(ds.Tables[0].Rows[0]["firstName"]);
                c.lname = Convert.ToString(ds.Tables[0].Rows[0]["lastName"]);
                c.phone = Convert.ToString(ds.Tables[0].Rows[0]["phoneNumber"]);

                logger.Log("GET | Customer table | " + param);
            }
            else
            {
                c = null;
                logger.Log("GET | could not select customer");
            }

            conn.Close();
            return c;
        }

        /*
         *  Function Name :     insertCustomer()
         *  Parameters :        Customer newCustomer
         *  Returns :           bool
         *  Description :       takes a customer object and attempts to add the values into the dbase as  
         *                      a new customer row in the customer table
         */

        public bool insertCustomer(Customer newCustomer)
        {
            bool success = false;
            string sqlString = string.Format("INSERT INTO Customer VALUES ('{0}', '{1}', '{2}')", newCustomer.fname, newCustomer.lname, newCustomer.phone);
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Connection = conn;
            int numOfRowsAffected = cmd.ExecuteNonQuery();
            
            if( numOfRowsAffected > 0){
                success = true;

                logger.Log("POST | Cusotmer table");
            }
            else
            {
                logger.Log("POST | could not add customer");
            }

            conn.Close();
            return success;
        }

        /*
         *  Function Name :     deleteCustomer()
         *  Parameters :        string id, string param
         *  Returns :           bool
         *  Description :       attempts to perform a delete query on the customer table according to the column
         *                      and value the user specifies.
         */

        public bool deleteCustomer(string id, string param)
        {
            bool ret = true;
            Customer c = new Customer();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Customer WHERE {0} = '{1}'", param, id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;

            if (adp.Fill(ds) > 0)
            {
                //in order to delete a customer the customers orders need to be deleted first
                //in order to delete orders, the carts need to be deleted first
                DataSet ds2 = new DataSet();
                string sqlString2 = string.Format("SELECT * FROM [dbo].[Order] WHERE custID = {0}", ds.Tables[0].Rows[0]["custID"]);
                SqlCommand cmd2 = new SqlCommand(sqlString2);
                SqlDataAdapter adp2 = new SqlDataAdapter();
                cmd2.Connection = conn;
                adp2.SelectCommand = cmd2;
                int numOfRows = adp2.Fill(ds2);

                for (int i = 0; i < numOfRows; i++)
                {
                    c.ID = Convert.ToInt32(ds2.Tables[0].Rows[i]["orderID"]);

                    OrderQuery o = new OrderQuery();
                    o.DeleteOrder(Convert.ToString(c.ID), "orderID");
                }

                sqlString = string.Format("DELETE FROM Customer WHERE {0} = '{1}'", param, id);
                cmd = new SqlCommand(sqlString);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                logger.Log("DELETE | Customer table | " + param);
            }
            else
            {
                ret = false;
                logger.Log("DELETE | could not delete customer");
            }

            conn.Close();
            return ret;
        }

        /*
         *  Function Name :     updateCustomer()
         *  Parameters :        string id, Customer newCustomer, string param
         *  Returns :           bool
         *  Description :       updates the customer specified by the custID, the new customer values
         *                      are passed in through a customer object.
         */

        public bool updateCustomer(string id, Customer newCustomer, string param)
        {
            bool ret = true;
            Customer c = new Customer();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Customer WHERE {0} = '{1}'", param, id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;

            if (adp.Fill(ds) > 0)
            {
                sqlString = string.Format("UPDATE Customer SET firstName='{0}', lastName='{1}', phoneNumber='{2}' WHERE {3} = '{4}'", newCustomer.fname, newCustomer.lname, newCustomer.phone, param, id);
                cmd = new SqlCommand(sqlString);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                logger.Log("PUT | Customer table | " + param);
            }
            else
            {
                ret = false;
                logger.Log("PUT | could not update customer");
            }

            conn.Close();
            return ret;
        }


    }
}