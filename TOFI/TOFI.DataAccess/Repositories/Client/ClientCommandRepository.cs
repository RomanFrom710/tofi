using DAL.Contexts;
using DAL.Models.Client;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Client.DataObjects;

namespace DAL.Repositories.Client
{
    public class ClientCommandRepository : ModelCommandRepository<ClientModel, ClientDto>, IClientCommandRepository
    {
        public ClientCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override void RestoreFkModels(ClientModel model, ClientDto modelDto)
        {
            model.User = GetUserModel(modelDto.User?.Id);
            if (modelDto.User != null)
            {
                model.User.FirstName = modelDto.User.FirstName;
                model.User.MiddleName = modelDto.User.MiddleName;
                model.User.LastName = modelDto.User.LastName;
            }
        }
    }
}