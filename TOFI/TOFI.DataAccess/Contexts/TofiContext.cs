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
using DAL.Models.Credits.CreditRequest;
using DAL.Models.Credits.CreditPayment;
using DAL.Models.Actions;

namespace DAL.Contexts
{
    public class TofiContext : DbContext
    {
        
        public TofiContext() : base("TofiContext")
        {
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

        public DbSet<CreditAccountStateModel> CreditAccountStates { get; set; }

        public DbSet<CreditPaymentModel> CreditPayments { get; set; }

        public DbSet<RequestActionModel> RequestActions { get; set; }

        public DbSet<PaymentActionModel> PaymentActions { get; set; }

        public DbSet<CreditRequestModel> CreditRequests { get; set; }


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
                .WithMany()
                .Map(p => p.MapKey("Currency_Id"));
            
            modelBuilder.Entity<CreditConditionModel>()
                .HasRequired(c => c.MinCreditSum)
                .WithOptional()
                .Map(c => c.MapKey("MinCreditSum_Id"));
            modelBuilder.Entity<CreditConditionModel>()
                .HasRequired(c => c.MaxCreditSum)
                .WithOptional()
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
                .HasRequired(a => a.User)
                .WithMany(u => u.CreditAccounts);
            modelBuilder.Entity<CreditAccountModel>()
                .HasMany(a => a.Payments)
                .WithRequired(p => p.CreditAccount);

            modelBuilder.Entity<CreditAccountStateModel>()
                .HasRequired(s => s.CreditAccount)
                .WithMany(a => a.CreditAccountStates)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<CreditAccountStateModel>()
                .HasRequired(s => s.TotalDebt)
                .WithOptional()
                .Map(a => a.MapKey("TotalDebt_Id"));
            modelBuilder.Entity<CreditAccountStateModel>()
                .HasRequired(s => s.FinesForOverdue)
                .WithOptional()
                .Map(a => a.MapKey("FinesForOverdue_Id"));
            modelBuilder.Entity<CreditAccountStateModel>()
                .HasRequired(s => s.RemainDebt)
                .WithOptional()
                .Map(a => a.MapKey("RemainDebt_Id"));
            modelBuilder.Entity<CreditAccountStateModel>()
                .HasRequired(s => s.InterestCounted)
                .WithOptional()
                .Map(a => a.MapKey("InterestCounted_Id"));
            modelBuilder.Entity<CreditAccountStateModel>()
                .HasRequired(s => s.TotalInterestSumNotPaid)
                .WithOptional()
                .Map(a => a.MapKey("TotalInterestSumNotPaid_Id"));

            modelBuilder.Entity<CreditRequestModel>()
                .HasRequired(r => r.Client)
                .WithMany(c => c.CreditRequests);
            modelBuilder.Entity<CreditRequestModel>()
                .HasOptional(r => r.SecurityApproved)
                .WithMany(s => s.CreditRequestsApprovedSecurity);
            modelBuilder.Entity<CreditRequestModel>()
                .HasOptional(r => r.CreditCommitteeApproved)
                .WithMany(c => c.CreditRequestsApprovedCommittee);
            modelBuilder.Entity<CreditRequestModel>()
                .HasOptional(r => r.CreditDepartmentApproved)
                .WithMany(d => d.CreditRequestsApprovedDepartment);
            modelBuilder.Entity<CreditRequestModel>()
                .HasOptional(r => r.OperatorApproved)
                .WithMany(c => c.CreditRequestsApprovedCashier);
            modelBuilder.Entity<CreditRequestModel>()
                .HasRequired(r => r.CreditType)
                .WithMany(t => t.CreditRequests);
            modelBuilder.Entity<CreditRequestModel>()
                .HasOptional(r => r.RequestOpener)
                .WithMany(e => e.RequestsOpened);
            modelBuilder.Entity<CreditRequestModel>()
                .HasRequired(r => r.CreditSum)
                .WithOptional()
                .Map(config => config.MapKey("CreditSum_Id"));

            modelBuilder.Entity<CreditPaymentModel>()
                .HasRequired(p => p.PaymentSum)
                .WithOptional()
                .Map(config => config.MapKey("PaymentSum_Id"));

            modelBuilder.Entity<RequestActionModel>()
                .HasRequired(a => a.CreditRequest)
                .WithMany();
            modelBuilder.Entity<RequestActionModel>()
                .HasRequired(a => a.Employee)
                .WithMany(e => e.RequestActions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentActionModel>()
                .HasRequired(a => a.CreditPayment)
                .WithMany();
            modelBuilder.Entity<PaymentActionModel>()
                .HasRequired(a => a.Employee)
                .WithMany(e => e.PaymentActions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeModel>()
                .HasMany(e => e.CreditPayments)
                .WithRequired(p => p.Employee);

        }
    }
}