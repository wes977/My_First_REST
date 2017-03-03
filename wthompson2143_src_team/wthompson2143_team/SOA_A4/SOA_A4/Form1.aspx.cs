using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOA_A4.Models;
/*
 * Project Name :       SOA A4
 * Project Author :     Wes Thompson, Jen Klimova, Niels Lindeboom and Alex Martin
 * Date :               November 10, 2016.
 * Description :        The purpose of this assignment is to give practice at creating and calling a RESTful web-service.
 *                      The service mimics an online shopping website.
 *                      This si the first form from here you can choose what you want to do insert ,search , update and delete 
 */
namespace SOA_A4
{
    public partial class Form1 : System.Web.UI.Page
    {
       
        public static Requester dataSender;
        Logger logging = new Logger();
        /*
* Method  Name :      PAge laod 
* Description :       When we load this page
*                      
*/
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch.Click += new ImageClickEventHandler(setGet);
            btnInsert.Click += new ImageClickEventHandler(setPost);
            btnUpdate.Click += new ImageClickEventHandler(setPut);
            btnDelete.Click += new ImageClickEventHandler(setDelete);
            dataSender = new Requester();
        }

        /*
* Method  Name :      set Get
* Description :      Set the request type to GEt 
*                      
*/
        void setGet(Object sender, EventArgs e)
        {
            logging.Log("Get Reuest selected");
            dataSender.requestType = "GET";
            Response.Redirect("Form2.aspx");
           
        }
        /*
* Method  Name :      set POST
* Description :      Set the request type to POST
*                      
*/
        void setPost(Object sender, EventArgs e)
        {
            logging.Log("Post Reuest selected");
            dataSender.requestType = "POST";
            Response.Redirect("Form2.aspx");
        }
        /*
* Method  Name :      set PUT
* Description :      Set the request type to PUT 
*                      
*/
        void setPut(Object sender, EventArgs e)
        {
            logging.Log("PUT Request selected");
            dataSender.requestType = "PUT";
            Response.Redirect("Form2.aspx");
        }
        /*
* Method  Name :      set DELETE
* Description :      Set the request type to DELETE 
*                      
*/
        void setDelete(Object sender, EventArgs e)
        {
            logging.Log("DELETE Request selected");
            dataSender.requestType = "DELETE";
            Response.Redirect("Form2.aspx");
        }



    }
}