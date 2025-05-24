using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly List<Wheel> r_Wheels;
        public List<Wheel> Wheels
        {
            get { return r_Wheels; }
        }

        private readonly string m_ModulName;
        public string ModulName
        {
            get { return m_ModulName; }
        }

        private readonly string m_LicensePlateNumber;
        public string LicensePlateNumber
        {
            get { return m_LicensePlateNumber; }
        }

        public float CurrentEnergyLevel { get; set; } // for electric vehicles or fuel vehicles

        public Vehicle(string i_Modul, string i_LicensePlate, int i_WheelAmount, int i_MaxWheelAirPreasue)
        {
            r_Wheels = new List<Wheel>(i_WheelAmount);
            for (int i = 0; i < i_WheelAmount; i++) 
            {
                Wheel wheel = new Wheel();
                wheel.MaxAirPreasure = i_MaxWheelAirPreasue;
                r_Wheels.Add(wheel);
            }

            m_ModulName = i_Modul;
            m_LicensePlateNumber =  i_LicensePlate;
        }

        public void InflateWheels()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.Inflate();
            }
        }
    }
}
