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
            model.User = GetUserModel(model.User?.Id);
        }
    }
}