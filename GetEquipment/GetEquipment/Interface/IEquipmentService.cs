using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Interface
{
    public interface IEquipmentService
    {
        IEnumerable<Equipment> GetAll();
        Task<IEnumerable<Equipment>> GetAllEquipmentByCompany(Guid companyID);
    }
}
