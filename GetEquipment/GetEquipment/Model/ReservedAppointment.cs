using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Model
{
    public class ReservedAppointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReservationId { get; set; }
        public Guid AppointmentId { get; set; }
        public Guid UserId { get; set; }
        public bool IsCanceled { get; set; }
    }
}
