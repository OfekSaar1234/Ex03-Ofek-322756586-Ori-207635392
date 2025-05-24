using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public sealed class FuelEngine
    {
        public eFuelType FuelType { get; set; }
        public float FuelAmount { get; set; }
        public float MaxFuelAmount { get; set; }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }

        public FuelEngine(eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            FuelType = i_FuelType;
            MaxFuelAmount = i_MaxFuelAmount;
        }

        public void Refuel(Vehicle i_Vehicle, float i_FuelAmount, eFuelType i_FuelType)
        {
            if (i_FuelType != FuelType)
            {
                throw new ArgumentException("Fuel amount to add cannot be negative");
            }

            if (i_FuelAmount < 0)
            {
                throw new ValueRangeException("Fuel amount to add cannot be negative");
            }

            if (FuelAmount + i_FuelAmount > MaxFuelAmount)
            {
                throw new ValueRangeException("Fuel amount exceeds maximum capacity");
            }

            FuelAmount += i_FuelAmount;
            i_Vehicle.CurrentEnergyLevel = FuelAmount / MaxFuelAmount;
        }
    }
}
