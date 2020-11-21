using AssisterApi.Models;
using AssisterApi.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AssisterContext _context;
        private readonly DbSet<Customer> _customers;


        public CustomerRepository(AssisterContext dbContext)
        {
            _context = dbContext;
            _customers = _context.Customers;
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers.Include(c => c.Appointments);
        }

        public Customer GetBy(int id)
        {
            return  _customers.SingleOrDefault(c => c.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Update(customer);
        }
    }
}
