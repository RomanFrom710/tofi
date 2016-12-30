using BLL.Services.Credits.BankCredits.CreditTypes;
using DAL.Contexts;
using Hangfire;
using System;
using System.Diagnostics;
using System.IO;

namespace TOFI.Web.Worker
{
    public class Worker
    {
        public static void Run()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("hello"));
            var recurringJobManager = new RecurringJobManager();
            RecurringJob.AddOrUpdate("credit-update", () => UpdateRemains(), Cron.Minutely);
            //recurringJobManager.AddOrUpdate("credit-update", Job.FromExpression(() => UpdateRemains()), Cron.Minutely, new RecurringJobOptions());
        }

        public static void UpdateRemains()
        {

            //using (var stream = new FileStream(Environment.CurrentDirectory + "file.txt", FileMode.OpenOrCreate))
            var path = Environment.CurrentDirectory + "file.txt";
            FileMode mode;
            if (File.Exists(path))
            {
                mode = FileMode.Append;
            }
            else
            {
                mode = FileMode.OpenOrCreate;
            }
            Trace.TraceInformation(DateTime.Now.ToString());
            using (var stream = new FileStream(path, mode))
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    streamWriter.WriteLine(DateTime.Now);
                }
            }
            
        }
    }
}