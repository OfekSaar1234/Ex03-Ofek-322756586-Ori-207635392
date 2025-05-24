using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private const int k_NumOfWheels = 5;
        private const int k_MaxAirPreasure = 32;

        public eColor Color { get; set; }
        public int DoorAmount { get; set; }
        public enum eColor
        {
            Yellow,
            Black,
            White,
            Silver
        }

        public Car(string i_LicenseID, string i_ModelName) : base(i_ModelName, i_LicenseID, k_NumOfWheels, k_MaxAirPreasure)
        {
        }
        public abstract override float CalculateExactEnergyAmount(float i_EnergyPrecentage);
        public abstract override void RefillEnergy(float i_EnergyPrecentage);
        public abstract override bool Fuelable(eFuelType i_fuelType);
        public abstract override bool Chargeable();
        public override void PartsValidatorAndAssignment(string i_Detail1, string i_Detail2)
        {
            GarageDetailsValidator.CarPartsValidatorAndAssignment(this, i_Detail1, i_Detail2);
        }


    }
}
