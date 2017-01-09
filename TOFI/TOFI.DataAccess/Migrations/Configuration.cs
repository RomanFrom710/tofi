using System;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Models.Auth;
using DAL.Models.User;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.BankCredits.CreditTypes;
using System.Collections.Generic;
using DAL.Models.Employee;
using TOFI.Providers;
using DAL.Models.Client;
using DAL.Models.Credits.CreditRequest;

namespace DAL.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Contexts.TofiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Contexts.TofiContext context)
        {
            // TODO: if seed already called
            if (context.Currency.FirstOrDefault() != null)
            {
                return;
            }
            var currencies = new List<CurrencyModel>
            {
                new CurrencyModel {Name = "USD"},
                new CurrencyModel {Name = "BYN"}
            };

            var creditTypes = new List<CreditTypeModel>()
            {
                new CreditTypeModel()
                {
                    Name = "На все про все",
                    Description = "Потребительский кредит наличными без поручителей от 100 руб. до 15 000 руб. на срок от 13 месяцев до 5 лет!",
                    InterestRate = 0.36,
                    CreditRequirements = new List<CreditRequirementModel>()
                    {
                        new CreditRequirementModel
                        {
                            Description = "Возраст кредитополучателя",
                            ExpectedValue = "От 21 до 62 лет"
                        },
                        new CreditRequirementModel
                        {
                            Description = "Гражданство",
                            ExpectedValue = "Гражданин Республики Беларусь, либо вид на жительство на территории Республики Беларусь на срок действия кредита"
                        },
                        new CreditRequirementModel
                        {
                            Description = "Непрерывный стаж на текущем месте работы",
                            ExpectedValue = "Не менее 3 месяцев"
                        }
                    },
                    CreditConditions = new List<CreditConditionModel>
                    {
                        new CreditConditionModel
                        {
                            MaxCreditSum = new PriceModel
                            {
                                Currency = currencies[1],
                                Value = 15000
                            },
                            MinCreditSum = new PriceModel
                            {
                                Currency = currencies[1],
                                Value = 100
                            },
                            MonthDurationFrom = 13,
                            MonthDurationTo = 60
                        }
                    },
                    FineInterest = 0.01m,
                    IsArchived = false
                },
                new CreditTypeModel
                {
                    Name = "Все серьезно",
                    Description = "Выгодные условия! Кредит до 50 000 руб. за один день!",
                    InterestRate = 0.3,
                    CreditRequirements = new List<CreditRequirementModel>
                    {
                        new CreditRequirementModel
                        {
                            Description = "Возраст кредитополучателя",
                            ExpectedValue = "От 27 до 62 лет"
                        },
                        new CreditRequirementModel
                        {
                            Description = "Гражданство",
                            ExpectedValue = "Гражданин Республики Беларусь, либо вид на жительство на территории Республики Беларусь на срок действия кредита"
                        },
                        new CreditRequirementModel
                        {
                            Description = "Обеспечение",
                            ExpectedValue = @"- неустойка
- поручительство не менее 2-х  физических лиц"
                        }
                    },
                    CreditConditions = new List<CreditConditionModel>
                    {
                        new CreditConditionModel
                        {
                            MonthDurationFrom = 13,
                            MonthDurationTo = 120,
                            MinCreditSum = new PriceModel
                            {
                                Currency = currencies[1],
                                Value = 5000
                            },
                            MaxCreditSum = new PriceModel
                            {
                                Currency = currencies[1],
                                Value = 50000
                            }
                        }
                    },
                    FineInterest = 0.015m,
                    IsArchived = false
                }
            };

            var salt = SecurityProvider.GetNewSalt();
            var testUser = new UserModel
            {
                Username = "test@test.test",
                Email = "test@test.test",
                FirstName = "Test",
                LastName = "Testovich",
                MiddleName = "Иванович",
                Client = new ClientModel()
                {
                    Address = "temp",
                    Birthday = new DateTime(1992, 04, 05),
                    Authority = "Беларусь",
                    ExpirationDate = new DateTime(2020, 03, 04),
                    IssueDate = new DateTime(2009, 01, 06),
                    PassportId = "1234567890фыва",
                    PassportNumber = "АВ1234567",
                    Sex = TOFI.TransferObjects.Client.Enums.Sex.Male,
                    TelephoneNumber = "987654321"
                },
                Key = SignatureProvider.GenerateNewKey(),
                Auth = new AuthModel
                {
                    PasswordHash = SecurityProvider.ApplySalt("qwe123", salt),
                    Salt = salt,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                }, 
                EmailConfirmed = true
            };

            salt = SecurityProvider.GetNewSalt();
            var employees = new List<UserModel>()
            {
                new UserModel
                {
                    Username = "empl@empl.empl",
                    Email = "empl@empl.empl",
                    FirstName = "Employee",
                    LastName = "Employevich",
                    Key = SignatureProvider.GenerateNewKey(),
                    Auth = new AuthModel
                    {
                        PasswordHash = SecurityProvider.ApplySalt("qwe123", salt),
                        Salt = salt,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = true
                    },
                    Employee = new EmployeeModel
                    {
                        Rights = TOFI.TransferObjects.Employee.DataObjects.EmployeeRights.Handyman
                    }
                },
                new UserModel
                {
                    Username = "cashier@gmail.com",
                    Email = "cashier@gmail.com",
                    FirstName = "Cashier",
                    LastName = "Cashierovich",
                    Key = SignatureProvider.GenerateNewKey(),
                    Auth = new AuthModel
                    {
                        PasswordHash = SecurityProvider.ApplySalt("qwe123", salt),
                        Salt = salt,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = true
                    },
                    Employee = new EmployeeModel
                    {
                        Rights = TOFI.TransferObjects.Employee.DataObjects.EmployeeRights.Cashier
                    }
                },
                new UserModel
                {
                    Username = "operator@gmail.com",
                    Email = "operator@gmail.com",
                    FirstName = "Operator",
                    LastName = "Operatorovich",
                    Key = SignatureProvider.GenerateNewKey(),
                    Auth = new AuthModel
                    {
                        PasswordHash = SecurityProvider.ApplySalt("qwe123", salt),
                        Salt = salt,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = true
                    },
                    Employee = new EmployeeModel
                    {
                        Rights = TOFI.TransferObjects.Employee.DataObjects.EmployeeRights.Operator
                    }
                },
                new UserModel
                {
                    Username = "committee@gmail.com",
                    Email = "committee@gmail.com",
                    FirstName = "Committee",
                    LastName = "committeevich",
                    Key = SignatureProvider.GenerateNewKey(),
                    Auth = new AuthModel
                    {
                        PasswordHash = SecurityProvider.ApplySalt("qwe123", salt),
                        Salt = salt,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = true
                    },
                    Employee = new EmployeeModel
                    {
                        Rights = TOFI.TransferObjects.Employee.DataObjects.EmployeeRights.CreditCommitteeMember
                    }
                },
                new UserModel
                {
                    Username = "depchef@gmail.com",
                    Email = "depchef@gmail.com",
                    FirstName = "Depchef",
                    LastName = "Depchefovich",
                    Key = SignatureProvider.GenerateNewKey(),
                    Auth = new AuthModel
                    {
                        PasswordHash = SecurityProvider.ApplySalt("qwe123", salt),
                        Salt = salt,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = true
                    },
                    Employee = new EmployeeModel
                    {
                        Rights = TOFI.TransferObjects.Employee.DataObjects.EmployeeRights.CreditDepartmentChief
                    }
                },
                new UserModel
                {
                    Username = "security@gmail.com",
                    Email = "security@gmail.com",
                    FirstName = "Security",
                    LastName = "Securitievich",
                    Key = SignatureProvider.GenerateNewKey(),
                    Auth = new AuthModel
                    {
                        PasswordHash = SecurityProvider.ApplySalt("qwe123", salt),
                        Salt = salt,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = true
                    },
                    Employee = new EmployeeModel
                    {
                        Rights = TOFI.TransferObjects.Employee.DataObjects.EmployeeRights.SecurityOfficer
                    }
                },
            };

            salt = SecurityProvider.GetNewSalt();
            var adminUser = new UserModel
            {
                Username = "admin@admin.admin",
                Email = "admin@admin.admin",
                FirstName = "Admin",
                LastName = "Adminovich",
                Key = SignatureProvider.GenerateNewKey(),
                Auth = new AuthModel
                {
                    PasswordHash = SecurityProvider.ApplySalt("qwe123", salt),
                    Salt = salt,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                Employee = new EmployeeModel
                {
                    Rights = TOFI.TransferObjects.Employee.DataObjects.EmployeeRights.Admin
                }
            };

            salt = SecurityProvider.GetNewSalt();
            var superUser = new UserModel
            {
                Username = "super@super.super",
                Email = "super@super.super",
                FirstName = "Super",
                LastName = "Superovich",
                Key = SignatureProvider.GenerateNewKey(),
                Auth = new AuthModel
                {
                    PasswordHash = SecurityProvider.ApplySalt("qwe123", salt),
                    Salt = salt,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                Employee = new EmployeeModel
                {
                    Rights = TOFI.TransferObjects.Employee.DataObjects.EmployeeRights.Superuser
                }
            };

            context.CreditTypes.AddRange(creditTypes);
            context.Users.Add(testUser);
            context.Users.Add(adminUser);
            context.Users.AddRange(employees);
            context.Users.Add(superUser);
            context.SaveChanges();
        }
    }
}
