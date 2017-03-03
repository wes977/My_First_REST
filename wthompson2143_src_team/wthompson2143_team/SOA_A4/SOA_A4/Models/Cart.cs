using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Services;
using System.ServiceModel.Web;
/*
 * Project Name :       SOA A4
 * Project Author :     Wes Thompson, Jen Klimova, Niels Lindeboom and Alex Martin
 * Date :               November 10, 2016.
 * Description :        The purpose of this assignment is to give practice at creating and calling a RESTful web-service.
 *                      The service mimics an online shopping website.
 *                      This is cart calss for transfering back and forth between the service and the client 
 */
namespace SOA_A4.Models
{

    public class Cart
    {
        public int cartID { get; set; }
        public int orderID { get; set; }
        public int prodID { get; set; }
        public int quantity { get; set; }
    }
}