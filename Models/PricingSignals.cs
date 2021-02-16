using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class PricingSignals
    {
        public string PricingSignalId { get; set; }
        public string EventId { get; set; }
        public string Time { get; set; }
        public string MarketContext { get; set; }
        public string CreatedDateTime { get; set; }
        public string DtStart { get; set; }
        public string Duration { get; set; }
        public string StartAfter { get; set; }
        public float SignalValue { get; set; } 
        public string SignalIntervalText { get; set; }
        public string SignalIntervalStartDate { get; set; }
        public string SignalIntervalDuration { get; set; }
        public float SignalIntervalPayloadValue { get; set; }
        public int SignalDescriptionNumber { get; set; }
        public string SignalUnitsNumber { get; set; }
        public int SignalScaleCode { get; set; }
        public string SignalId { get; set; }
        public string SignalName { get; set; }
        public int SignalType { get; set; }
    }
}
