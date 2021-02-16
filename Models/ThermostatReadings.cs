using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class TstatDataTemplate
    {
        public string ThermostatReadingId { get; set; }
        public string ThermostatId { get; set; }
        public string SiteId { get; set; }
        public string Time { get; set; }
        public int CoolSetting { get; set; }
        public int HeatSetting { get; set; }
        public string Fan { get; set; }
        public int Temperature { get; set; }
        public string RunStatus { get; set; }
        public string System { get; set; }
    }
}
