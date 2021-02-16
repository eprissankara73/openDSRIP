using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class BatteryReading
    {
        public string BatteryReadingId { get; set; }
        public string BatteryId { get; set; }
        public string SiteId { get; set; }
        public string Time { get; set; }
        public string ConsumptionWatts { get; set; }
        public string Frequency { get; set; }
        public string IntervalPower { get; set; }
        public string ProductionWatts { get; set; }
        public string StateOfCharge { get; set; }
        public string AcVoltage { get; set; }
        public string BatteryVoltage { get; set; }
    }
}
