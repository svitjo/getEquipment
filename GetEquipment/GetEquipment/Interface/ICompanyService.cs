using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Interface
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAll();
        Task<Company> GetAsync(Guid companyID);
        Task<WorkCalendar> GetWorkCalendar(Guid companyID);
    }
}
