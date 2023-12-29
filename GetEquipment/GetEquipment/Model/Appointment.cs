using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Model
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AppointmentId { get; set; }
        public DateTime DateAndTimeOfAppointment { get; set; }
        public int DurationH { get; set; }
        public bool IsReserved { get; set; }
        public Guid AdminId { get; set; }
    }
}
