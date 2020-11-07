using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models.Repositories
{
    public interface ICustomerRepository
    {
        public void Add(Customer customer);

        public void Delete(Customer customer);
        public IEnumerable<Customer> GetAll();
        public Customer GetBy(int id);

        public void SaveChanges();

        public void Update(Customer customer);
    }
}
