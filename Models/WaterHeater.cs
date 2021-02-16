using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class WaterHeater
    {
        public string SiteId { get; set; }
        public string WaterHeaterId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
