using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ImpoundedVehicle
    {
        private readonly Vehicle r_Vehicle; // The vehicle that is impounded
        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }

        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public eVehicleStatus Status { get; set; }

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Paid,
        }

        public ImpoundedVehicle(string i_OwnerName, string i_OwnerPhone, eVehicleStatus i_Status, Vehicle i_Vehicle)
        {
            r_Vehicle = i_Vehicle;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhone;
            Status = i_Status;
        }

        public override string ToString()
        {
            Wheel wheel = r_Vehicle.Wheels[0]; // All wheels are the same, so we can take the first one

            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.AppendLine($"License Plate Number: {r_Vehicle.LicensePlateNumber}");
            vehicleInfo.AppendLine($"Model Name: {r_Vehicle.ModulName}");
            vehicleInfo.AppendLine($"Owner Name: {OwnerName} Owner Phone: {OwnerPhoneNumber}");
            vehicleInfo.AppendLine($"Vehicle Status: {Status}");
            vehicleInfo.Append($"Wheels info: Manufacturer - {wheel.Manufacturer}, Max Air Preasure - {wheel.MaxAirPreasure}, ");
            vehicleInfo.AppendLine($"Current Air Preasure - {wheel.CurrentAirPreasure}");
            vehicleInfo.AppendLine($"Vehicle Type: {r_Vehicle.GetType().Name}");

            if(r_Vehicle is Car)
            {
                Car car = r_Vehicle as Car;

                vehicleInfo.AppendLine($"Number of doors : {car.DoorAmount}, Color: {car.Color}");

                if (car is FuelCar)
                {
                    FuelCar fuelCar = car as FuelCar;
                    vehicleInfo.Append($"Fuel Max Liters : {fuelCar.Engine.MaxFuelAmount}, Remaining Liters: {fuelCar.Engine.FuelAmount}, ");
                    vehicleInfo.AppendLine($"Fuel Type: {fuelCar.Engine.FuelType}");
                }
                else if (car is ElectricCar)
                {
                    ElectricCar electricCar = car as ElectricCar;
                    vehicleInfo.Append($"Battery Max Hours : {electricCar.Battery.MaxBatteryHours}, ");
                    vehicleInfo.AppendLine($"Remaining Hours: {electricCar.Battery.RemainingBatteryHours}");
                }
            }
            else if (r_Vehicle is Motorcycle)
            {
                Motorcycle motorcycle = r_Vehicle as Motorcycle;

                vehicleInfo.AppendLine($"License Type : {motorcycle.LicenseType}, Engine capacity: {motorcycle.EngineCapacity}");

                if (motorcycle is FuelMotorcycle)
                {
                    FuelMotorcycle fuelMotorcycle = motorcycle as FuelMotorcycle;
                    vehicleInfo.Append($"Fuel Max Liters : {fuelMotorcycle.Engine.MaxFuelAmount}, Remaining Liters: {fuelMotorcycle.Engine.FuelAmount}, ");
                    vehicleInfo.AppendLine($"Fuel Type: {fuelMotorcycle.Engine.FuelType}");
                }
                else if (motorcycle is ElectricMotorcycle)
                {
                    ElectricMotorcycle electricMotorcycle = r_Vehicle as ElectricMotorcycle;
                    vehicleInfo.Append($"Battery Max Hours : {electricMotorcycle.Battery.MaxBatteryHours}, ");
                    vehicleInfo.AppendLine($"Remaining Hours: {electricMotorcycle.Battery.RemainingBatteryHours}");
                }
            }
            else if (r_Vehicle is Truck)
            {
                Truck truck = r_Vehicle as Truck;

                vehicleInfo.AppendLine($"Conatins Hazard : {truck.ContainHazard}, Cargo Volume : {truck.CargoVolume}");
                vehicleInfo.Append($"Fuel Max Liters : {truck.Engine.MaxFuelAmount}, Remaining Liters: {truck.Engine.FuelAmount}, ");
                vehicleInfo.AppendLine($"Fuel Type: {truck.Engine.FuelType}");
            }

            return vehicleInfo.ToString();
        }
    }
}
