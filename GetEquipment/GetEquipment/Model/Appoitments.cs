using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Model
{
    public class Appoitment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid appointmentId { get; set; }
        public DateTime dateAndTimeOfAppointment { get; set; }
        public bool isSuccessful { get; set; }
        public string companyName { get; set; }
    }
}
