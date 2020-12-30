using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssisterApi.Models;
using AssisterApi.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/Customers
        /// <summary>
        /// Get all customers ordered by nqme
        /// </summary>
        /// <returns>array of customers</returns>
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
           
            return _customerRepository.GetAll().OrderBy(r => r.Name);
        }

        // POST: api/Customers
        /// <summary>
        /// Make a new Customer
        /// </summary>
        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {

            _customerRepository.Add(customer);
            _customerRepository.SaveChanges();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);

        }

        // GET: api/Customer/id
        /// <summary>
        /// Get the customer with given id
        /// </summary>
        /// <param name="id">the id of the customer</param>
        /// <returns>The customer</returns>
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            Customer customer = _customerRepository.GetBy(id);

            return customer;

        }

        // PUT: api/Customers
        /// <summary>
        /// Modifies a Customer
        /// </summary>
        [HttpPut]
        public IActionResult PutCustomer( Customer customer)
        {

            Customer updatedCustomer = _customerRepository.GetBy(customer.Id);

            updatedCustomer.BirthDate = customer.BirthDate;
            updatedCustomer.Email = customer.Email;
            updatedCustomer.Gender = customer.Gender;
            updatedCustomer.Name = customer.Name;
            updatedCustomer.RijkRegisterNummer = customer.RijkRegisterNummer;


            _customerRepository.Update(updatedCustomer);
            _customerRepository.SaveChanges();
            return NoContent();
        }
    }
}

