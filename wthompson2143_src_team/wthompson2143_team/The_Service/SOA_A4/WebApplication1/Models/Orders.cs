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

namespace WebApplication1.Models
{
    /*
     * Class Name :     Orders
     * Description :    The orders class contains all of the variables that make up the
     *                  orders table.
     */

    public class Orders
    {
        public int orderID { get; set; }
        public int custID { get; set; }
        public string poNumber { get; set; }
        public DateTime orderDate { get; set; }
    }
}