using System;
using BLL.Result;
using NLog;
using TOFI.Providers;

namespace BLL.Services.Security
{
    public class SecurityService : Service, ISecurityService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public ValueResult<string> GetNewSalt()
        {
            try
            {
                return new ValueResult<string>(SecurityProvider.GetNewSalt(), true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Can't generate new salt: {ex.Message}");
                return new ValueResult<string>(null, false).Error($"Can't generate new salt: {ex.Message}", ex);
            }
        }

        public ValueResult<string> ApplySalt(string passwordText, string saltText)
        {
            try
            {
                return new ValueResult<string>(SecurityProvider.ApplySalt(passwordText, saltText), true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Can't apply salt: {ex.Message}");
                return new ValueResult<string>(null, false).Error($"Can't apply salt: {ex.Message}", ex);
            }
        }
    }
}