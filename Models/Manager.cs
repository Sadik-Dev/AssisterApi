using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models
{
    public class Manager: Employee
    {
        public Manager()
        {

        }
        public Manager(String name, String gender, string email, string password) : base(name,gender,email,password)
        {
            
        }
    }
}
