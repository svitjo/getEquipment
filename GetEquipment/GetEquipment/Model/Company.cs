using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Model
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid companyID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public List<Equipment> equipmentInStock { get; set; }
        public List<Appoitment> pickUpAppointments { get; set; }
        public double averageRating { get; set; }
    }
}
