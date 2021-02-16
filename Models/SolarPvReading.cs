using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class SolarPvReading
    {
        public string SolarPvReadingId { get; set; }
        public string SolarPvId { get; set; }
        public string SiteId { get; set; }
        public string Time { get; set; }
        public string EnergyValue { get; set; }
        public string EnergyMeterId { get; set; }
        public string EnergyMeterConsumption { get; set; }
        public string EnergyMeterPurchased { get; set; }
        public string EnergyMeterProduction { get; set; }
        public string EnergyMeterSelfConsumption { get; set; }
        public string EnergyMeterFeedIn { get; set; }
        public string PowerValue { get; set; }
        public string PowerMeterId { get; set; }
        public string PowerMeterConsumption { get; set; }
        public string PowerMeterPurchased { get; set; }
        public string PowerMeterProduction { get; set; }
        public string PowerMeterSelfConsumption { get; set; }
        public string PowerMeterFeedIn { get; set; }
        public string StorageValue { get; set; }
        public string StorageMeterId { get; set; }
        public string StorageMeterConsumption { get; set; }
        public string StorageMeterPurchased { get; set; }
        public string StorageMeterProduction { get; set; }
        public string StorageMeterSelfConsumption { get; set; }
        public string StorageMeterFeedIn { get; set; }
    }
}
