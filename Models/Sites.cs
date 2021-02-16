using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class Sites
    {
        public string UtilityId { get; set; }
        public string SiteId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Timezone { get; set; }
        public int Hassolar { get; set; }
        public int Sqfootage { get; set; }
        public string Type { get; set; }
        public int Floors { get; set; }
        public int Year { get; set; }
        public int Occupants { get; set; }
        public string MarketContext { get; set; }
    }
}
