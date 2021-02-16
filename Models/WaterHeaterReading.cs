using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class WaterHeaterReading
    {
        public string WaterHeaterReadingId { get; set; }
        public string SiteId { get; set; }
        public string WaterHeaterId { get; set; }
        public string Time { get; set; }
        public int Status { get; set; }
        public int SetPoint { get; set; }
        public int MinSetPoint { get; set; }
        public int MaxSetPoint { get; set; }
        public int UpperTemperature { get; set; }
        public int LowerTemperature { get; set; }
        public int AmbientTemperature { get; set; }
        public string TemperatureUnits { get; set; }
        public string VacationMode { get; set; }
        public string InUse { get; set; }
    }
}
