﻿/*
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
     * Class Name :     Products
     * Description :    The products class contains all of the variables that make up the
     *                  products table.
     */

    public class Products
    {
        public int prodID { get; set; }
        public string prodName { get; set; }
        public float price { get; set; }
        public float prodWeight { get; set; }
        public int inStock { get; set; }
    }
}