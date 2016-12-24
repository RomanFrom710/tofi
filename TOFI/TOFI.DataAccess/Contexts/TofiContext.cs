using System.Data.Entity;
using DAL.Models.Auth;
using DAL.Models.User;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.BankCredit;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.BankCredits.CreditTypes;
using DAL.Models.Credits.CreditAccount;

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

        public DbSet<CurrencyModel> Currency { get; set; }

        public DbSet<PriceModel> Prices { get; set; }

        public DbSet<BankCreditModel> BankCredits { get; set; }

        public DbSet<CreditConditionModel> CreditConditions { get; set; }

        public DbSet<CreditRequirementModel> CreditRequirements { get; set; }

        public DbSet<CreditTypeModel> CreditTypes { get; set; }

        public DbSet<CreditAccountModel> CreditAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthModel>()
                .HasRequired(a => a.User)
                .WithRequiredPrincipal(u => u.Auth);

            modelBuilder.Entity<PriceModel>()
                .HasRequired(p => p.Currency);
            
            modelBuilder.Entity<BankCreditModel>()
                .HasRequired(c => c.CreditType)
                .WithMany(t => t.BankCredits);
            modelBuilder.Entity<BankCreditModel>()
                .HasRequired(c => c.CreditAccount)
                .WithRequiredDependent(a => a.BankCredit);

            modelBuilder.Entity<CreditConditionModel>()
                .HasRequired(c => c.MinCreditSum);
            modelBuilder.Entity<CreditConditionModel>()
                .HasRequired(c => c.MaxCreditSum);

            modelBuilder.Entity<CreditTypeModel>()
                .HasMany(t => t.CreditConditions)
                .WithRequired(c => c.CreditType);
            modelBuilder.Entity<CreditTypeModel>()
                .HasMany(t => t.CreditRequirements)
                .WithRequired(r => r.CreditType);

            modelBuilder.Entity<CreditAccountModel>()
                .HasRequired(a => a.TotalDebt);
            modelBuilder.Entity<CreditAccountModel>()
                .HasRequired(a => a.FinesForOverdue);
            modelBuilder.Entity<CreditAccountModel>()
                .HasRequired(a => a.RemainDebt);
            modelBuilder.Entity<CreditAccountModel>()
                .HasRequired(a => a.User)
                .WithMany(u => u.CreditAccounts);

        }
    }
}