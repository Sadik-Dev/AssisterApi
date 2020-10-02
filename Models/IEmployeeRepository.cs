using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models
{
   public interface IEmployeeRepository
    {
        Employee GetBy(int id);
        IEnumerable<Employee> GetAll();
        void Add(Employee employee);
        void SaveChanges();
        bool isEmployeeManager(string email);
    }
}
