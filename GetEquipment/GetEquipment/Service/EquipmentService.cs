using GetEquipment.Interface;
using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Service
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
        }

        public IEnumerable<Equipment> GetAll()
        {
            var equipments = _equipmentRepository.GetAll();
            return equipments;
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipmentByCompany(Guid companyID)
        {
            var equipments = await _equipmentRepository.GetAllEquipmentByCompany(companyID);
            return equipments;
        }
    }
}