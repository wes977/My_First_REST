using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using SOA_A4.Models;
using System.Web.Script.Serialization;

using System.Collections;

/*
 * Project Name :       SOA A4
 * Project Author :     Wes Thompson, Jen Klimova, Niels Lindeboom and Alex Martin
 * Date :               November 10, 2016.
 * Description :        The purpose of this assignment is to give practice at creating and calling a RESTful web-service.
 *                      The service mimics an online shopping website.
 *                      This is where all the majic happens and all that its where we talk to the service from here 
 */
namespace SOA_A4
{
    public class Requester
    {
        public string requestType { get; set; }
        public List<string> dataList = new List<string>();
        public string tableName;
        public bool success = false;
        public string outPutData = "";
        public Customer tempCustClass;
        public Products tempProdClass;
        public Orders tempOrderClass;
        public Cart tempCartClass;
        public ArrayList tempAL;
        public List<Customer> ListAnswers;
        public List<Products> ListAnswers2;
        public List<Orders> ListAnswers3;
        public List<Cart> ListAnswers4;
        public bool poTime = false;
        public  string uri;
       
        /*
* Method  Name :       Add DAta
* Description :        VAdding data to the list of information 
*                      
*/
        public void AddData(string newData)
        {
            dataList.Add(newData);

        }
        /*
* Method  Name :       Send Data
* Description :        This is where all the majic happens and all that  
*                      
*/
        public bool sendData()
        {
            try
            {

                if (dataList[16] == "on")
                {
                    if (dataList[0] != "")
                    {
                        uri = "http://localhost/webApplication1/api/Customer/" + dataList[0];
                        getCustomers();
                        uri = "http://localhost/webApplication1/api/Order/customerID/" + tempCustClass.ID;
                        getOrders();
                    }
                    else if (dataList[1] != "")
                    {
                        uri = "http://localhost/webApplication1/api/Customer/firstName/" + dataList[1];
                        getCustomers();
                        uri = "http://localhost/webApplication1/api/Order/customerID/" + tempCustClass.ID;
                        getOrders();
                    }
                    else if (dataList[2] != "")
                    {
                        uri = "http://localhost/webApplication1/api/Customer/lastName/" + dataList[2];
                        getCustomers();
                        uri = "http://localhost/webApplication1/api/Order/customerID/" + tempCustClass.ID;
                        getOrders();
                    }
                    else
                    {
                        if (dataList[9] != "")
                        {
                            uri = "http://localhost/webApplication1/api/Order/" + dataList[9];
                            getOrders();
                            uri = "http://localhost/webApplication1/api/Customer/" + tempOrderClass.custID;
                            getCustomers();

                        }
                        else if (dataList[10] != "")
                        {
                            uri = "http://localhost/webApplication1/api/Order/customerID/" + dataList[10];
                            getOrders();
                            uri = "http://localhost/webApplication1/api/Customer/" + tempOrderClass.custID;
                            getCustomers();
                        }
                        else if (dataList[11] != "")
                        {
                            uri = "http://localhost/webApplication1/api/Order/poNumber/" + dataList[11];
                            getOrders();
                            uri = "http://localhost/webApplication1/api/Customer/" + tempOrderClass.custID;
                            getCustomers();
                        }
                        else if (dataList[12] != "")
                        {
                            uri = "http://localhost/webApplication1/api/Order/orderDate/" + dataList[12];
                            getOrders();
                            uri = "http://localhost/webApplication1/api/Customer/" + tempOrderClass.custID;
                            getCustomers();
                        }
                        else
                        {
                            throw new Exception("No information entered ");
                        }
                    }


                    

                    success = true;

                }
                else if (poTime == false)
                {


                    if (tableName == "Customer")
                    {

                        if (requestType == "POST")
                        {
                            uri = "http://localhost/webApplication1/api/Customer";
                        }
                        else
                        {
                            if (dataList[0] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Customer/" + dataList[0];
                            }
                            else if (dataList[1] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Customer/firstName/" + dataList[1];
                            }
                            else if (dataList[2] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Customer/lastName/" + dataList[2];
                            }
                            else if (dataList[3] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Customer/phoneNumber/" + dataList[3];
                            }

                        }
                    }
                    else if (tableName == "Product")
                    {
                        if (requestType == "POST")
                        {
                            uri = "http://localhost/webApplication1/api/Product";
                        }
                        else
                        {
                            if (dataList[4] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Product/" + dataList[4];
                            }
                            else if (dataList[5] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Product/productName/" + dataList[5];
                            }
                            else if (dataList[8] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Product/inStock/" + 0;
                            }
                        }

                    }
                    else if (tableName == "Cart")
                    {
                        if (requestType == "POST")
                        {
                            uri = "http://localhost/webApplication1/api/Cart";
                        }
                        else
                        {
                            if (dataList[13] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Cart/prodID/" + dataList[13];
                            }
                            else if (dataList[14] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Cart/orderID/" + dataList[14];
                            }
                            else if (dataList[15] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Cart/quantity/" + dataList[15];
                            }
                        }
                    }
                    else if (tableName == "Order")
                    {
                        if (requestType == "POST")
                        {
                            uri = "http://localhost/webApplication1/api/Order";
                        }
                        else
                        {
                            if (dataList[9] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Order/" + dataList[9]; // ORDER ID

                            }
                            else if (dataList[10] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Order/customerID/" + dataList[10]; // customer ID for order
                            }
                            else if (dataList[11] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Order/poNumber/" + dataList[11];  // Order poNumber
                            }
                            else if (dataList[12] != "")
                            {
                                uri = "http://localhost/webApplication1/api/Order/orderDate/" + dataList[12]; // order Date 
                            }
                        }
                    }
                    else
                    {

                    }

                    HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                    req.KeepAlive = false;
                    req.Method = requestType.ToUpper();
                    req.ContentType = "application/json; charset=utf-8";

                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();


                    if (("POST,PUT,DELETE").Split(',').Contains(requestType.ToUpper()))
                    {


                        string serOut = "";
                        if (tableName == "Customer")
                        {
                            Customer tempCust = new Customer();
                            if (dataList[0] != "")
                            {
                                tempCust.ID = Convert.ToInt32(dataList[0]);
                            }

                            tempCust.fname = dataList[1];
                            tempCust.lname = dataList[2];
                            tempCust.phone = dataList[3];
                            serOut = jsonSerializer.Serialize(tempCust);
                        }
                        else if (tableName == "Product")
                        {

                            Products tempProd = new Products();

                            if (dataList[4] != "")
                            {
                                tempProd.prodID = Convert.ToInt32(dataList[4]);
                            }

                            tempProd.prodName = dataList[5];
                            tempProd.price = float.Parse(dataList[6]);
                            tempProd.prodWeight = float.Parse(dataList[7]);
                            serOut = jsonSerializer.Serialize(tempProd);
                        }

                        else if (tableName == "Order")
                        {
                            Orders tempOrder = new Models.Orders();

                            if (dataList[9] != "")
                            {
                                tempOrder.orderID = Convert.ToInt32(dataList[9]);
                            }
                            if (dataList[10] != "")
                            {
                                tempOrder.custID = Convert.ToInt32(dataList[10]);
                            }

                            tempOrder.poNumber = dataList[11];
                            if (dataList[12] != "")
                            {
                                tempOrder.orderDate = Convert.ToDateTime(dataList[12]);
                            }
                            serOut = jsonSerializer.Serialize(tempOrder);
                        }
                        else if (tableName == "Cart")
                        {
                            Cart tempCart = new Models.Cart();

                            tempCart.orderID = Convert.ToInt32(dataList[14]);
                            tempCart.prodID = Convert.ToInt32(dataList[13]);
                            tempCart.quantity = Convert.ToInt32(dataList[15]);
                            serOut = jsonSerializer.Serialize(tempCart);
                        }
                        else
                        {

                        }

                        success = true;
                        outPutData = "All good in the hood!";

                        req.ContentLength = serOut.Length;
                        using (StreamWriter writer = new StreamWriter(req.GetRequestStream()))
                        {
                            writer.Write(serOut);
                        }
                    }

                    HttpWebResponse resp = req.GetResponse() as HttpWebResponse;


                    Encoding enc = System.Text.Encoding.GetEncoding(1252);
                    StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);

                    string Response = loResponseStream.ReadToEnd();

                    if (requestType == "GET")
                    {
                        if (tableName == "Customer")
                        {
                            tempCustClass = jsonSerializer.Deserialize<Customer>(Response);
                        }
                        else if (tableName == "Product")
                        {

                            if (dataList[4] != "")
                            {
                                tempProdClass = jsonSerializer.Deserialize<Products>(Response);
                            }
                            else
                            {

                                 ListAnswers2 = jsonSerializer.Deserialize<List<Products>>(Response);
                                tempProdClass = ListAnswers2[0];



                            }

                        }

                        else if (tableName == "Order")
                        {

                            if (requestType == "GET")
                            {
                                 ListAnswers3 = jsonSerializer.Deserialize<List<Orders>>(Response);
                                tempOrderClass = ListAnswers3[0];
                            }
                            else
                            {
                                tempOrderClass = jsonSerializer.Deserialize<Orders>(Response);
                            }



                        }
                        else if (tableName == "Cart")
                        {
                            if (requestType == "GET")
                            {
                               ListAnswers4 = jsonSerializer.Deserialize<List<Cart>>(Response);
                                tempCartClass = ListAnswers4[0];
                            }
                            else
                            {
                                tempCartClass = jsonSerializer.Deserialize<Cart>(Response);
                            }


                        }
                    }
                    success = true;
                    loResponseStream.Close();
                    resp.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                success = false;
                outPutData = "ERROR ERROR ERROR cound not work ERROR: " + ex;
            }
            return true;
        }
        /*
* Method  Name :       Get Orders 
* Description :        Gets the orders nd all that JAZZ  
*                      
*/
        public void getOrders()
        {
            HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = requestType.ToUpper();
            req.ContentType = "application/json; charset=utf-8";
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);
            string Response = loResponseStream.ReadToEnd();

