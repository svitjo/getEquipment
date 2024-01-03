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
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly DataContext _dbContext;

        public EquipmentRepository(DataContext dataContext)
        {
            _dbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public IEnumerable<Equipment> GetAll()
        {
            var equipments = _dbContext.Equipments;
            return equipments;
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipmentByCompany(Guid companyID)
        {
            var equipments = await _dbContext.Equipments.Where(e => e.CompanyID == companyID).ToListAsync();
            return equipments;
        }
    }
}
