using GetEquipment.Data;
using GetEquipment.Interface;
using GetEquipment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Repository
{
    public class WorkCalendarRepository : IWorkCalendarRepository
    {
        private readonly DataContext _dbContext;

        public WorkCalendarRepository(DataContext dataContext)
        {
            _dbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
        public async Task<WorkCalendar> GetAsync(Guid companyID)
        {
            WorkCalendar workCalendar = await _dbContext.WorkCalendars.SingleOrDefaultAsync(c => c.CompanyId == companyID);
            return workCalendar;
        }
    }
}
