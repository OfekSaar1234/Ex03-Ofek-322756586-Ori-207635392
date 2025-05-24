using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
