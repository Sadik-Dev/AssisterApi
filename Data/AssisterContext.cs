﻿using AssisterApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Data
{
    public class AssisterContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Media> Medias { get; set; }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Consultation> Appointments { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ProductOrService> ProductOrServices { get; set; }
        public DbSet<UpdateLog> UpdateLogs { get; set; }


        public AssisterContext(DbContextOptions<AssisterContext> options)
            : base(options)
        {

        }

        public void FirstSave()
        {
            base.SaveChanges();
        }
        public void SafeUpdate(object o)
        {
            base.Update(o);
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Consultation>().HasOne(p => p.Invoice).
                WithOne(prop => prop.Consultation).HasForeignKey<Invoice>(i => i.Id);

        }

        public override int SaveChanges()
        {
            UpdateLog log = UpdateLogs.SingleOrDefault(u => u.Id == 1);
            log.LastModification = DateTime.UtcNow.AddHours(1);

            base.Update(log);
            
            return base.SaveChanges();
        }

        public override EntityEntry Update(object entity)
        {
          UpdateLog log = UpdateLogs.SingleOrDefault(u => u.Id == 1);
            log.LastModification = DateTime.UtcNow.AddHours(1);

            base.Update(log);
         
            return base.Update(entity);
        }

    }
}
