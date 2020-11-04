using AssisterApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AssisterApi.Data
{
    public class DataInitializer
    {
        private readonly AssisterContext _dbContext;


        public DataInitializer(AssisterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void LoadDB()
        {
               //_dbContext.Database.EnsureDeleted();
               if (_dbContext.Database.EnsureCreated())
               {
                Customer ahmed = new Customer("Ahmed Sadik", "valenco1@hotmail.be", "singes");
                Customer lisa = new Customer("Lisa Marzouki", "lisa@outlook.be", "lisa123lisa");

                Consultation rdv1 = new Consultation(ahmed,DateTime.Today, "consultation");
                Consultation rdv2 = new Consultation(lisa, DateTime.Today, "consultation");

                IList<ProductOrService> rdv = new List<ProductOrService>();
                rdv.Add(new ProductOrService("30m consultatie", 65));

                rdv1.generateInvoice(rdv);
                rdv2.generateInvoice(rdv);

                _dbContext.Customers.AddRange(ahmed, lisa);
                _dbContext.Appointments.AddRange(rdv1, rdv2);
                _dbContext.SaveChanges();
        }
        


        }

    
    }
}
