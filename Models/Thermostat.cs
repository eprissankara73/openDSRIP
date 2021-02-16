using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class Thermostat
    {
        public string SiteId { get; set; }
        public string ThermostatId { get; set; }
        public string Name { get; set; }
        public string EndUse { get; set; }
    }
}
