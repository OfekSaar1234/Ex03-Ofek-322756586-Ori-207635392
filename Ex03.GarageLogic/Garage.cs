using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.Motorcycle;
using static Ex03.GarageLogic.ImpoundedVehicle;
using static Ex03.GarageLogic.FuelEngine;
using Ex03.GarageLogic;


namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, ImpoundedVehicle> r_Vehicles
            = new Dictionary<string, ImpoundedVehicle>();

        public bool IsVehicleExist (string i_LicenseID)
        {
            return r_Vehicles.ContainsKey(i_LicenseID);
        }

        public void AddNewVehicle(string[] i_VehicleDetail)
        {
            string vehicleType = i_VehicleDetail[0];
            string licensePlate = i_VehicleDetail[1];
            string modelName = i_VehicleDetail[2];
            float energyVolume = float.Parse(i_VehicleDetail[3]); // energy precentage
            string tireModel = i_VehicleDetail[4];
            int AirPressure = int.Parse(i_VehicleDetail[5]);
            string ownerName = i_VehicleDetail[6];
            string ownerPhone = i_VehicleDetail[7];
            string extraDetail1 = i_VehicleDetail[8];
            string extraDetail2 = i_VehicleDetail[9];

            GarageDetailsValidator.VehicleTypeValidator(vehicleType); // decide if exception or bool
            GarageDetailsValidator.LicensePlateNumberValidator(licensePlate); // decide if exception or bool
            GarageDetailsValidator.ValidateOwnerName(ownerName); // decide if exception or bool
            GarageDetailsValidator.ValidateOwnerPhone(ownerPhone); // decide if exception or bool

            Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);

            GarageDetailsValidator.ValidateWheelsAirPreasure(newVehicle, AirPressure);

            foreach (Wheel wheel in newVehicle.Wheels)
            {
                wheel.Manufacturer = tireModel;
                wheel.CurrentAirPreasure = AirPressure;  //Exeption if the value is out of range!!!!!!!!!!!!!!!!!!!!!!!!!!
            }

            float energyPrecentage = newVehicle.CalculateExactEnergyAmount(energyVolume);//(recognise specific vehicle and calculate exact liters for engine or hours for battery)
            newVehicle.RefillEnergy(energyPrecentage);
            newVehicle.PartsValidatorAndAssignment(extraDetail1, extraDetail2);

            ImpoundedVehicle impoundedNewVehicleDetails = new ImpoundedVehicle(ownerName, ownerPhone, eVehicleStatus.InRepair, newVehicle); // Assuming you create an instance

            if (!r_Vehicles.ContainsKey(licensePlate))
            {
                r_Vehicles.Add(licensePlate, impoundedNewVehicleDetails);
            }
        }

        public void FindLicensePlate(string i_LicenseID, out ImpoundedVehicle o_Details)
        {
            r_Vehicles.TryGetValue(i_LicenseID, out o_Details);
        }

        public List<string> GetLicensePlatesByStatus(eVehicleStatus i_Status)
        {
            List<string> licensePlates = new List<string>();
            foreach (KeyValuePair<string, ImpoundedVehicle> vehicle in r_Vehicles)
            {
                if (vehicle.Value.Status == i_Status)
                {
                    licensePlates.Add(vehicle.Key);
                }
            }

            return licensePlates;
        }

        public void ChangeVehicleStatus(string i_LicensePlate, eVehicleStatus i_NewStatus)
        {
            ImpoundedVehicle impoundedVehicle;
            FindLicensePlate(i_LicensePlate, out impoundedVehicle);
            if (impoundedVehicle != null)
            {
                impoundedVehicle.Status = i_NewStatus;
            }
            else
            {
                throw new ArgumentException("No vehicles found with the selected license plate.");
            }
        }

        public void InflateTires(string i_LicensePlate)
        {
            ImpoundedVehicle impoundedVehicle;
            FindLicensePlate(i_LicensePlate, out impoundedVehicle);
            if (impoundedVehicle != null)
            {
                impoundedVehicle.Vehicle.InflateWheels();
            }
            else
            {
                throw new ArgumentException("No vehicles found with the selected license plate.");
            }
        }

        public void RefuelVehicle(string i_LicensePlate, eFuelType i_FuelType, float i_FuelAmount) 
        {
            ImpoundedVehicle impoundedVehicle;
            FindLicensePlate(i_LicensePlate, out impoundedVehicle);
            Vehicle vehicle;

            if (impoundedVehicle != null)
            {
                vehicle = impoundedVehicle.Vehicle;

                if(vehicle.Fuelable(i_FuelType))
                {
                    vehicle.RefillEnergy(i_FuelAmount);
                }
                else
                {
                    throw new ArgumentException("Inserted electric vehicle to refuel");
                }
            }
            else
            {
                throw new ArgumentException("No vehicles found with the selected license plate.");
            }
        }

        public void RechargeVehicle(string i_LicensePlate, float i_MinutesAmount)
        {
            ImpoundedVehicle impoundedVehicle;
            FindLicensePlate(i_LicensePlate, out impoundedVehicle);
            Vehicle vehicle;

            if (impoundedVehicle != null)
            {
                float hoursToFill = i_MinutesAmount / 60;
                vehicle = impoundedVehicle.Vehicle;

                if (vehicle.Chargeable())
                {
                    vehicle.RefillEnergy(hoursToFill);
                }
                else
                {
                    throw new ArgumentException("Inserted fuel vehicle to recharge");
                }
            }
            else
            {
                throw new ArgumentException("No vehicles found with the selected license plate.");
            }
        }

        public void ShowAllDetailsOfSpecificVehicle(string i_LicensePlate)
        {

            ImpoundedVehicle impoundedVehicle;
            FindLicensePlate(i_LicensePlate, out impoundedVehicle);

            if (impoundedVehicle != null)
            {
                Console.WriteLine(impoundedVehicle.ToString());
            }
            else
            {
                throw new ArgumentException("No vehicles found with the selected license plate.");
            }
        }
    }
}
