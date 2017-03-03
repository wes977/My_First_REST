using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Project Name :       SOA A4
 * Project Author :     Wes Thompson, Jen Klimova, Niels Lindeboom and Alex Martin
 * Date :               November 10, 2016.
 * Description :        The purpose of this assignment is to give practice at creating and calling a RESTful web-service.
 *                      The service mimics an online shopping website.
 *                      This is the screen that you can input the information for what you selected to do and all that JAZZ 
 */
namespace SOA_A4
{
    public partial class Form2 : System.Web.UI.Page
    {
        Requester Temp;
        bool ERROR = false;
        Validation valid;
        Models.Logger logging = new Models.Logger();
        /*
* Method  Name :      PAge laod 
* Description :       When we load this page
*                      
*/
        protected void Page_Load(object sender, EventArgs e)
        {
            valid = new Validation();
            Temp = Form1.dataSender;
            goBackbtn.Click += new ImageClickEventHandler(goBack);
            submitbtn.Click += new ImageClickEventHandler(execute);

            if (Temp.requestType == "POST")
            {
                custIDtxt.ReadOnly = true;
                prodIDtxt.ReadOnly = true;
                orderIDtxt.ReadOnly = true;
            }
            if (Temp.requestType != "GET")
            {
                PObox.Visible = false;
            }
        }

        /*
* Method  Name :     Go Back 
* Description :      Go back to form 1
*                      
*/

        void goBack(Object sender, EventArgs e)
        {

            Response.Redirect("Form1.aspx");
        }

