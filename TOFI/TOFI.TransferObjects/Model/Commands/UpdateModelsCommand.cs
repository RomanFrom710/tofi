using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Model.Commands
{
    public class UpdateModelsCommand<TModelDto> : Command where TModelDto : ModelDto
    {
        public ICollection<TModelDto> ModelsDto { get; set; }
    }
}
