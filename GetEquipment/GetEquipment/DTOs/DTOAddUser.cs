using GetEquipment.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.DTOs
{
    public class DTOAddUser
    {
        public string email { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string company { get; set; }
        public Role role { get; set; }
    }
}
