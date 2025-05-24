using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private const float k_MaxFuelAmount = 5.8f;

        private FuelEngine m_Engine = new FuelEngine(eFuelType.Octan98, k_MaxFuelAmount);
        public FuelEngine Engine
        {
            get { return m_Engine; }
        }

        public FuelMotorcycle(string i_LicenseID, string i_ModelName) : base(i_ModelName, i_LicenseID){}

        public override float CalculateExactEnergyAmount(float i_EnergyPrecentage)
        {
            float exactEnergyAmount = (i_EnergyPrecentage / 100) * k_MaxFuelAmount;
            return exactEnergyAmount;
        }

        public override void RefillEnergy(float i_EnergyAmount)
        {
            m_Engine.Refuel(this, i_EnergyAmount, eFuelType.Octan98);
        }
        public override bool Fuelable(eFuelType i_fuelType)
        {
            if (m_Engine.FuelType != i_fuelType)
            {
                throw new ArgumentException("Invalid fuel type");
            }

            return true;
        }

        public override bool Chargeable()
        {
            return false;
        }
    }
}
