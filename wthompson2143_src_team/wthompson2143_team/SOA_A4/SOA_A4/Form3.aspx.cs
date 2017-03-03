using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using SOA_A4.Models;
/*
 * Project Name :       SOA A4
 * Project Author :     Wes Thompson, Jen Klimova, Niels Lindeboom and Alex Martin
 * Date :               November 10, 2016.
 * Description :        The purpose of this assignment is to give practice at creating and calling a RESTful web-service.
 *                      The service mimics an online shopping website.
 *                      This is the for for outputing all  the information that it gets from the service.
 */
namespace SOA_A4
{
    public partial class Form3 : System.Web.UI.Page
    {
        Requester Temp;
        float subTotal = 0;
        float totalWeight = 0;
        float numPieces = 0;
        Models.Logger logging = new Models.Logger();
        /*
* Method  Name :      PAge laod 
* Description :       When we load this page
*                      
*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Temp = Form1.dataSender;
            Temp.sendData();
            if (Temp.success == true)
            {
                if (Temp.dataList[16] == "on")
                {
                    logging.Log("Out put a PO ");
                    TextArea1.Text = "Customer ID: \t" + Temp.tempCustClass.ID +
                 "\r\nFirst Name: \t" + Temp.tempCustClass.fname +
                 "\r\nLast Name: \t" + Temp.tempCustClass.lname +
                 "\r\nPhone Number: \t" + Temp.tempCustClass.phone;
                    foreach (Orders o in Temp.ListAnswers3)
                    {
                        TextArea1.Text += "\r\n" +
"\r\nOrder date: \t" + o.orderDate +
"\r\nPoNumber: \t" + o.poNumber;
                        TextArea1.Text += "\r\n";
                        TextArea1.Text += "\t\tITEMS \r\n";
                        Temp.uri = "http://localhost/webApplication1/api/Cart/orderID/" + o.orderID;
                        Temp.getCart();
                        foreach (Cart c in Temp.ListAnswers4)
                        {
                            Temp.uri = "http://localhost/webApplication1/api/Product/" + c.prodID;
                            Temp.getProducts();
                            foreach (Products p in Temp.ListAnswers2)
                            {
                                TextArea1.Text += "\r\nProduct ID : \t" + p.prodID +
"\r\nProduct Name: \t" + p.prodName +
"\r\nQuantity : \t" + c.quantity +
"\r\nPrice: \t\t" + p.price +
"\r\nProduct weight: " + p.prodWeight;
                                subTotal += p.price * c.quantity ;
                                totalWeight += p.prodWeight * c.quantity;
                                numPieces += c.quantity;
                            }


                        }
                        TextArea1.Text += "\r\nSubtotal : \t" + subTotal +
"\r\ntotal weight: \t" + totalWeight +
"\r\nNum of pieces : " + numPieces +
"\r\nTax: \t\t" + subTotal * (0.13) +
"\r\nTotal:\t\t " + (subTotal * (0.13) + subTotal);

                        TextArea1.Text += "\r\n\t\t END OF THIS ORDER ";
                        subTotal = 0;
                        totalWeight = 0;
                        numPieces = 0;

                    }

                    Temp.tempOrderClass = new Models.Orders();



                    Temp.tempCustClass = new Models.Customer();
                }
                else if (Temp.requestType != "GET")
                {
                    logging.Log("NON get reuest  ");
                    TextArea1.Text = Temp.outPutData;
                }
                else if (Temp.tempAL != null)
                {
                    TextArea1.Text = Temp.tempAL.ToString();
                }
                else
                {
                    if (Temp.tableName == "Customer")
                    {
                        logging.Log("Getting a customer");
                        if (Temp.tempCustClass != null)
                        {
                            TextArea1.Text = "Customer ID: \t" + Temp.tempCustClass.ID +
                                             "\r\nFirst Name: \t" + Temp.tempCustClass.fname +
                                             "\r\nLast Name: \t" + Temp.tempCustClass.lname +
                                             "\r\nPhone Number: \t" + Temp.tempCustClass.phone;
                            Temp.tempCustClass = new Models.Customer();
                        }
                        else
                        {
                            TextArea1.Text = "Nothing found with that information";
                        }
                    }
                    else if (Temp.tableName == "Product")
                    {
                        if (Temp.tempProdClass != null)
                        {
                            logging.Log("Getting a Product ");
                            TextArea1.Text = "Product ID: \t\t" + Temp.tempProdClass.prodID +
                     "\r\nProduct Name: \t\t" + Temp.tempProdClass.prodName +
                     "\r\nProduct Price: \t\t" + Temp.tempProdClass.price +
                     "\r\nProduct Weight: \t" + Temp.tempProdClass.prodWeight;
                            if (Temp.tempProdClass.inStock >= 1)
                            {
                                TextArea1.Text += "\r\nis Product instock: \tYES";

                            }
                            else
                            {
                                TextArea1.Text += "\r\nis Product instock: \tNOPE";

                            }

                            Temp.tempProdClass = new Models.Products();
                        }
                        else
                        {
                            TextArea1.Text = "Nothing found with that information";
                        }
                    }

                    else if (Temp.tableName == "Order")
                    {
                        if (Temp.tempOrderClass != null)
                        {
                            logging.Log("Getting a Order");
                            TextArea1.Text = "Orderr ID: \t" + Temp.tempOrderClass.orderID +
                 "\r\nCustomer ID: \t" + Temp.tempOrderClass.custID +
                 "\r\nOrder date: \t" + Temp.tempOrderClass.orderDate +
                 "\r\nPoNumber: \t" + Temp.tempOrderClass.poNumber;
                            Temp.tempOrderClass = new Models.Orders();
                        }
                        else
                        {
                            TextArea1.Text = "Nothing found with that information";
                        }

                    }
                    else if (Temp.tableName == "Cart")
                    {
                        if (Temp.tempCartClass != null)
                        {
                            logging.Log("Getting a Cart");
                            TextArea1.Text = "Cart ID: \t" + Temp.tempCartClass.cartID +
             "\r\nOrder ID: \t" + Temp.tempCartClass.orderID +
             "\r\nProduct ID: \t" + Temp.tempCartClass.prodID +
             "\r\nQuantity: \t" + Temp.tempCartClass.quantity;
                            Temp.tempCartClass = new Models.Cart();
                        }
                        else
                        {
                            TextArea1.Text = "Nothing found with that information";
                        }
                    }
                }
            }
            else
            {
                TextArea1.Text = Temp.outPutData;
                logging.Log("ERROR on gettign info ");
            }

        }
    }
}