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
     *  Class Name :    OrderController
     *  Purpose :       This class defines all of the accepted uri's. Within the uri method
     *                  appropriate methods are called with the values from the user.
     */

    public class OrderController : ApiController
    {
        // GET: api/Order
        public ArrayList Get()
        {
            OrderQuery oq = new OrderQuery();
            return oq.SelectAllOrder();
        }

        // GET: api/Order/5
        public ArrayList Get(int id)
        {
            ArrayList order = new ArrayList();

            OrderQuery oq = new OrderQuery();
            order = oq.SelectOrder(Convert.ToString(id), "orderID");

            return order;
        }

        // GET: api/Order/customerID/2
        [HttpGet]
        public ArrayList GetcustID(int custID)
        {
            ArrayList order = new ArrayList();

            OrderQuery oq = new OrderQuery();
            order = oq.SelectOrder(Convert.ToString(custID), "custID");

            return order;
        }

        // GET: api/Order/poNumber/GRAP-09-2011-001
        [HttpGet]
        public ArrayList GetpoNumber(string poNumber)
        {
            ArrayList order = new ArrayList();

            OrderQuery oq = new OrderQuery();
            order = oq.SelectOrder(poNumber, "poNumber");

            return order;
        }

        // GET: api/Order/orderDate/2011-09-15
        [HttpGet]
        public ArrayList GetorderDate(string orderDate)
        {
            ArrayList order = new ArrayList();

            OrderQuery oq = new OrderQuery();
            order = oq.SelectOrder(orderDate, "orderDate");

            return order;
        }

        // POST: api/Order
        public HttpResponseMessage Post([FromBody]Orders value)
        {
            HttpResponseMessage response;
            OrderQuery oq = new OrderQuery();
            bool success = oq.InsertOrder(value);

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

        // PUT: api/Order/5
        public HttpResponseMessage Put(int id, [FromBody]Orders value)
        {
            OrderQuery oq = new OrderQuery();
            HttpResponseMessage response;
            bool ret = oq.UpdateOrder(id, value);

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

        // DELETE: api/Order/5
        public HttpResponseMessage Delete(int id)
        {
            OrderQuery oq = new OrderQuery();
            HttpResponseMessage response;
            bool ret = oq.DeleteOrder(Convert.ToString(id), "orderID");

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

        // DELETE: api/Order/customerID/5
        [HttpDelete]
        public HttpResponseMessage DeletecustID(int custID)
        {
            OrderQuery oq = new OrderQuery();
            HttpResponseMessage response;
            bool ret = oq.DeleteOrder(Convert.ToString(custID), "custID");

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

        // DELETE: api/Order/poNumber/GRAP-09-2011-001
        [HttpDelete]
        public HttpResponseMessage DeletepoNumber(string poNumber)
        {
            OrderQuery oq = new OrderQuery();
            HttpResponseMessage response;
            bool ret = oq.DeleteOrder(poNumber, "poNumber");

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

        // DELETE: api/Order/orderDate/2011-09-15
        [HttpDelete]
        public HttpResponseMessage DeleteorderDate(string orderDate)
        {
            OrderQuery oq = new OrderQuery();
            HttpResponseMessage response;
            bool ret = oq.DeleteOrder(orderDate, "orderDate");

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
