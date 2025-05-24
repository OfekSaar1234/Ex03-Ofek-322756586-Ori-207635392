using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string Manufacturer { get; set; }
        public float CurrentAirPreasure { get; set; }
        public float MaxAirPreasure { get; set; }

        public void Inflate()
        {
            CurrentAirPreasure = MaxAirPreasure;
        }
    }
}
