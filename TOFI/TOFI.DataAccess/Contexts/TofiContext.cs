using System.Data.Entity;
using DAL.Models.Auth;
using DAL.Models.Client;
using DAL.Models.User;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.BankCredits.CreditTypes;
using DAL.Models.Credits.CreditAccount;
using DAL.Models.Employee;

namespace DAL.Contexts
{
    public class TofiContext : DbContext
    {

        public TofiContext() : base("TofiContext")
        {
            Database.Initialize(false);
        }

        public DbSet<AuthModel> AuthData { get; set; }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<ClientModel> Clients { get; set; }

        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<CurrencyModel> Currency { get; set; }

        public DbSet<PriceModel> Prices { get; set; }

        public DbSet<CreditConditionModel> CreditConditions { get; set; }

        public DbSet<CreditRequirementModel> CreditRequirements { get; set; }

        public DbSet<CreditTypeModel> CreditTypes { get; set; }

        public DbSet<CreditAccountModel> CreditAccounts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthModel>()
                .HasRequired(a => a.User)
                .WithRequiredPrincipal(u => u.Auth)
                .Map(a => a.MapKey("Auth_Id"));

            modelBuilder.Entity<UserModel>()
                .HasOptional(u => u.Client)
                .WithRequired(c => c.User)
                .Map(config => config.MapKey("User_Id"));
            modelBuilder.Entity<UserModel>()
                .HasOptional(u => u.Employee)
                .WithRequired(e => e.User)
                .Map(config => config.MapKey("User_Id"));
            
            modelBuilder.Entity<PriceModel>()
                .HasRequired(p => p.Currency)
                .WithRequiredDependent()
                .Map(p => p.MapKey("Currency_Id"));
            
            modelBuilder.Entity<CreditConditionModel>()
                .HasRequired(c => c.MinCreditSum)
                .WithRequiredDependent()
                .Map(c => c.MapKey("MinCreditSum_Id"));
            modelBuilder.Entity<CreditConditionModel>()
                .HasRequired(c => c.MaxCreditSum)
                .WithRequiredDependent()
                .Map(c => c.MapKey("MaxCreditSum_Id"));

            modelBuilder.Entity<CreditTypeModel>()
                .HasMany(t => t.CreditConditions)
                .WithRequired(c => c.CreditType);
            modelBuilder.Entity<CreditTypeModel>()
                .HasMany(t => t.CreditRequirements)
                .WithRequired(r => r.CreditType);
            modelBuilder.Entity<CreditTypeModel>()
                .HasMany(t => t.CreditAccounts)
                .WithRequired(a => a.CreditType);

            modelBuilder.Entity<CreditAccountModel>()
                .HasRequired(a => a.TotalDebt)
                .WithRequiredDependent()
                .Map(a => a.MapKey("TotalDebt_Id"));
            modelBuilder.Entity<CreditAccountModel>()
                .HasRequired(a => a.FinesForOverdue)
                .WithRequiredDependent()
                .Map(a => a.MapKey("FinesForOverdue_Id"));
            modelBuilder.Entity<CreditAccountModel>()
                .HasRequired(a => a.RemainDebt)
                .WithRequiredDependent()
                .Map(a => a.MapKey("RemainDebt_Id"));
            modelBuilder.Entity<CreditAccountModel>()
                .HasRequired(a => a.User)
                .WithMany(u => u.CreditAccounts);

        }
    }
}