using GetEquipment.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Model
{
    public class Equipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EquipmentID { get; set; }
        public Guid CompanyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public double AverageRating { get; set; }
    }
}