           ListAnswers3 = jsonSerializer.Deserialize<List<Orders>>(Response);
            tempOrderClass = ListAnswers3[0];
        }
        /*
* Method  Name :       Get Customers  
* Description :        Gets the Customers and all that JAZZ  
*                      
*/
        public void getCustomers()
        {
            HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = requestType.ToUpper();
            req.ContentType = "application/json; charset=utf-8";
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);
            string Response = loResponseStream.ReadToEnd();
            tempCustClass = jsonSerializer.Deserialize<Customer>(Response);

        }
        /*
* Method  Name :       Get Products 
* Description :        Gets the Products nd all that JAZZ  
*                      
*/
        public void getProducts()
        {
            HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = requestType.ToUpper();
            req.ContentType = "application/json; charset=utf-8";
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);
            string Response = loResponseStream.ReadToEnd();
            ListAnswers2 = jsonSerializer.Deserialize<List<Products>>(Response);

        }
        /*
* Method  Name :       Get Cart 
* Description :        Gets the Cart nd all that JAZZ  
*                      
*/
        public void getCart()
        {
            HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = requestType.ToUpper();
            req.ContentType = "application/json; charset=utf-8";
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);
            string Response = loResponseStream.ReadToEnd();
            ListAnswers4 = jsonSerializer.Deserialize<List<Cart>>(Response);

        }
    }
}