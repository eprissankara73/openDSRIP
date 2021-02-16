using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class Battery
    {
        public string SiteId { get; set; }
        public string BatteryId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
