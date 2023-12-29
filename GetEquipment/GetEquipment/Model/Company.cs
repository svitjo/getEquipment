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
        public Guid CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Equipment> EquipmentInStock { get; set; }
        public WorkCalendar WorkCalendar { get; set; }
        public double AverageRating { get; set; }
    }
}
