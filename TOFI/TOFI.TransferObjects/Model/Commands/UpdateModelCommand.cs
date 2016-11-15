using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Model.Commands
{
    public class UpdateModelCommand<TModelDto> : Command where TModelDto : ModelDto
    {
        public TModelDto ModelDto { get; set; }
    }
}