using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;

namespace DAL.Contexts
{
    public class TofiContext : DbContext
    {
        public TofiContext() : base("TofiContext")
        {
            
        }

        public DbSet<Model> Entities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");

        }
    }
}