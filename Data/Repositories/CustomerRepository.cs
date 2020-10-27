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
            throw new NotImplementedException();
        }

        public void Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetBy(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
