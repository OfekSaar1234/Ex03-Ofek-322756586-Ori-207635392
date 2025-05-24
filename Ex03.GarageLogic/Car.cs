using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
