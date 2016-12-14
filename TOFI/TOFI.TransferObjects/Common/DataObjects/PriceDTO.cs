using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Common.DataObjects
{
    public class PriceDTO: ModelDto
    {
        public decimal Value { get; set; }

        public CurrencyDTO Currency { get; set; }
    }
}
