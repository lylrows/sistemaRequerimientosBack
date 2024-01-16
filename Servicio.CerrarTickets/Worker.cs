using Quartz.Impl;
using Quartz;
using System.Data.SqlClient;
using System.Data;

namespace Servicio.CerrarTickets
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<DatabaseJob>()
                .WithIdentity("databaseJob", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("databaseTrigger", "group1")
                .StartAt(DateBuilder.DateOf(20, 0, 0)) // la hora es 20 (8 PM)
                .WithSimpleSchedule(x => x.WithIntervalInHours(24).RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
        public class DatabaseJob : IJob
        {
            private readonly IConfiguration _configuration;

            public DatabaseJob(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task Execute(IJobExecutionContext context)
            {
                string connectionString = _configuration.GetConnectionString("local");
                int result;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_CerrarTicketsSGR", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter outputParam = new SqlParameter("@result", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        cmd.ExecuteNonQuery();

                        result = (int)cmd.Parameters["@result"].Value;
                    }
                }
                // si el resultado es cero, reprogramar la tarea para que se ejecute en 30 minutos
                if (result == 0)
                {
                    var triggerKey = context.Trigger.Key;
                    await context.Scheduler.RescheduleJob(triggerKey,
                        TriggerBuilder.Create()
                            .WithIdentity(triggerKey.Name, triggerKey.Group)
                            .StartAt(DateBuilder.FutureDate(30, IntervalUnit.Minute))
                            .Build());
                }
            }
        }
    }
}