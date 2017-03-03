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
     *  Class Name :    ProductQuery
     *  Purpose :       This class includes the methods that perform the queries on the data base for the product table
     */

    public class ProductQuery
    {
        private SqlConnection conn;
        Logger logger = new Logger();

        /*
         *  Function Name :     ProductQuery() - Constructor
         *  Parameters :        none
         *  Returns :           n/a
         *  Description :       This is the constructor to the ProductQuery class. Its purpose is to
         *                      initialize the connection to the dbase.
         */

        public ProductQuery()
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
         *  Function Name :     SelectAllProduct()
         *  Parameters :        none
         *  Returns :           ArrayList - An array list of the products in the dbase
         *  Description :       This method queries the data base for all products in the product table
         *                      and returns an array list filled with all of the products
         */

        public ArrayList SelectAllProduct()
        {
            logger.Log("GET | Product table");

            ArrayList products = new ArrayList();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Product");
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;

            //the sqldataadapter.fill method returns an int representing the amount of rows it affected
            int numOfRows = adp.Fill(ds);

            //the numOfRows is used to loop through each product and add it to the array list
            for (int i = 0; i < numOfRows; i++)
            {
                Products p = new Products();
                p.prodID = Convert.ToInt32(ds.Tables[0].Rows[i]["prodID"]);
                p.prodName = Convert.ToString(ds.Tables[0].Rows[i]["prodName"]);
                p.price = Convert.ToSingle(ds.Tables[0].Rows[i]["price"]);
                p.prodWeight = Convert.ToSingle(ds.Tables[0].Rows[i]["prodWeight"]);
                p.inStock = Convert.ToInt32(ds.Tables[0].Rows[i]["inStock"]);
                products.Add(p);
            }

            return products;
        }

        /*
         *  Function Name :     SelectProduct()
         *  Parameters :        string id - the value the user wants to query the dbase for, string param - the table column
         *  Returns :           ArryaList - returns an array list of all the products that match the query
         *  Description :       This function queries the dbase for a value the user enters
         */

        public ArrayList SelectProduct(string id, string param)
        {
            ArrayList products = new ArrayList();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Product WHERE {0} = '{1}'", param, id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;
            int numOfRows = adp.Fill(ds);

            if (numOfRows > 0)
            {
                for (int i = 0; i < numOfRows; i++)
                {
                    Products p = new Products();
                    p.prodID = Convert.ToInt32(ds.Tables[0].Rows[0]["prodID"]);
                    p.prodName = Convert.ToString(ds.Tables[0].Rows[0]["prodName"]);
                    p.price = Convert.ToSingle(ds.Tables[0].Rows[0]["price"]);
                    p.prodWeight = Convert.ToSingle(ds.Tables[0].Rows[0]["prodWeight"]);
                    p.inStock = Convert.ToInt32(ds.Tables[0].Rows[0]["inStock"]);
                    products.Add(p);
                }


                logger.Log("GET | Product table | " + param);
            }
            else
            {
                products = null;
                logger.Log("GET | Product table | could not select product");
            }

            conn.Close();
            return products;
        }

        /*
         *  Function Name :     InsertProduct()
         *  Parameters :        Products newProduct
         *  Returns :           bool - true if the insert was successful, false if it failed
         *  Description :       This function takes a Products class and attempts to add the contents to the products table
         */

        public bool InsertProduct(Products newProduct)
        {
            logger.Log("GET | Product Table | ID");

            bool success = false;
            string sqlString = string.Format("INSERT INTO Product VALUES ('{0}', {1}, {2}, {3})", newProduct.prodName, newProduct.price, newProduct.prodWeight, newProduct.inStock);
            SqlCommand cmd = new SqlCommand(sqlString);
            cmd.Connection = conn;
            int numOfRowsAffected = cmd.ExecuteNonQuery();

            if (numOfRowsAffected > 0)
            {
                success = true;
                logger.Log("POST | Product table | prodID " + newProduct.prodID + " added");
            }
            else
            {
                logger.Log("POST | Product table | could not add product");
            }

            conn.Close();
            return success;
        }

        /*
         *  Function Name :     UpdateProduct()
         *  Parameters :        int id - update the product table row based on id of product, Products newProduct - class holding the new values
         *  Returns :           bool
         *  Description :       Updates a product in the dbase, based on the product id
         */

        public bool UpdateProduct(int id, Products newProduct)
        {
            bool ret = true;
            Products p = new Products();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Product WHERE prodID={0}", id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;

            if (adp.Fill(ds) > 0)
            {
                sqlString = string.Format("UPDATE Product SET prodName='{0}', price={1}, prodWeight={2}, inStock={3} WHERE prodID={4}", newProduct.prodName, newProduct.price, newProduct.prodWeight, newProduct.inStock, id);
                cmd = new SqlCommand(sqlString);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                logger.Log("PUT | Product table | updated prodID " + id);
            }
            else
            {
                ret = false;
                logger.Log("PUT | Product table | could not update prodID " + id);
            }

            conn.Close();
            return ret;
        }

        /*
         *  Function Name :     DeleteProduct()
         *  Parameters :        string id, string param
         *  Returns :           bool
         *  Description :       deletes product in the dbase based on the column of the product table and a value entered
         *                      by the user.
         */

        public bool DeleteProduct(string id, string param)
        {
            bool ret = true;
            Products p = new Products();
            DataSet ds = new DataSet();
            string sqlString = string.Format("SELECT * FROM Product WHERE {0} = '{1}'", param, id);
            SqlCommand cmd = new SqlCommand(sqlString);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = conn;
            adp.SelectCommand = cmd;

            if (adp.Fill(ds) > 0)
            {
                CartQuery c = new CartQuery();
                c.DeleteCart(id, "prodID");

                sqlString = string.Format("DELETE FROM Product WHERE {0} = '{1}'", param, id);
                cmd = new SqlCommand(sqlString);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                logger.Log("DELETE | Product table | deleted prodID " + id);
            }
            else
            {
                ret = false;
                logger.Log("DELETE | Cart table | could not delete prodID " + id);
            }

            conn.Close();
            return ret;
        }
    }
}