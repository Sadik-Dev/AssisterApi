using AssisterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Data
{
    public interface IUserService
    {
        Employee Authenticate(string username, string password);
        IEnumerable<Employee> GetAll();
    }
}
