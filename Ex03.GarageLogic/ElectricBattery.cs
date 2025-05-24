using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public sealed class ElectricBattery
    {
        public float RemainingBatteryHours { get; set; }
        public float MaxBatteryHours { get; set;}
        public ElectricBattery(float i_MaxBatteryHours)
        {
            MaxBatteryHours = i_MaxBatteryHours;
        }
        public void Recharge(Vehicle vehicle, float i_ChargingHours)
        {
            if (i_ChargingHours < 0)
            {
                throw new ValueRangeException("Charging hours must be positive");
            }

            if (RemainingBatteryHours + i_ChargingHours > MaxBatteryHours)
            {
                throw new ValueRangeException("Charging hours exceed max battery hours");
            }

            RemainingBatteryHours += i_ChargingHours;
            vehicle.CurrentEnergyLevel = RemainingBatteryHours / MaxBatteryHours;
        }
    }
}
