using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
 * Project Name :       SOA A4
 * Project Author :     Wes Thompson, Jen Klimova, Niels Lindeboom and Alex Martin
 * Date :               November 10, 2016.
 * Description :        The purpose of this assignment is to give practice at creating and calling a RESTful web-service.
 *                      The service mimics an online shopping website.
 *                      This is Orders calss for transfering back and forth between the service and the client 
 */
namespace SOA_A4.Models
{
    public class Orders
    {
        public int orderID { get; set; }
        public int custID { get; set; }
        public string poNumber { get; set; }
        public DateTime orderDate { get; set; }
    }
}