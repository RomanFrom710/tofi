using System.Data.Entity;
using DAL.Models.Auth;
using DAL.Models.User;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits;
using DAL.Models.Credits;
using DAL.Models.Credits.BankCredits.CreditCondition;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.BankCredits.CreditType;

namespace DAL.Contexts
{
    public class TofiContext : DbContext
    {
        public DbSet<AuthModel> AuthData { get; set; }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<CurrencyModel> Currency { get; set; }

        public DbSet<PriceModel> Prices { get; set; }

        public DbSet<BankCreditModel> BankCredits { get; set; }

        public DbSet<CreditConditionModel> CreditConditions { get; set; }

        public DbSet<CreditRequirementModel> CreditRequirements { get; set; }

        public DbSet<CreditTypeModel> CreditTypes { get; set; }

        public DbSet<CreditAccountModel> CreditAccounts { get; set; }

        public TofiContext() : base("TofiContext")
        {
            Database.Initialize(false);
        }
    }
}