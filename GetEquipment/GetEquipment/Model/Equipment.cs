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
        public Guid equipmentID { get; set; }
        public Guid companyID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public EquipmentType equipmentType { get; set; }
        public double averageRating { get; set; }
    }
}
