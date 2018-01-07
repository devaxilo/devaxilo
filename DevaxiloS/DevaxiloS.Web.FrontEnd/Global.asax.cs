using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DevaxiloS.Services.Commands.Web.Trigger;
using Quartz;
using Quartz.Impl;

namespace DevaxiloS.Web.FrontEnd
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // construct a scheduler factory
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<LayKetQuaXoSoMienBacJob>()
                .WithIdentity("JobGetKetQua", "groupKQXSMB")
                .Build();

            // Trigger the job to run now, and then every 60 seconds
            //Gio chay o viet nam la 18h gio utc la 18-7=11
            //Chay den 19h15 la 1 tieng dong ho de lay ket qua chinh xac
            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                (s =>
                    s.WithIntervalInSeconds(60)
                        .OnEveryDay()
                        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(11, 15))
                        .EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(17, 15)).InTimeZone(TimeZoneInfo.Utc)
                )
                .Build();

            sched.ScheduleJob(job, trigger);
        }
    }
}
