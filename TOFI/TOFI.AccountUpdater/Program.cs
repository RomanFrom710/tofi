using System;
using System.Diagnostics;
using TOFI.Web;
using TOFI.BusinessLayer.Updater;

namespace TOFI.AccountUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.TraceInformation("from webjob " + DateTime.Now.ToString());

            var accountUpdater = new AccountUpdaterService();
            MapperConfig.Initialize();
            accountUpdater.UpdateAccounts(DateTime.Today);
        }
    }
}
