using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Model
{
    public class ReservedEquipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReservedEquipmentID { get; set; }
        public Guid ReservedAppointmentID { get; set; }
        public Guid EquipmentID { get; set; }
    }
}
