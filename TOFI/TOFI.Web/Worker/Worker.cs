using Hangfire;
using System;
using System.IO;

namespace TOFI.Web.Worker
{
    public class Worker
    {
        internal static void Run()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("hello"));
            var recurringJobManager = new RecurringJobManager();
            RecurringJob.AddOrUpdate("credit-update", () => UpdateRemains(), Cron.Minutely);
            //recurringJobManager.AddOrUpdate("credit-update", Job.FromExpression(() => UpdateRemains()), Cron.Minutely, new RecurringJobOptions());
        }

        private static void UpdateRemains()
        {
            using (var stream = new FileStream("file.txt", FileMode.OpenOrCreate))
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    streamWriter.WriteLine(DateTime.Now);
                }
            }
            
        }
    }
}