        /*
* Method  Name :      Execute 
* Description :      Doing all the valid ations and all that jazz and fun stuff 
*                      
*/
        void execute(Object sender, EventArgs e)
        {
            int counter = 0;

            Temp.dataList.Clear();
            var allTextBoxes = inputForm.Controls;
            foreach (Control tb in allTextBoxes)
            {
                if (tb is TextBox)
                {
                    Temp.AddData(((TextBox)tb).Text);

                }
            }
            ERROR = false;
            foreach (string info in Temp.dataList)
            {
                if (info != "")
                {
                    if (counter >= 0 && counter <= 3)
                    {
                        Temp.tableName = "Customer";
                        logging.Log("Doing stuff with Customer Table ");
                    }
                    if (counter >= 4 && counter <= 8)
                    {
                        Temp.tableName = "Product";
                        logging.Log("Doing stuff with Product Table ");
                    }
                    if (counter >= 9 && counter <= 12)
                    {
                        Temp.tableName = "Order";
                        logging.Log("Doing stuff with Order Table ");
                    }
                    if (counter >= 13 && counter <= 15)
                    {
                        Temp.tableName = "Cart";
                        logging.Log("Doing stuff with Cart Table ");
                    }
                }

                counter++;
            }
            if (Temp.dataList[16] == "on") // For purchase order and all that jazz YEE
            {
                if (Temp.dataList[0] != "")
                {
                    if (valid.IDValidation(Temp.dataList[0]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[0]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[1] != "")
                {
                    if (valid.nameValidation(Temp.dataList[1], "Customer first Name") != "")
                    {
                        errorlbl.Text = valid.nameValidation(Temp.dataList[1], "Customer first Name");
                        ERROR = true;
                    }
                }
                if (Temp.dataList[2] != "")
                {
                    if (valid.nameValidation(Temp.dataList[2], "Customer last Name") != "")
                    {
                        errorlbl.Text = valid.nameValidation(Temp.dataList[2], "Customer last Name");
                        ERROR = true;
                    }
                }
                if (Temp.dataList[9] != "")
                {
                    if (valid.IDValidation(Temp.dataList[9]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[9]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[10] != "")
                {
                    if (valid.IDValidation(Temp.dataList[10]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[10]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[12] != "")
                {
                    if (valid.dateValidation(Temp.dataList[12]) != "")
                    {
                        errorlbl.Text = valid.dateValidation(Temp.dataList[12]);
                        ERROR = true;
                    }
                }

                for (int i = 3; i < 9; i++) // Making sure certain fields are empty 
                {
                    if (Temp.dataList[i] != "")
                    {
                        errorlbl.Text = "Cannot create a a PO with extra data";
                        ERROR = true;
                    }
                }

                for (int j = 13; j < 16; j++) // Making sure certain fields are empty 
                {
                    if (Temp.dataList[j] != "")
                    {
                        errorlbl.Text = "Cannot create a a PO with extra data";
                        ERROR = true;
                    }
                }
            }
            else if (Temp.requestType == "GET")  // SEARCH INPut validation 
            {
                if (Temp.dataList[0] != "")
                {
                    if (valid.IDValidation(Temp.dataList[0]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[0]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[1] != "")
                {
                    if (valid.nameValidation(Temp.dataList[1], "Customer first Name") != "")
                    {
                        errorlbl.Text = valid.nameValidation(Temp.dataList[1], "Customer first Name");
                        ERROR = true;
                    }
                }
                if (Temp.dataList[2] != "")
                {
                    if (valid.nameValidation(Temp.dataList[2], "Customer last Name") != "")
                    {
                        errorlbl.Text = valid.nameValidation(Temp.dataList[2], "Customer last Name");
                        ERROR = true;
                    }
                }
                if (Temp.dataList[3] != "")
                {
                    if (valid.phoneValidation(Temp.dataList[3]) != "")
                    {
                        errorlbl.Text = valid.phoneValidation(Temp.dataList[3]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[4] != "")
                {
                    if (valid.IDValidation(Temp.dataList[4]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[4]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[5] != "")
                {
                    if (valid.nameValidation(Temp.dataList[5], "Product Name ") != "")
                    {
                        errorlbl.Text = valid.nameValidation(Temp.dataList[5], "Product Name");
                        ERROR = true;
                    }
                }
                if (Temp.dataList[6] != "")
                {
                    if (valid.priceValidation(Temp.dataList[6]) != "")
                    {
                        errorlbl.Text = valid.priceValidation(Temp.dataList[6]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[7] != "")
                {
                    if (valid.weightValidation(Temp.dataList[7]) != "")
                    {
                        errorlbl.Text = valid.weightValidation(Temp.dataList[7]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[9] != "")
                {
                    if (valid.IDValidation(Temp.dataList[9]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[9]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[10] != "")
                {
                    if (valid.IDValidation(Temp.dataList[10]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[10]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[12] != "")
                {
                    if (valid.dateValidation(Temp.dataList[12]) != "")
                    {
                        errorlbl.Text = valid.dateValidation(Temp.dataList[12]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[13] != "")
                {
                    if (valid.IDValidation(Temp.dataList[13]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[13]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[14] != "")
                {
                    if (valid.IDValidation(Temp.dataList[14]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[14]);
                        ERROR = true;
                    }
                }
                if (Temp.dataList[15] != "")
                {
                    if (valid.quantityValidation(Temp.dataList[15]) != "")
                    {
                        errorlbl.Text = valid.quantityValidation(Temp.dataList[15]);
                        ERROR = true;
                    }
                }
            }
            if (Temp.requestType == "POST")
            {

                if (Temp.tableName == "Customer")
                {
                    if (Temp.dataList[1] == "")
                    {
                        errorlbl.Text = "No Customer first name ";
                        ERROR = true;

                    }
                    else if (valid.nameValidation(Temp.dataList[1], "Customer first Name") != "")
                    {
                        errorlbl.Text = valid.nameValidation(Temp.dataList[1], "Customer first Name");
                        ERROR = true;
                    }
                    if (Temp.dataList[2] == "")
                    {
                        errorlbl.Text = "No Customer last name ";
                        ERROR = true;
                    }
                    else if (valid.nameValidation(Temp.dataList[2], "Customer last Name") != "")
                    {
                        errorlbl.Text = valid.nameValidation(Temp.dataList[2], "Customer last Name");
                        ERROR = true;
                    }
                    if (Temp.dataList[3] == "")
                    {
                        errorlbl.Text = "No Customer no phone number";
                        ERROR = true;
                    }
                    else if (valid.phoneValidation(Temp.dataList[3]) != "")
                    {
                        errorlbl.Text = valid.phoneValidation(Temp.dataList[3]);
                        ERROR = true;
                    }
                }
                else if (Temp.tableName == "Product")
                {
                    if (Temp.dataList[5] == "")
                    {
                        errorlbl.Text = "No product name ";
                        ERROR = true;

                    }
                    else if (valid.nameValidation(Temp.dataList[5], "product name") != "")
                    {
                        errorlbl.Text = valid.nameValidation(Temp.dataList[5], "product name");
                        ERROR = true;
                    }
                    if (Temp.dataList[6] == "")
                    {
                        errorlbl.Text = "No price ";
                        ERROR = true;
                    }
                    else if (valid.priceValidation(Temp.dataList[6]) != "")
                    {
                        errorlbl.Text = valid.priceValidation(Temp.dataList[6]);
                        ERROR = true;
                    }
                    if (Temp.dataList[7] == "")
                    {
                        errorlbl.Text = "No product weight";
                        ERROR = true;
                    }
                    else if (valid.weightValidation(Temp.dataList[7]) != "")
                    {
                        errorlbl.Text = valid.weightValidation(Temp.dataList[7]);
                        ERROR = true;
                    }
                }
                else if (Temp.tableName == "Order")
                {
                    if (Temp.dataList[10] == "")
                    {
                        errorlbl.Text = "No Customer ID ";
                        ERROR = true;

                    }
                    else if (valid.IDValidation(Temp.dataList[10]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[10]);
                        ERROR = true;
                    }


                    if (Temp.dataList[12] == "")
                    {
                        errorlbl.Text = "No order Date";
                        ERROR = true;
                    }
                    else if (valid.dateValidation(Temp.dataList[12]) != "")
                    {
                        errorlbl.Text = valid.dateValidation(Temp.dataList[12]);
                        ERROR = true;
                    }
                }
                else if (Temp.tableName == "Cart")
                {
                    if (Temp.dataList[13] == "")
                    {
                        errorlbl.Text = "No order ID ";
                        ERROR = true;

                    }
                    else if (valid.IDValidation(Temp.dataList[13]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[13]);
                        ERROR = true;
                    }
                    if (Temp.dataList[14] == "")
                    {
                        errorlbl.Text = "NO product ID ";
                        ERROR = true;
                    }
                    else if (valid.IDValidation(Temp.dataList[14]) != "")
                    {
                        errorlbl.Text = valid.IDValidation(Temp.dataList[14]);
                        ERROR = true;
                    }
                    if (Temp.dataList[15] == "")
                    {
                        errorlbl.Text = "No quantity given ";
                        ERROR = true;
                    }
                    else if (valid.quantityValidation(Temp.dataList[15]) != "")
                    {
                        errorlbl.Text = valid.quantityValidation(Temp.dataList[15]);
                        ERROR = true;
                    }
                }
            }
            else if (Temp.requestType == "PUT" || Temp.requestType == "DELETE")
            {

                if (Temp.dataList[1] != "")
                {
                    if (valid.nameValidation(Temp.dataList[1], "Customer first Name") != "")
                    {
                        errorlbl.Text = valid.nameValidation(Temp.dataList[1], "Customer first Name");
                        ERROR = true;
                    }
                }
                if (Temp.dataList[2] != "")
                {
                    if (valid.nameValidation(Temp.dataList[2], "Customer last Name") != "")
                    {
                        errorlbl.Text = valid.nameValidation(Temp.dataList[2], "Customer last Name");
                        ERROR = true;
                    }
                }
                if (Temp.dataList[3] != "")
                {
                    if (valid.phoneValidation(Temp.dataList[3]) != "")
                    {
                        errorlbl.Text = valid.phoneValidation(Temp.dataList[3]);
                        ERROR = true;
                    }
                }

                if (Temp.dataList[4] != "")    // For updating a product and all that jazz and deleting 
                {
                    if (Temp.dataList[5] != "")
                    {
                        if (valid.nameValidation(Temp.dataList[5], "product name") != "")
                        {
                            errorlbl.Text = valid.nameValidation(Temp.dataList[5], "product name");
                            ERROR = true;
                        }
                    }
                    if (Temp.dataList[6] != "")
                    {
                        if (valid.priceValidation(Temp.dataList[6]) != "")
                        {
                            errorlbl.Text = valid.priceValidation(Temp.dataList[6]);
                            ERROR = true;
                        }
                    }
                    if (Temp.dataList[7] != "")
                    {
                        if (valid.weightValidation(Temp.dataList[7]) != "")
                        {
                            errorlbl.Text = valid.weightValidation(Temp.dataList[7]);
                            ERROR = true;
                        }
                    }
                }
                else if (Temp.dataList[9] != "")// updating and deleting a order 
                {
                    if (Temp.dataList[10] != "")
                    {
                        if (valid.IDValidation(Temp.dataList[10]) != "")
                        {
                            errorlbl.Text = valid.IDValidation(Temp.dataList[10]);
                            ERROR = true;
                        }
                    }
                    if (Temp.dataList[12] != "")
                    {
                        if (valid.dateValidation(Temp.dataList[12]) != "")
                        {
                            errorlbl.Text = valid.dateValidation(Temp.dataList[12]);
                            ERROR = true;
                        }
                    }
                }
                else if (Temp.dataList[12] != "") // updating and delete a cart
                {
                    if (Temp.dataList[13] == "")
                    {
                        if (valid.IDValidation(Temp.dataList[13]) != "")
                        {
                            errorlbl.Text = valid.IDValidation(Temp.dataList[13]);
                            ERROR = true;
                        }
                    }
                    if (Temp.dataList[14] == "")
                    {
                        if (valid.IDValidation(Temp.dataList[14]) != "")
                        {
                            errorlbl.Text = valid.IDValidation(Temp.dataList[14]);
                            ERROR = true;
                        }
                    }
                    if (Temp.dataList[15] == "")
                    {
                        if (valid.quantityValidation(Temp.dataList[15]) != "")
                        {
                            errorlbl.Text = valid.quantityValidation(Temp.dataList[15]);
                            ERROR = true;
                        }
                    }
                }

            }
            else
            {

            }
            if (ERROR == false)
            {
                Response.Redirect("Form3.aspx");
            }

        }
    }
}