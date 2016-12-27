namespace BLL.Services.Signature
{
    public interface ISignatureService
    {
        string GenerateNewKey();

        string Sign(string data, string key);

        bool Verify(string data, string signature, string key);
    }
}