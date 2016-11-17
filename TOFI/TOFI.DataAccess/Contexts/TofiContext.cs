using System.Data.Entity;
using DAL.Models.Auth;
using DAL.Models.User;

namespace DAL.Contexts
{
    public class TofiContext : DbContext
    {
        public DbSet<AuthModel> AuthData { get; set; }

        public DbSet<UserModel> Users { get; set; }


        public TofiContext() : base("name=tofidb")
        {
            
        }
    }
}