﻿using DAL.Models.Common;
using DAL.Repositories.Model;
using DAL.Contexts;
using TOFI.TransferObjects.Common.Price.DataObjects;

namespace DAL.Repositories.Common.Price
{
    public class PriceCommandRepository : ModelCommandRepository<PriceModel, PriceDto>, IPriceCommandRepository
    {
        public PriceCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}