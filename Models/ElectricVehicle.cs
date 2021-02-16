using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class ElectricVehicle
    {
        public string SiteId { get; set; }
        public string ElectricVehicleId { get; set; }
        public string Name { get; set; }
        public string Vin { get; set; }
        public string NickName { get; set; }
    }
}
