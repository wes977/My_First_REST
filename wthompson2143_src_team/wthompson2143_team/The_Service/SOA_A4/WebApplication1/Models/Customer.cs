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
     * Class Name :     Customer
     * Description :    The customer class contains all of the variables that make up the
     *                  customer table.
     */

    public class Customer
    {
        public int ID { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string phone { get; set; }
    }
}