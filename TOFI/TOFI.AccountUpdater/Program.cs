using System;
using System.Diagnostics;
using BLL.Mapping;
using BLL.Services.AccountUpdater;
using Ninject;
using TOFI.DependencyInjection;

namespace TOFI.AccountUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.TraceInformation("from webjob " + DateTime.Now.ToString("G"));

            MapperConfig.Initialize();
            var kernel = ResolverModule.GetKernel();
            var accountUpdater = kernel.Get<IAccountUpdaterService>();
            accountUpdater.UpdateAccounts(DateTime.Today);
        }
    }
}