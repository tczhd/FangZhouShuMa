using FangZhouShuMa.Api.Interfaces;
using FangZhouShuMa.ApplicationCore.Entities;
using FangZhouShuMa.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace FangZhouShuMa.Api.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IAsyncRepository<Schedule> _scheduleRepository;
        public ScheduleService(IAsyncRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public void AddSchedule()
        {
            var schedule = new Schedule()
            {
                LastUpdateDate = DateTime.UtcNow,
                Name = "Test"
            };

            try
            {
                _scheduleRepository.AddAsync(schedule);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }
    }
}
