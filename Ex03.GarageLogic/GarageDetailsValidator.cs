using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.Motorcycle;
using static Ex03.GarageLogic.ImpoundedVehicle;


namespace Ex03.GarageLogic
{
    public class GarageDetailsValidator
    {
        public static void CarPartsValidatorAndAssignment(Car car, string i_Detail1, string i_Detail2)
        {
            if (Enum.TryParse(i_Detail1, out eColor o_Color))
            {
                car.Color = o_Color;
            }
            else
            {
                throw new ArgumentException("Invalid color value.");
            }

            if (int.TryParse(i_Detail2, out int o_DoorAmount))
            {
                car.DoorAmount = o_DoorAmount;
            }
            else
            {
                throw new ArgumentException("Invalid Door Amount value.");
            }
        }

        public static void MotorcyclePartsValidatorAndAssignment(Motorcycle motorcycle, string i_Detail1, string i_Detail2)
        {
            if (Enum.TryParse(i_Detail1, out eLicenseType o_LicenseType))
            {
                motorcycle.LicenseType = o_LicenseType;
            }
            else
            {
                throw new ArgumentException("Invalid color value.");
            }

            if (int.TryParse(i_Detail2, out int o_EngineCapacity))
            {
                motorcycle.EngineCapacity = o_EngineCapacity;
            }
            else
            {
                throw new ArgumentException("Invalid Door Amount value.");
            }
        }

        public static void TruckPartsValidatorAndAssignment(Truck truck, string i_Detail1, string i_Detail2)
        {
            if (bool.TryParse(i_Detail1, out bool o_ContainHazard))
            {
                truck.ContainHazard = o_ContainHazard;
            }
            else
            {
                throw new ArgumentException("Invalid color value.");
            }

            if (float.TryParse(i_Detail2, out float o_CargoVolume))
            {
                truck.CargoVolume = o_CargoVolume;
            }
            else
            {
                throw new ArgumentException("Invalid Door Amount value.");
            }
        }

        public static bool LicensePlateNumberValidator(string i_LicensPlate)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(i_LicensPlate))
            {
                valid = false;
            }

            string[] parts = i_LicensPlate.Split('-');

            if (parts.Length != 3)
            {
                valid = false;
            }
            else if (parts[0].Length != 2 || parts[1].Length != 3 || parts[2].Length != 2)
            {
                valid = false;
            }

            foreach (string part in parts)
            {
                if (valid == false)
                {
                    break;
                }
                foreach (char c in part)
                {
                    if (!char.IsDigit(c))
                    {
                        valid = false;
                        break;
                    }
                }
            }
            return valid;
        }

        public static bool ValidateOwnerName(string i_OwnerName)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(i_OwnerName))
            {
                isValid = false;
            }

            foreach (char c in i_OwnerName)
            {
                if(!char.IsLetter(c))
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

        public static bool ValidateOwnerPhone(string i_OwnerPhone)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(i_OwnerPhone))
            {
                isValid = false;
            }

            foreach (char c in i_OwnerPhone)
            {
                if (!char.IsDigit(c))
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

        public static void ValidateWheelsAirPreasure(Vehicle i_Vehicle, int i_AirPressure)
        {
            if (i_AirPressure < 0 || i_AirPressure >i_Vehicle.Wheels[0].MaxAirPreasure)
            {
                throw ValueRangeException();
            }
        }

        public static void VehicleTypeValidator(string i_VehicleType)
        {
            if (!VehicleCreator.SupportedTypes.Contains(i_VehicleType))
            {
                throw new ArgumentException("Invalid Vehicle Type");
            }

        }

        public static void ValidateVehicleStatus(string i_VehicleStatus, out eVehicleStatus o_Status)
        {
            if (!Enum.TryParse(i_VehicleStatus, out o_Status))
            {
                throw new ArgumentException("Invalid Vehicle Status");
            }   
        }
    }
}
