using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
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

        public Truck(string i_LicenseID, string i_ModelName) : base(i_ModelName, i_LicenseID, k_NumOfWheels, k_MaxAirPreasure) { }


        public override float CalculateExactEnergyAmount(float i_EnergyPrecentage)
        {
            float exactEnergyAmount = (i_EnergyPrecentage / 100) * k_MaxFuelAmount;
            return exactEnergyAmount;
        }
        public override void RefillEnergy(float i_EnergyPrecentage)
        {
            m_Engine.Refuel(this, i_EnergyPrecentage, eFuelType.Soler);
        }
        public override bool Fuelable(eFuelType i_fuelType)
        {
            if( m_Engine.FuelType != i_fuelType)
            {
                throw new ArgumentException("Invalid fuel type");
            }

            return true;
        }

        public override bool Chargeable()
        {
           
            return false;
        }
        public override void PartsValidatorAndAssignment(string i_Detail1, string i_Detail2)
        {
            GarageDetailsValidator.TruckPartsValidatorAndAssignment(this, i_Detail1, i_Detail2);
        }
    }
}
