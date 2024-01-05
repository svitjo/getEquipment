using GetEquipment.Data;
using GetEquipment.Interface;
using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Repository
{
    public class ReservedEquipmentRepository : IReservedEquipmentRepository
    {
        private readonly DataContext _dbContext;

        public ReservedEquipmentRepository(DataContext dataContext)
        {
            _dbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
        public async Task AddAsync(ReservedEquipment reservedEquipment)
        {
            reservedEquipment.ReservedEquipmentID = new Guid();
            _dbContext.ReservedEquipments.Add(reservedEquipment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
