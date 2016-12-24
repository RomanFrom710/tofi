﻿using DAL.Models.Common;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Common.DataObjects;
using DAL.Contexts;

namespace DAL.Repositories.Common.Currency
{
    public class CurrencyQueryRepository : ModelQueryRepository<CurrencyModel, CurrencyDTO>, ICurrencyQueryRepository
    {
        public CurrencyQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}