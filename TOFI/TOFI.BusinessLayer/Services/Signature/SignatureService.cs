using System;
using BLL.Result;
using NLog;
using TOFI.Providers;

namespace BLL.Services.Signature
{
    public class SignatureService : Service, ISignatureService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public ValueResult<string> GenerateNewKey()
        {
            try
            {
                return new ValueResult<string>(SignatureProvider.GenerateNewKey(), true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Can't generate new key: {ex.Message}");
                return new ValueResult<string>(null, false).Error($"Can't generate new key: {ex.Message}", ex);
            }
        }

        public ValueResult<string> Sign(string data, string key)
        {
            try
            {
                return new ValueResult<string>(SignatureProvider.Sign(data, key), true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Can't sign data: {ex.Message}");
                return new ValueResult<string>(null, false).Error($"Can't sign data: {ex.Message}", ex);
            }
        }

        public ValueResult<bool> Verify(string data, string signature, string key)
        {
            try
            {
                return new ValueResult<bool>(SignatureProvider.Verify(data, signature, key), true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Can't verify signature: {ex.Message}");
                return new ValueResult<bool>(false, false).Error($"Can't verify signature: {ex.Message}", ex);
            }
        }
    }
}