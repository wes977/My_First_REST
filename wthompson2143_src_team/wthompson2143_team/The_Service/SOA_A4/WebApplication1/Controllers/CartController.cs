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
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    /*
     *  Class Name :    CartController
     *  Purpose :       This class defines all of the accepted uri's. Within the uri method
     *                  appropriate methods are called with the values from the user.
     */

    public class CartController : ApiController
    {
        // GET: api/Cart
        public ArrayList Get()
        {
            CartQuery cq = new CartQuery();
            return cq.SelectAllCart();
        }

        // GET: api/Cart/5
        public ArrayList Get(int id)
        {
            ArrayList cart = new ArrayList();

            CartQuery cq = new CartQuery();
            cart = cq.SelectCart(id, "cartID");

            return cart;
        }

        // GET: api/Cart/orderID/1
        [HttpGet]
        public ArrayList GetorderID(int orderID)
        {
            ArrayList cart = new ArrayList();

            CartQuery cq = new CartQuery();
            cart = cq.SelectCart(orderID, "orderID");

            return cart;
        }

        // GET: api/Cart/prodID/1
        [HttpGet]
        public ArrayList GetprodID(int prodID)
        {
            ArrayList cart = new ArrayList();

            CartQuery cq = new CartQuery();
            cart = cq.SelectCart(prodID, "prodID");

            return cart;
        }

        // GET: api/Cart/quantity/1
        [HttpGet]
        public ArrayList Getquantity(int quantity)
        {
            ArrayList cart = new ArrayList();

            CartQuery cq = new CartQuery();
            cart = cq.SelectCart(quantity, "quantity");

            return cart;
        }

        // POST: api/Cart
        public HttpResponseMessage Post([FromBody]Cart value)
        {
            HttpResponseMessage response;
            CartQuery cq = new CartQuery();
            bool success = cq.InsertCart(value);

            if (success)
            {
                response = Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return response;
        }

        // PUT: api/Cart/5
        public HttpResponseMessage Put(int id, [FromBody]Cart value)
        {
            CartQuery cq = new CartQuery();
            HttpResponseMessage response;
            bool ret = cq.UpdateCart(id, value);

            if (ret)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return response;
        }

        // DELETE: api/Cart/5
        public HttpResponseMessage Delete(int id)
        {
            CartQuery cq = new CartQuery();
            HttpResponseMessage response;
            bool ret = cq.DeleteCart(Convert.ToString(id), "cartID");

            if (ret)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return response;
        }

        // DELETE: api/Cart/orderID/5
        public HttpResponseMessage DeleteorderID(int orderID)
        {
            CartQuery cq = new CartQuery();
            HttpResponseMessage response;
            bool ret = cq.DeleteCart(Convert.ToString(orderID), "orderID");

            if (ret)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return response;
        }

        // DELETE: api/Cart/prodID/5
        public HttpResponseMessage DeleteprodID(int prodID)
        {
            CartQuery cq = new CartQuery();
            HttpResponseMessage response;
            bool ret = cq.DeleteCart(Convert.ToString(prodID), "prodID");

            if (ret)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return response;
        }

        // DELETE: api/Cart/quantity/5
        public HttpResponseMessage Deletequantity(int quantity)
        {
            CartQuery cq = new CartQuery();
            HttpResponseMessage response;
            bool ret = cq.DeleteCart(Convert.ToString(quantity), "quantity");

            if (ret)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return response;
        }
    }
}
