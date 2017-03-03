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
     *  Class Name :    ProductController
     *  Purpose :       This class defines all of the accepted uri's. Within the uri method
     *                  appropriate methods are called with the values from the user.
     */

    public class ProductController : ApiController
    {
        // GET: api/Product
        public ArrayList Get()
        {
            ProductQuery pq = new ProductQuery();
            return pq.SelectAllProduct();
        }

        // GET: api/Product/5
        public ArrayList Get(int id)
        {
            ArrayList product = new ArrayList();

            ProductQuery pq = new ProductQuery();
            product = pq.SelectProduct(Convert.ToString(id), "prodID");

            return product;
        }

        // GET: api/Product/productName/Grapple Grommet
        [HttpGet]
        public ArrayList GetprodName(string prodName)
        {
            ArrayList product = new ArrayList();

            ProductQuery pq = new ProductQuery();
            product = pq.SelectProduct(prodName, "prodName");

            return product;
        }

        // GET: api/Product/inStock/1
        [HttpGet]
        public ArrayList GetinStock(string inStock)
        {
            ArrayList product = new ArrayList();

            ProductQuery pq = new ProductQuery();
            product = pq.SelectProduct(inStock, "inStock");

            return product;
        }

        // POST: api/Product
        public HttpResponseMessage Post([FromBody]Products value)
        {
            HttpResponseMessage response;
            ProductQuery pq = new ProductQuery();
            bool success = pq.InsertProduct(value);

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

        // PUT: api/Product/5
        public HttpResponseMessage Put(int id, [FromBody]Products value)
        {
            ProductQuery pq = new ProductQuery();
            HttpResponseMessage response;
            bool ret = pq.UpdateProduct(id, value);

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

        // DELETE: api/Product/5
        public HttpResponseMessage Delete(int id)
        {
            ProductQuery pq = new ProductQuery();
            HttpResponseMessage response;
            bool ret = pq.DeleteProduct(Convert.ToString(id), "prodID");

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

        // DELETE: api/Product/ProductName/Grapple Grommet
        [HttpDelete]
        public HttpResponseMessage DeleteprodName(string prodName)
        {
            ProductQuery pq = new ProductQuery();
            HttpResponseMessage response;
            bool ret = pq.DeleteProduct(prodName, "prodName");

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

        [HttpDelete]
        public HttpResponseMessage DeleteinStock(string inStock)
        {
            ProductQuery pq = new ProductQuery();
            HttpResponseMessage response;
            bool ret = pq.DeleteProduct(inStock, "inStock");

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
