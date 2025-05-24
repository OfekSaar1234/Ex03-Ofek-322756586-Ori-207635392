using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car, IRefillEnergy
    {
        private const float k_MaxBatteryHours = 4.8f;

        private ElectricBattery m_Battery = new ElectricBattery(k_MaxBatteryHours);
        public ElectricBattery Battery
        {
            get { return m_Battery; }
        }

        public ElectricCar(string i_LicenseID, string i_ModelName) : base(i_ModelName, i_LicenseID) { }

        public void RefillEnergyLevel(float i_EnergyAmount)
        {
            m_Battery.Recharge(this, i_EnergyAmount);
        }
    }
}
