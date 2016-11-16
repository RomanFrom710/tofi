using System.Data.Entity;
using DAL.Models;

namespace DAL.Contexts
{
    public class TofiContext : DbContext
    {
        public DbSet<Model> Models { get; set; }


        public TofiContext() : base("name=tofidb")
        {
            
        }
    }
}