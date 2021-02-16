using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MYSQL.Models
{
    public partial class dsripppdContext : DbContext
    {
        public dsripppdContext()
        {
        }

        public dsripppdContext(DbContextOptions<dsripppdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Battery> Batteries { get; set; }
        public virtual DbSet<BatteryReading> BatteryReadings { get; set; }
        public virtual DbSet<Loads> Loads { get; set; }
        public virtual DbSet<PowerReadings> PowerReadings { get; set; }
        public virtual DbSet<Sites> Sites { get; set; }
        public virtual DbSet<Thermostat> Thermostats { get; set; }
        public virtual DbSet<ThermostatReading> ThermostatReadings { get; set; }
        public virtual DbSet<Utilities> Utilities { get; set; }
        public virtual DbSet<WaterHeater> WaterHeaters { get; set; }
        public virtual DbSet<WaterHeaterReading> WaterHeaterReadings { get; set; }
        public virtual DbSet<ElectricVehicle> ElectricVehicles { get; set; }
        public virtual DbSet<ElectricVehicleReading> ElectricVehicleReadings { get; set; }
        public virtual DbSet<SolarPv> SolarPvs { get; set; }
        public virtual DbSet<SolarPvReading> SolarPvReadings { get; set; }
        public virtual DbSet<PricingSignals> PricingSignals { get; set; }
        //public virtual DbSet<PricingSignals> PricingSignals { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Battery>(entity =>
            {
                entity.HasKey(e => e.BatteryId)
                    .HasName("PRIMARY");

                entity.ToTable("batteries");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");

                entity.Property(e => e.BatteryId)
                    .IsRequired()
                    .HasColumnName("batteryid")
                    .HasMaxLength(36);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(16);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(512);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);
            });

            modelBuilder.Entity<BatteryReading>(entity =>
            {
                entity.HasKey(e => e.BatteryReadingId)
                    .HasName("PRIMARY");

                entity.ToTable("batteryreadings");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");
                
                entity.HasIndex(e => e.BatteryId)
                    .HasName("batteryid");

                entity.HasIndex(e => e.Time)
                    .HasName("timestamp");

                entity.Property(e => e.BatteryReadingId)
                    .IsRequired()
                    .HasColumnName("batteryreadingid")
                    .HasMaxLength(36);

                entity.Property(e => e.BatteryId)
                    .IsRequired()
                    .HasColumnName("batteryid")
                    .HasMaxLength(36);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .HasMaxLength(24);

                entity.Property(e => e.ConsumptionWatts)
                    .IsRequired()
                    .HasColumnName("consumptionwatts")
                    .HasMaxLength(20);

                entity.Property(e => e.Frequency)
                    .IsRequired()
                    .HasColumnName("frequency")
                    .HasMaxLength(20);
                
                entity.Property(e => e.IntervalPower)
                    .IsRequired()
                    .HasColumnName("intervalpower")
                    .HasMaxLength(20);
                
                entity.Property(e => e.ProductionWatts)
                    .IsRequired()
                    .HasColumnName("productionwatts")
                    .HasMaxLength(20);
                
                entity.Property(e => e.StateOfCharge)
                    .IsRequired()
                    .HasColumnName("stateofcharge")
                    .HasMaxLength(20);
                
                entity.Property(e => e.AcVoltage)
                    .IsRequired()
                    .HasColumnName("acvoltage")
                    .HasMaxLength(20);
                
                entity.Property(e => e.BatteryVoltage)
                    .IsRequired()
                    .HasColumnName("batteryvoltage")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ElectricVehicle>(entity => 
            {
                entity.HasKey(e => e.ElectricVehicleId)
                    .HasName("PRIMARY");
                
                entity.ToTable("electricvehicles");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");
                
                entity.Property(e => e.ElectricVehicleId)
                    .IsRequired()
                    .HasColumnName("electricvehicleid")
                    .HasMaxLength(36);
                
                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);
                
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
                
                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasColumnName("vin")
                    .HasMaxLength(64);
                
                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasColumnName("nickname")
                    .HasMaxLength(64);

            });

            modelBuilder.Entity<ElectricVehicleReading>(entity =>
            {
                entity.HasKey(e => e.ElectricVehicleReadingId)
                    .HasName("PRIMARY");

                entity.ToTable("electricvehiclereadings");

                entity.HasIndex(e => e.ElectricVehicleId)
                    .HasName("electricvehicleid");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");

                entity.HasIndex(e => e.Time)
                    .HasName("timestamp");

                entity.Property(e => e.ElectricVehicleReadingId)
                    .IsRequired()
                    .HasColumnName("electricvehiclereadingid")
                    .HasMaxLength(36);

                entity.Property(e => e.ElectricVehicleId)
                    .IsRequired()
                    .HasColumnName("electricvehicleid")
                    .HasMaxLength(36);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);
                
                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .HasMaxLength(24);

                entity.Property(e => e.BatteryCapacityAndRange).HasColumnName("batterycapacityandrange");

                entity.Property(e => e.StateOfCharge).HasColumnName("stateofcharge");

                entity.Property(e => e.DesiredStateOfCharge)
                    .HasColumnName("desiredstateofcharge")
                    .HasMaxLength(36);
                
                entity.Property(e => e.ChargingState)
                    .HasColumnName("chargingstate")
                    .HasMaxLength(36);
                
                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.ChargerPilotCurrent).HasColumnName("chargerpilotcurrent");

                entity.Property(e => e.ChargerPilotActual).HasColumnName("chargerpilotactual");

                entity.Property(e => e.ChargerVoltage).HasColumnName("chargervoltage");

                entity.Property(e => e.ChargerPower).HasColumnName("chargerpower");

                entity.Property(e => e.TimeUntilFullCharge).HasColumnName("timeuntilfullcharge");

                entity.Property(e => e.ChargerPhase)
                    .HasColumnName("chargerphase")
                    .HasMaxLength(36);
                
                entity.Property(e => e.SuperCharger)
                    .HasColumnName("supercharger")
                    .HasMaxLength(36);
                
                entity.Property(e => e.ScheduledChargingPending)
                    .HasColumnName("scheduledchargingpending")
                    .HasMaxLength(36);

                entity.Property(e => e.ScheduledChargingStartTime)
                    .HasColumnName("scheduledchargingstarttime")
                    .HasMaxLength(36);
                
                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.Odometer).HasColumnName("odometer");

                entity.Property(e => e.InsideTemperature).HasColumnName("insidetemperature");

                entity.Property(e => e.OutsideTemperature).HasColumnName("outsidetemperature");

                entity.Property(e => e.SmartPreConditioningEnabled)
                    .HasColumnName("smartpreconditioningenabled")
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Loads>(entity =>
            {
                entity.HasKey(e => e.LoadId)
                    .HasName("PRIMARY");

                entity.ToTable("loads");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");

                entity.Property(e => e.LoadId)
                    .IsRequired()
                    .HasColumnName("loadid")
                    .HasMaxLength(36);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<PowerReadings>(entity =>
            {
                entity.HasKey(e => e.PowerReadingId)
                    .HasName("PRIMARY");

                entity.ToTable("powerreadings");

                entity.HasIndex(e => e.LoadId)
                    .HasName("loadid");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");

                entity.HasIndex(e => e.Time)
                    .HasName("timestamp");

                entity.Property(e => e.PowerReadingId)
                    .IsRequired()
                    .HasColumnName("powerreadingid")
                    .HasMaxLength(36);

                entity.Property(e => e.LoadId)
                    .IsRequired()
                    .HasColumnName("loadid")
                    .HasMaxLength(36);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);
                
                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .HasMaxLength(24);

                entity.Property(e => e.Average)
                    .IsRequired()
                    .HasColumnName("average")
                    .HasColumnType("decimal(20,10)");
            });

            modelBuilder.Entity<Sites>(entity =>
            {
                entity.HasKey(e => e.SiteId)
                    .HasName("PRIMARY");

                entity.ToTable("sites");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(32);

                entity.Property(e => e.Floors).HasColumnName("floors");

                entity.Property(e => e.Hassolar).HasColumnName("hassolar");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(512);

                entity.Property(e => e.Occupants).HasColumnName("occupants");

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);

                entity.Property(e => e.Sqfootage).HasColumnName("sqfootage");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(16);

                entity.Property(e => e.Timezone)
                    .IsRequired()
                    .HasColumnName("timezone")
                    .HasMaxLength(32);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(16);

                entity.Property(e => e.UtilityId)
                    .IsRequired()
                    .HasColumnName("utilityid")
                    .HasMaxLength(36)
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnName("zipcode")
                    .HasMaxLength(12);
                
                entity.Property(e => e.MarketContext)
                    .HasColumnName("marketcontext")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Thermostat>(entity =>
            {
                entity.HasKey(e => e.ThermostatId)
                    .HasName("PRIMARY");

                entity.ToTable("thermostats");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.EndUse)
                    .IsRequired()
                    .HasColumnName("enduse")
                    .HasMaxLength(32);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);

                entity.Property(e => e.ThermostatId)
                    .IsRequired()
                    .HasColumnName("thermostatid")
                    .HasMaxLength(36);

            });

            modelBuilder.Entity<ThermostatReading>(entity =>
            {
                entity.HasKey(e => e.ThermostatReadingId)
                    .HasName("PRIMARY");

                entity.ToTable("thermostatreadings");

                entity.HasIndex(e => e.ThermostatId)
                    .HasName("thermostatid");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");

                entity.HasIndex(e => e.Time)
                    .HasName("time");
                
                entity.Property(e => e.ThermostatReadingId)
                    .IsRequired()
                    .HasColumnName("thermostatreadingid")
                    .HasMaxLength(32);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);

                entity.Property(e => e.ThermostatId)
                    .IsRequired()
                    .HasColumnName("thermostatid")
                    .HasMaxLength(36);

                entity.Property(e => e.System)
                    .HasColumnName("system")
                    .HasMaxLength(16);

                entity.Property(e => e.CoolSetting)
                    .HasColumnName("coolsetting");
                
                entity.Property(e => e.HeatSetting)
                    .HasColumnName("heatsetting");

                entity.Property(e => e.Fan)
                    .HasColumnName("fan")
                    .HasMaxLength(16);

                entity.Property(e => e.Temperature)
                    .HasColumnName("temperature");

                entity.Property(e => e.RunStatus)
                    .HasColumnName("runstatus")
                    .HasMaxLength(16);
                
                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .HasMaxLength(16);

            });

            modelBuilder.Entity<Utilities>(entity =>
            {
                entity.HasKey(e => e.UtilityId)
                    .HasName("PRIMARY");

                entity.ToTable("utilities");

                entity.Property(e => e.UtilityName)
                    .IsRequired()
                    .HasColumnName("utilityname")
                    .HasMaxLength(512);

                entity.Property(e => e.UtilityId)
                    .IsRequired()
                    .HasColumnName("utilityid")
                    .HasMaxLength(36);
            });

            modelBuilder.Entity<WaterHeater>(entity =>
            {
                entity.HasKey(e => e.WaterHeaterId)
                    .HasName("PRIMARY");

                entity.ToTable("waterheaters");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.WaterHeaterId)
                    .IsRequired()
                    .HasColumnName("waterheaterid")
                    .HasMaxLength(36);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(16);

            });

            modelBuilder.Entity<WaterHeaterReading>(entity =>
            {
                entity.HasKey(e => e.WaterHeaterReadingId)
                    .HasName("PRIMARY");

                entity.ToTable("waterheaterreadings");

                entity.HasIndex(e => e.WaterHeaterId)
                    .HasName("waterheaterid");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");
                
                entity.HasIndex(e => e.Time)
                    .HasName("timestamp");
                
                entity.Property(e => e.WaterHeaterReadingId)
                    .IsRequired()
                    .HasColumnName("waterheaterreadingid")
                    .HasMaxLength(36);

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .HasMaxLength(24);

                entity.Property(e => e.WaterHeaterId)
                    .IsRequired()
                    .HasColumnName("waterheaterid")
                    .HasMaxLength(36);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);

                entity.Property(e => e.Status).HasColumnName("status");
                
                entity.Property(e => e.SetPoint).HasColumnName("setpoint");

                entity.Property(e => e.MinSetPoint).HasColumnName("minsetpoint");

                entity.Property(e => e.MaxSetPoint).HasColumnName("maxsetpoint");

                entity.Property(e => e.UpperTemperature).HasColumnName("uppertemperature");

                entity.Property(e => e.LowerTemperature).HasColumnName("lowertemperature");
                
                entity.Property(e => e.AmbientTemperature).HasColumnName("ambienttemperature");

                entity.Property(e => e.InUse)
                    .IsRequired()
                    .HasColumnName("inuse")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'False'");

                entity.Property(e => e.VacationMode)
                    .IsRequired()
                    .HasColumnName("vacationmode")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'False'");

                entity.Property(e => e.TemperatureUnits)
                    .IsRequired()
                    .HasColumnName("temperatureunits")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("'F'");
                
            });

            modelBuilder.Entity<SolarPv>(entity =>
            {
                entity.HasKey(e => e.SolarPvId)
                    .HasName("PRIMARY");

                entity.ToTable("solarpvs");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.SolarPvId)
                    .IsRequired()
                    .HasColumnName("solarpvid")
                    .HasMaxLength(36);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);

                entity.Property(e => e.HouseholdId)
                    .IsRequired()
                    .HasColumnName("householdid")
                    .HasMaxLength(36);

            });

            modelBuilder.Entity<SolarPvReading>(entity => 
            {
                entity.HasKey(e => e.SolarPvReadingId)
                    .HasName("PRIMARY");
                
                entity.ToTable("solarpvreadings");

                entity.HasIndex(e => e.SiteId)
                    .HasName("siteid");
                
                entity.HasIndex(e => e.SolarPvId)
                    .HasName("solarpvid");
                
                entity.HasIndex(e => e.Time)
                    .HasName("timestamp");
                
                entity.Property(e => e.SolarPvReadingId)
                    .IsRequired()
                    .HasColumnName("solarpvreadingid")
                    .HasMaxLength(36);

                entity.Property(e => e.SolarPvId)
                    .IsRequired()
                    .HasColumnName("solarpvid")
                    .HasMaxLength(36);
                
                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteid")
                    .HasMaxLength(36);
                
                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .HasMaxLength(36);
                
                entity.Property(e => e.EnergyValue)
                    .HasColumnName("energyvalue")
                    .HasMaxLength(20);
                
                entity.Property(e => e.EnergyMeterId)
                    .HasColumnName("energymeterid")
                    .HasMaxLength(20);
                
                entity.Property(e => e.EnergyMeterConsumption)
                    .HasColumnName("energymeterconsumption")
                    .HasMaxLength(20);

                entity.Property(e => e.EnergyMeterPurchased)
                    .HasColumnName("energymeterpurchased")
                    .HasMaxLength(20);
                               
                entity.Property(e => e.EnergyMeterProduction)
                    .HasColumnName("energymeterproduction")
                    .HasMaxLength(20);

                entity.Property(e => e.EnergyMeterSelfConsumption)
                    .HasColumnName("energymeterselfconsumption")
                    .HasMaxLength(20);

                entity.Property(e => e.EnergyMeterFeedIn)
                    .HasColumnName("energymeterfeedin")
                    .HasMaxLength(20);

                entity.Property(e => e.PowerValue)
                    .HasColumnName("powervalue")
                    .HasMaxLength(20);
                
                entity.Property(e => e.PowerMeterId)
                    .HasColumnName("powermeterid")
                    .HasMaxLength(20);
                
                entity.Property(e => e.PowerMeterConsumption)
                    .HasColumnName("powermeterconsumption")
                    .HasMaxLength(20);

                entity.Property(e => e.PowerMeterPurchased)
                    .HasColumnName("powermeterpurchased")
                    .HasMaxLength(20);

                entity.Property(e => e.PowerMeterProduction)
                    .HasColumnName("powermeterproduction")
                    .HasMaxLength(20);

                entity.Property(e => e.PowerMeterSelfConsumption)
                    .HasColumnName("powermeterselfconsumption")
                    .HasMaxLength(20);

                entity.Property(e => e.PowerMeterFeedIn)
                    .HasColumnName("powermeterfeedin")
                    .HasMaxLength(20);

                entity.Property(e => e.StorageValue)
                    .HasColumnName("storagevalue")
                    .HasMaxLength(20);
                
                entity.Property(e => e.StorageMeterId)
                    .HasColumnName("storagemeterid")
                    .HasMaxLength(20);
                
                entity.Property(e => e.StorageMeterConsumption)
                    .HasColumnName("storagemeterconsumption")
                    .HasMaxLength(20);

                entity.Property(e => e.StorageMeterPurchased)
                    .HasColumnName("storagemeterpurchased")
                    .HasMaxLength(20);
               
                entity.Property(e => e.StorageMeterProduction)
                    .HasColumnName("storagemeterproduction")
                    .HasMaxLength(20);

                entity.Property(e => e.StorageMeterSelfConsumption)
                    .HasColumnName("storagemeterselfconsumption")
                    .HasMaxLength(20);

                entity.Property(e => e.StorageMeterFeedIn)
                    .HasColumnName("storagemeterfeedin")
                    .HasMaxLength(20);                
            });

            modelBuilder.Entity<PricingSignals>(entity =>
            {
                entity.HasKey(e => e.PricingSignalId)
                    .HasName("PRIMARY");

                entity.ToTable("pricingsignals");

                entity.HasIndex(e => e.PricingSignalId)
                    .HasName("siteid");

                entity.HasIndex(e => e.Time)
                    .HasName("timestamp");

                entity.Property(e => e.PricingSignalId)
                    .IsRequired()
                    .HasColumnName("pricingsignalid")
                    .HasMaxLength(36);

                entity.Property(e => e.EventId)
                    .IsRequired()
                    .HasColumnName("eventid")
                    .HasMaxLength(36);

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .HasMaxLength(20);

                entity.Property(e => e.MarketContext)
                    .IsRequired()
                    .HasColumnName("marketcontext")
                    .HasMaxLength(32);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("createddatetime")
                    .HasMaxLength(20);

                entity.Property(e => e.DtStart)
                    .IsRequired()
                    .HasColumnName("dtstart")
                    .HasMaxLength(20);

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasMaxLength(8);

                entity.Property(e => e.StartAfter)
                    .HasColumnName("startafter")
                    .HasMaxLength(8);

                entity.Property(e => e.SignalValue)
                    .HasColumnName("signalvalue")
                    .HasColumnType("float");

                entity.Property(e => e.SignalIntervalText)
                    .HasColumnName("signalintervaltext")
                    .HasMaxLength(32);

                entity.Property(e => e.SignalIntervalStartDate)
                    .HasColumnName("signalintervalstartdate")
                    .HasMaxLength(20);

                entity.Property(e => e.SignalIntervalDuration)
                    .HasColumnName("signalintervalduration")
                    .HasMaxLength(20);

                entity.Property(e => e.SignalIntervalPayloadValue)
                    .HasColumnName("signalintervalpayloadvalue")
                    .HasColumnType("float");

                entity.Property(e => e.SignalDescriptionNumber)
                    .HasColumnName("signaldescriptionnumber");

                entity.Property(e => e.SignalScaleCode)
                    .HasColumnName("signalscalecode");

                entity.Property(e => e.SignalId)
                    .HasColumnName("signalid")
                    .HasMaxLength(36);

                entity.Property(e => e.SignalName)
                    .HasColumnName("signalname")
                    .HasMaxLength(16);

                entity.Property(e => e.SignalType)
                    .HasColumnName("signaltype");

            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
