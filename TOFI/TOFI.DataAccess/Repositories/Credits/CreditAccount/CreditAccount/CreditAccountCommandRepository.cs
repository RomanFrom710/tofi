﻿using DAL.Contexts;
using DAL.Models.Credits.CreditAccount;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;

namespace DAL.Repositories.Credits.CreditAccount
{
    public class CreditAccountCommandRepository : ModelCommandRepository<CreditAccountModel, CreditAccountDto>, ICreditAccountCommandRepository
    {
        public CreditAccountCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override void RestoreFkModels(CreditAccountModel model, CreditAccountDto modelDto)
        {
            model.User = GetUserModel(modelDto.User?.Id);
            model.CreditType = GetCreditTypeModel(modelDto.CreditType?.Id);
        }
    }
}