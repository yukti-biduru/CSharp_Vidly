using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.APIs
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /apis/customers 
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(c => Mapper.Map<Customer, CustomerDto>(c)));
        }

        // GET /apis/customers/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }

        // POST /apis/customers 
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customer_dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customer_dto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            
            return Created(new Uri(Request.RequestUri.ToString() + '/' + customer.Id), customer_dto);
        }

        // PUT Customer (customer, id)
        [HttpPut]
        public IHttpActionResult UpdateCustomer(CustomerDto customer_dto, int Id)
        {
            if (customer_dto == null)
            {
                return BadRequest();
            }
            var customerInDB = _context.Customers.SingleOrDefault(x => x.Id == Id);
            if (customerInDB == null)
            {
                return NotFound();
            }
            Mapper.Map(customerInDB, customer_dto);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE Customer (id)
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(x => x.Id == Id);
            if (customerInDB == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
            return Ok();
        }

    }
}
