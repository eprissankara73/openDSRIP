using System;
using System.Collections.Generic;

namespace MYSQL.Models
{
    public partial class ElectricVehicleReading
    {
        public string ElectricVehicleReadingId { get; set; }
        public string ElectricVehicleId { get; set; }
        public string SiteId { get; set; }
        public string Time { get; set; }
        public int BatteryCapacityAndRange { get; set; }
        public int StateOfCharge { get; set; }
        public string DesiredStateOfCharge { get; set; }
        public string ChargingState { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int ChargerPilotCurrent { get; set; }
        public int ChargerPilotActual { get; set; }
        public int ChargerVoltage { get; set; }
        public int ChargerPower { get; set; }
        public int TimeUntilFullCharge { get; set; }
        public string ChargerPhase { get; set; }
        public string SuperCharger { get; set; }
        public string ScheduledChargingPending { get; set; }
        public string ScheduledChargingStartTime { get; set; }
        public int Speed { get; set; }
        public int Odometer { get; set; }
        public int InsideTemperature { get; set; }
        public int OutsideTemperature { get; set; }
        public string SmartPreConditioningEnabled { get; set; }
    }
}
