using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumOfWheels = 2;
        private const int k_MaxAirPreasure = 30;

        public eLicenseType LicenseType { get; set; }
        public int EngineCapacity { get; set; }

        public enum eLicenseType
        {
            A,
            A2,
            AB,
            B2,
            B3
        }

        public Motorcycle(string i_LicenseID, string i_ModelName) : base(i_ModelName, i_LicenseID, k_NumOfWheels, k_MaxAirPreasure)
        {
        }

        public abstract override float CalculateExactEnergyAmount(float i_EnergyPrecentage);
        public abstract override void RefillEnergy(float i_EnergyPrecentage);
        public abstract override bool Fuelable(eFuelType i_fuelType);
        public abstract override bool Chargeable();

        public override void PartsValidatorAndAssignment(string i_Detail1, string i_Detail2)
        {
            GarageDetailsValidator.MotorcyclePartsValidatorAndAssignment(this, i_Detail1, i_Detail2);
        }
    }
}
