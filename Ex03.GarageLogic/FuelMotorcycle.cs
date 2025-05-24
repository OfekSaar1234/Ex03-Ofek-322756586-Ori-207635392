using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle, IRefillEnergy
    {
        private const float k_MaxFuelAmount = 5.8f;

        private FuelEngine m_Engine = new FuelEngine(eFuelType.Octan98, k_MaxFuelAmount);
        public FuelEngine Engine
        {
            get { return m_Engine; }
        }

        public FuelMotorcycle(string i_LicenseID, string i_ModelName) : base(i_ModelName, i_LicenseID){}

        public void RefillEnergyLevel(float i_EnergyAmount)
        {
            m_Engine.Refuel(this, i_EnergyAmount, eFuelType.Octan98);
        }
    }
}
