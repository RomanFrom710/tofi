using System.Collections.Generic;
using AutoMapper;
using DAL.Contexts;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.BankCredits.CreditTypes;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditTypes
{
    public class CreditTypeCommandRepository : ModelCommandRepository<CreditTypeModel, CreditTypeDto>, ICreditTypeCommandRepository
    {
        public CreditTypeCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override CreditTypeModel CreateDbModel(CreditTypeDto modelDto)
        {
            var model = base.CreateDbModel(modelDto);
            CreateConditionsAndRequirements(model, modelDto);
            return model;
        }

        protected override void UpdateDbModel(CreditTypeModel model, CreditTypeDto modelDto)
        {
            base.UpdateDbModel(model, modelDto);
            foreach (var condition in model.CreditConditions)
            {
                Context.CreditConditions.Remove(condition);
            }
            foreach (var requirement in model.CreditRequirements)
            {
                Context.CreditRequirements.Remove(requirement);
            }
            CreateConditionsAndRequirements(model, modelDto);
        }


        private void CreateConditionsAndRequirements(CreditTypeModel model, CreditTypeDto modelDto)
        {
            model.CreditConditions = new List<CreditConditionModel>();
            model.CreditRequirements = new List<CreditRequirementModel>();
            foreach (var condition in modelDto.CreditConditions)
            {
                var condModel = Mapper.Map<CreditConditionModel>(condition);
                condModel.MinCreditSum.Currency = GetCurrencyModel(condition.MinCreditSum.Currency.Id);
                condModel.MaxCreditSum.Currency = GetCurrencyModel(condition.MaxCreditSum.Currency.Id);
                model.CreditConditions.Add(condModel);
            }
            foreach (var requirement in modelDto.CreditRequirements)
            {
                var reqModel = Mapper.Map<CreditRequirementModel>(requirement);
                model.CreditRequirements.Add(reqModel);
            }
        }
    }
}