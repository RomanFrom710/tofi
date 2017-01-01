using System;
using System.Data.Entity;
using DAL.Contexts;
using DAL.Models.Client;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.CreditTypes;
using DAL.Models.Employee;
using DAL.Models.User;

namespace DAL.Repositories.Model
{
    public abstract class ModelRepository<TModel> : Repository where TModel : Models.Model
    {
        protected readonly DbSet<TModel> ModelsDao;


        protected ModelRepository(TofiContext context) : base(context)
        {
            ModelsDao = Context.Set<TModel>();
        }


        protected ClientModel GetClientModel(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentException("Client Id is invalid");
            }
            var client = Context.Clients.Find(id.Value);
            if (client == null)
            {
                throw new ArgumentException("Client with given Id doesn't exists");
            }
            return client;
        }

        protected CreditTypeModel GetCreditTypeModel(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentException("CreditType Id is invalid");
            }
            var creditType = Context.CreditTypes.Find(id.Value);
            if (creditType == null)
            {
                throw new ArgumentException("CreditType with given Id doesn't exists");
            }
            return creditType;
        }

        protected CurrencyModel GetCurrencyModel(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentException("Currency Id is invalid");
            }
            var currency = Context.Currency.Find(id.Value);
            if (currency == null)
            {
                throw new ArgumentException("Currency with given Id doesn't exists");
            }
            return currency;
        }

        protected EmployeeModel GetEmployeeModelOptional(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }
            var employee = Context.Employees.Find(id.Value);
            if (employee == null)
            {
                throw new ArgumentException("Employee with given Id doesn't exists");
            }
            return employee;
        }

        protected UserModel GetUserModel(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentException("User Id is invalid");
            }
            var user = Context.Users.Find(id.Value);
            if (user == null)
            {
                throw new ArgumentException("User with given Id doesn't exists");
            }
            return user;
        }
    }
}