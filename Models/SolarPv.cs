using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class SolarPv
    {
        public string SiteId { get; set; }
        public string SolarPvId { get; set; }
        public string Name { get; set; }
        public string HouseholdId { get; set; }
    }
}
