using DAL.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Common.DataObjects;

namespace DAL.Repositories.Common.Price
{
    public interface IPriceCommandRepository: IModelCommandRepository<PriceDTO>
    {
    }
}
