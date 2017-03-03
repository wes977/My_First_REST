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
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace WebApplication1.Controllers
{
    /*
     *  Class Name :    CustomerController
     *  Purpose :       This class defines all of the accepted uri's. Within the uri method
     *                  appropriate methods are called with the values from the user.
     */

    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public ArrayList Get()
        {
            CustomerQuery cq = new CustomerQuery();
            return cq.selectAllCustomer();
        }

        // GET: api/Customer/5
        public Customer Get(int id)
        {
            Customer customer = new Customer();

            CustomerQuery cq = new CustomerQuery();
            customer = cq.selectCustomer(Convert.ToString(id), "custID");

            return customer;
        }

        // GET: api/Customer/firstName/Joe
        [HttpGet]
        public Customer Getfname(string fname)
        {
            Customer customer = new Customer();

            CustomerQuery cq = new CustomerQuery();
            customer = cq.selectCustomer(fname, "firstName");

            return customer;
        }

        // GET: api/Customer/lastName/Bzolay
        [HttpGet]
        public Customer Getlname(string lname)
        {
            Customer customer = new Customer();

            CustomerQuery cq = new CustomerQuery();
            customer = cq.selectCustomer(lname, "lastName");

            return customer;
        }

        // GET: api/Customer/phoneNumber/555-555-1212
        [HttpGet]
        public Customer Getphone(string phone)
        {
            Customer customer = new Customer();

            CustomerQuery cq = new CustomerQuery();
            customer = cq.selectCustomer(phone, "phoneNumber");

            return customer;
        }

        // POST: api/Customer
        public HttpResponseMessage Post([FromBody]Customer value)
        {
            HttpResponseMessage response;
            CustomerQuery cq = new CustomerQuery();
            bool success = cq.insertCustomer(value);

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

        // PUT: api/Customer/5
        public HttpResponseMessage Put(int id, [FromBody]Customer value)
        {
            CustomerQuery cq = new CustomerQuery();
            HttpResponseMessage response;
            bool ret = cq.updateCustomer(Convert.ToString(id), value, "custID");

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

        // PUT: api/Customer/firstName/Joe
        [HttpPut]
        public HttpResponseMessage Putfname(string fname, [FromBody]Customer value)
        {
            CustomerQuery cq = new CustomerQuery();
            HttpResponseMessage response;
            bool ret = cq.updateCustomer(fname, value, "firstName");

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

        // PUT: api/Customer/lastName/Bzolay
        [HttpPut]
        public HttpResponseMessage Putlname(string lname, [FromBody]Customer value)
        {
            CustomerQuery cq = new CustomerQuery();
            HttpResponseMessage response;
            bool ret = cq.updateCustomer(lname, value, "lastName");

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

        // PUT: api/Customer/phoneNumber/555-555-1212
        [HttpPut]
        public HttpResponseMessage Putphone(string phone, [FromBody]Customer value)
        {
            CustomerQuery cq = new CustomerQuery();
            HttpResponseMessage response;
            bool ret = cq.updateCustomer(phone, value, "phoneNumber");

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

        // DELETE: api/Customer/5
        public HttpResponseMessage Delete(int id)
        {
            CustomerQuery cq = new CustomerQuery();
            HttpResponseMessage response;
            bool ret = cq.deleteCustomer(Convert.ToString(id), "custID");

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

        // DELETE: api/Customer/firstName/Joe
        [HttpDelete]
        public HttpResponseMessage DeleteByFirstName(string fname)
        {
            CustomerQuery cq = new CustomerQuery();
            HttpResponseMessage response;
            bool ret = cq.deleteCustomer(fname, "firstName");

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

        // DELETE: api/Customer/lastName/Bzolay
        [HttpDelete]
        public HttpResponseMessage DeleteByLastName(string lname)
        {
            CustomerQuery cq = new CustomerQuery();
            HttpResponseMessage response;
            bool ret = cq.deleteCustomer(lname, "lastName");

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

        // DELETE: api/Customer/phoneNumber/555-555-1212
        [HttpDelete]
        public HttpResponseMessage DeleteByPhoneNumber(string phone)
        {
            CustomerQuery cq = new CustomerQuery();
            HttpResponseMessage response;
            bool ret = cq.deleteCustomer(phone, "phoneNumber");

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
