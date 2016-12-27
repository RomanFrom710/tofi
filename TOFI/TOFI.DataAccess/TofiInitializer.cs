using DAL.Contexts;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.BankCredits.CreditTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TofiInitializer: CreateDatabaseIfNotExists<TofiContext>
    {
        protected override void Seed(TofiContext context)
        {
            var currencies = new List<CurrencyModel>()
            {
                new CurrencyModel() { Name = "USD" },
                new CurrencyModel() { Name = "BYN" }
            };

            var creditTypes = new List<CreditTypeModel>()
            {
                new CreditTypeModel()
                {
                    Description = "Потребительский кредит наличными без поручителей от 100 руб. до 15 000 руб. на срок от 13 месяцев до 5 лет!",
                    InterestRate = 0.36,
                    CreditRequirements = new List<CreditRequirementModel>()
                    {
                        new CreditRequirementModel()
                        {
                            Description = "Возраст кредитополучателя",
                            ExpectedValue = "От 21 до 62 лет"
                        },
                        new CreditRequirementModel()
                        {
                            Description = "Гражданство",
                            ExpectedValue = "Гражданин Республики Беларусь, либо вид на жительство на территории Республики Беларусь на срок действия кредита"
                        },
                        new CreditRequirementModel()
                        {
                            Description = "Непрерывный стаж на текущем месте работы",
                            ExpectedValue = "Не менее 3 месяцев"
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
                    Description = "Выгодные условия! Кредит до 50 000 руб. за один день!",
                    InterestRate = 0.3,
                    CreditRequirements = new List<CreditRequirementModel>()
                    {
                        new CreditRequirementModel()
                        {
                            Description = "Возраст кредитополучателя",
                            ExpectedValue = "От 27 до 62 лет"
                        },
                        new CreditRequirementModel()
                        {
                            Description = "Гражданство",
                            ExpectedValue = "Гражданин Республики Беларусь, либо вид на жительство на территории Республики Беларусь на срок действия кредита"
                        },
                        new CreditRequirementModel()
                        {
                            Description = "Обеспечение",
                            ExpectedValue = @"- неустойка
- поручительство не менее 2-х  физических лиц"
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

            context.CreditTypes.AddRange(creditTypes);
            context.SaveChanges();
        }
    }
}
