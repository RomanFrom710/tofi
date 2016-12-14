using DAL.Models.Common;
using DAL.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Common.DataObjects;
using DAL.Contexts;

namespace DAL.Repositories.Common.Currency
{
    public class CurrencyCommandRepository : ModelCommandRepository<CurrencyModel, CurrencyDTO>, ICurrencyCommandRepository
    {
        public CurrencyCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}
