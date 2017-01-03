using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Models.Auth;
using DAL.Models.Client;
using DAL.Models.User;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.BankCredits.CreditTypes;
using System.Collections.Generic;

namespace DAL.Migrations
{
    
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Contexts.TofiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.Contexts.TofiContext context)
        {
            // TODO: if seed already called
            if (context.Currency.FirstOrDefault() != null)
            {
                return;
            }
            var currencies = new List<CurrencyModel>()
            {
                new CurrencyModel() { Name = "USD" },
                new CurrencyModel() { Name = "BYN" }
            };

            var creditTypes = new List<CreditTypeModel>()
            {
                new CreditTypeModel()
                {
                    Name = "�� ��� ��� ���",
                    Description = "��������������� ������ ��������� ��� ����������� �� 100 ���. �� 15 000 ���. �� ���� �� 13 ������� �� 5 ���!",
                    InterestRate = 0.36,
                    CreditRequirements = new List<CreditRequirementModel>()
                    {
                        new CreditRequirementModel()
                        {
                            Description = "������� �����������������",
                            ExpectedValue = "�� 21 �� 62 ���"
                        },
                        new CreditRequirementModel()
                        {
                            Description = "�����������",
                            ExpectedValue = "��������� ���������� ��������, ���� ��� �� ���������� �� ���������� ���������� �������� �� ���� �������� �������"
                        },
                        new CreditRequirementModel()
                        {
                            Description = "����������� ���� �� ������� ����� ������",
                            ExpectedValue = "�� ����� 3 �������"
                        }
                    },
                    CreditConditions = new List<CreditConditionModel>()
                    {
                        new CreditConditionModel()
                        {
                            MaxCreditSum = new PriceModel()
                            {
                                Currency = currencies[1],
                                Value = 15000
                            },
                            MinCreditSum = new PriceModel()
                            {
                                Currency = currencies[1],
                                Value = 100
                            },
                            MonthDurationFrom = 13,
                            MonthDurationTo = 60
                        }
                    }
                },
                new CreditTypeModel()
                {
                    Name = "��� ��������",
                    Description = "�������� �������! ������ �� 50 000 ���. �� ���� ����!",
                    InterestRate = 0.3,
                    CreditRequirements = new List<CreditRequirementModel>()
                    {
                        new CreditRequirementModel()
                        {
                            Description = "������� �����������������",
                            ExpectedValue = "�� 27 �� 62 ���"
                        },
                        new CreditRequirementModel()
                        {
                            Description = "�����������",
                            ExpectedValue = "��������� ���������� ��������, ���� ��� �� ���������� �� ���������� ���������� �������� �� ���� �������� �������"
                        },
                        new CreditRequirementModel()
                        {
                            Description = "�����������",
                            ExpectedValue = @"- ���������
- �������������� �� ����� 2-�  ���������� ���"
                        }
                    },
                    CreditConditions = new List<CreditConditionModel>()
                    {
                        new CreditConditionModel()
                        {
                            MonthDurationFrom = 13,
                            MonthDurationTo = 120,
                            MinCreditSum = new PriceModel()
                            {
                                Currency = currencies[1],
                                Value = 5000
                            },
                            MaxCreditSum = new PriceModel()
                            {
                                Currency = currencies[1],
                                Value = 50000
                            }
                        }
                    }
                }
            };

            var testUser = new UserModel()
            {
                Username = "test@test.test",
                Email = "test@test.test",
                FirstName = "Test",
                LastName = "Testovich",
                Auth = new AuthModel()
                {
                    PasswordHash = "Vj6ZiT90kMnqcgg98gBL0qJ2GhHo2N1NnkPlSiZspDs=",
                    Salt = "ReSAlajKUU2ZGYb0tLaNAw==",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                }
            };

            var adminUser = new UserModel()
            {
                Username = "admin@admin.admin",
                Email = "admin@admin.admin",
                FirstName = "Admin",
                LastName = "Adminovich",
                Auth = new AuthModel()
                {
                    PasswordHash = "Vj6ZiT90kMnqcgg98gBL0qJ2GhHo2N1NnkPlSiZspDs=",
                    Salt = "ReSAlajKUU2ZGYb0tLaNAw==",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                }
            };

            context.CreditTypes.AddRange(creditTypes);
            context.Users.Add(testUser);
            context.Users.Add(adminUser);
            context.SaveChanges();
        }
    }
}
