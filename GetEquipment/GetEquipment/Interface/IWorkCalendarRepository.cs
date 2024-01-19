using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Interface
{
    public interface IWorkCalendarRepository
    {
        Task<WorkCalendar> GetAsync(Guid companyID);
    }
}
