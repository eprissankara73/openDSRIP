using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class PowerReadings
    {
        public string PowerReadingId { get; set; }
        public string SiteId { get; set; }
        public string LoadId { get; set; }
        public decimal Average { get; set; }
        public string Time { get; set; }
    }
}
