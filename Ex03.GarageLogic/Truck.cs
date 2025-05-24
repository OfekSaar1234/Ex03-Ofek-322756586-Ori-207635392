using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle, IRefillEnergy
    {
        private const int k_NumOfWheels = 12;
        private const int k_MaxAirPreasure = 27;
        private const float k_MaxFuelAmount = 135f;

        private FuelEngine m_Engine = new FuelEngine(eFuelType.Soler, k_MaxFuelAmount);
        public FuelEngine Engine
        {
            get { return m_Engine; }
        }

        public bool ContainHazard { get; set; }
        public float CargoVolume { get; set; }

        public Truck(string i_LicenseID, string i_ModelName) : base(i_ModelName, i_LicenseID, k_NumOfWheels, k_MaxAirPreasure)
        {
        }

        public void RefillEnergyLevel(float i_EnergyAmount)
        {
            m_Engine.Refuel(this, i_EnergyAmount, eFuelType.Soler);
        }
    }
}
