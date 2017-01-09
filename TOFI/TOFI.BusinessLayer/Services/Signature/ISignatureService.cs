using BLL.Result;

namespace BLL.Services.Signature
{
    public interface ISignatureService
    {
        ValueResult<string> GenerateNewKey();

        ValueResult<string> Sign(string data, string key);

        ValueResult<bool> Verify(string data, string signature, string key);
    }
}