using AssisterApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Data
{
    public class AssisterContext : DbContext
    {
        public DbSet<Media> Medias { get; set; }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<File> Files { get; set; }


        public DbSet<Consultation> Appointments { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ProductOrService> ProductOrServices { get; set; }


        public AssisterContext(DbContextOptions<AssisterContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Consultation>().HasOne(p => p.Invoice).
                WithOne(prop => prop.Consultation).HasForeignKey<Invoice>(i => i.Id);

        }


    }
}
