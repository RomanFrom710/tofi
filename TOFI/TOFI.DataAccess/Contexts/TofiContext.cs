using System.Data.Entity;
using DAL.Models;
using DAL.Models.User;

namespace DAL.Contexts
{
    public class TofiContext : DbContext
    {
        public DbSet<Model> Entities { get; set; }


        public TofiContext() : base("TofiContext")
        {
            
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>().ToTable("Users");

        }
    }
}