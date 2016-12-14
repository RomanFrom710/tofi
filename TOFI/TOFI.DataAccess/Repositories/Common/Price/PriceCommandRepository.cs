using DAL.Models.Common;
using DAL.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Common.DataObjects;
using DAL.Contexts;

namespace DAL.Repositories.Common.Price
{
    public class PriceCommandRepository : ModelCommandRepository<PriceModel, PriceDTO>, IPriceCommandRepository
    {
        public PriceCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}
