using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Common
{
    public class PriceModel: Model
    {
        public decimal Value { get; set; }

        public CurrencyModel Currency { get; set; }
    }
}
