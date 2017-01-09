using BLL.Result;

namespace BLL.Services.Security
{
    public interface ISecurityService : IService
    {
        ValueResult<string> GetNewSalt();

        ValueResult<string> ApplySalt(string password, string salt);
    }
}