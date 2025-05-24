using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryHours = 3.2f;

        private ElectricBattery m_Battery = new ElectricBattery(k_MaxBatteryHours);
        public ElectricBattery Battery
        {
            get { return m_Battery; }
        }

        public ElectricMotorcycle(string i_LicenseID, string i_ModelName) : base(i_ModelName, i_LicenseID) { }

        public override float CalculateExactEnergyAmount(float i_EnergyPrecentage)
        {
            float exactEnergyAmount = (i_EnergyPrecentage / 100) * k_MaxBatteryHours;
            return exactEnergyAmount;
        }

        public override void RefillEnergy(float i_EnergyAmount)
        {
            m_Battery.Recharge(this, i_EnergyAmount);
        }

        public override bool Fuelable(FuelEngine.eFuelType i_fuelType)
        {
            return false;
        }

        public override bool Chargeable()
        {
            return true;
        }
    }
}
