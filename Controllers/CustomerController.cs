using Microsoft.AspNetCore.Mvc;
using mongoDemo.Models;
using mongoDemo.Services;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mongoDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            this.customerServices = customerServices;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return customerServices.Get();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = customerServices.Get(id);

            if(customer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            customerServices.Create(customer);

            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Customer customer)
        {
            var existingCustomer = customerServices.Get(id);

            if(existingCustomer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            customerServices.Update(id, customer);
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var customer = customerServices.Get(id);

            if (customer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            customerServices.Remove(customer.CustomerId);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}
