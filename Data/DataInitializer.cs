﻿using AssisterApi.Models;
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
               _dbContext.Database.EnsureDeleted();
               if (_dbContext.Database.EnsureCreated())
               {
                User sadik = new User("SadikDev", "dsk0@live.fr", Convert.ToBase64String(Encoding.UTF8.GetBytes("1974sadik")));

                string birth1 = "1974/12/04";
                DateTime date1 = DateTime.Parse(birth1);

                string birth2 = "1988/08/12";
                DateTime date2 = DateTime.Parse(birth2);

                Customer ahmed = new Customer("Ahmed Sadik", "valenco1@hotmail.be", "singes","male", 97120415301, date1);
                Customer lisa = new Customer("Lisa Marzouki", "lisa@outlook.be", "lisa123lisa", "female", 88081212345, date2);

                string dateString = "2020/12/04 16:54";
                DateTime oDate = DateTime.Parse(dateString);

                Consultation rdv1 = new Consultation(ahmed, oDate, "consultation");
                Consultation rdv2 = new Consultation(lisa, oDate, "consultation");

          

                UpdateLog updateLog = new UpdateLog(DateTime.UtcNow.AddHours(1));

                _dbContext.UpdateLogs.AddRange(updateLog);
                _dbContext.Customers.AddRange(ahmed, lisa);
                _dbContext.Users.AddRange(sadik);
                _dbContext.Appointments.AddRange(rdv1, rdv2);

                _dbContext.FirstSave();
        }
        


        }

    
    }
}
