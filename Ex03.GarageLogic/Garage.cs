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
            float energyVolume = float.Parse(i_VehicleDetail[3]);
            string tireModel = i_VehicleDetail[4];
            int AirPressure = int.Parse(i_VehicleDetail[5]);
            string ownerName = i_VehicleDetail[6];
            string ownerPhone = i_VehicleDetail[7];

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

            if (vehicleType == "FuelCar" || vehicleType == "ElectricCar")
            {
                Car car = newVehicle as Car; // Safe casting ask ori // if the cast fails, car will be null
                if (car != null)
                {
                    GarageDetailsValidator.CarPartsValidatorAndAssignment(car, i_VehicleDetail[8], i_VehicleDetail[9]);
                }

                if(vehicleType == "FuelCar")
                {
                    FuelCar fuelCar = newVehicle as FuelCar;
                    fuelCar.RefillEnergyLevel(energyVolume);
                }
                else // Electric Car
                {
                    ElectricCar electricCar = newVehicle as ElectricCar;
                    electricCar.RefillEnergyLevel(energyVolume);
                }
            }
            else if (vehicleType == "FuelMotorcycle" || vehicleType == "ElectricMotorcycle")
            {
                Motorcycle motorcycle = newVehicle as Motorcycle; // Direct cast // throws exeption if the cast fails!!!!!!!!!!
                if (motorcycle != null)
                {
                    GarageDetailsValidator.MotorcyclePartsValidatorAndAssignment(motorcycle, i_VehicleDetail[8], i_VehicleDetail[9]);
                }

                if (vehicleType == "FuelMotorcycle")
                {
                    FuelMotorcycle fuelMotorcycle = newVehicle as FuelMotorcycle;
                    fuelMotorcycle.RefillEnergyLevel(energyVolume);
                }
                else // Electric Motorcycle
                {
                    ElectricMotorcycle electricMotorcycle = newVehicle as ElectricMotorcycle;
                    electricMotorcycle.RefillEnergyLevel(energyVolume);
                }
            }
            else if (vehicleType == "Truck")
            {
                Truck truck = newVehicle as Truck; 
                if (truck != null)
                {
                    GarageDetailsValidator.TruckPartsValidatorAndAssignment(truck, i_VehicleDetail[8], i_VehicleDetail[9]);
                }

                truck.RefillEnergyLevel(energyVolume);
            }

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
                new ArgumentException("No vehicles found with the selected license plate.");
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
                new ArgumentException("No vehicles found with the selected license plate.");
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

                if (vehicle is FuelCar)
                {
                    if (i_FuelType != eFuelType.Octan95)
                    {
                        throw new ArgumentException("Oops you can't refuel with this type of fuel");
                    }

                    (vehicle as FuelCar).RefillEnergyLevel(i_FuelAmount);
                }
                else if (vehicle is FuelMotorcycle)
                {
                    if (i_FuelType != eFuelType.Octan98)
                    {
                        throw new ArgumentException("Oops you can't refuel with this type of fuel");
                    }

                    (vehicle as FuelMotorcycle).RefillEnergyLevel(i_FuelAmount);
                }
                else if (vehicle is Truck)
                {
                    if (i_FuelType != eFuelType.Soler)
                    {
                        throw new ArgumentException("Oops you can't refuel with this type of fuel");
                    }

                    (vehicle as Truck).RefillEnergyLevel(i_FuelAmount);
                }
                else
                {
                    throw new ArgumentException("This vehicle can't refuel");
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

                if (vehicle is ElectricCar)
                {
                    (vehicle as ElectricCar).RefillEnergyLevel(hoursToFill);
                }
                else if (vehicle is ElectricMotorcycle)
                {
                    (vehicle as ElectricMotorcycle).RefillEnergyLevel(hoursToFill);
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
