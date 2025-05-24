using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.ImpoundedVehicle;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.ConsoleUI
{
    public class GarageManagmentSystem
    {
        private Garage m_Garage = new Garage();

        public void ChooseOptionFromMenu()
        {
            int choice = Menu.ShowMainMenu();
            while(choice != 9)
            {
                HandleUserChoice(choice);
                choice = Menu.ShowMainMenu();

            }
            Console.WriteLine("Exiting the Garage Management System. Goodbye!");
        }

        private void HandleUserChoice(int i_Choice)
        {
            string licensePlate;
            switch (i_Choice)
            {
                case 1:
                    addAllVehicles();
                    Console.WriteLine($"All vehicles have been loaded successfully.");
                    
                    break;
                case 2:
                    try
                    {
                        addNewVehicleFromUser();
                        Console.WriteLine("Vehicle has been added successfully.");
                    }
                    catch(ArgumentException ae)
                    {
                        Console.WriteLine($"Error: {ae.Message}"); //EDIT
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine("Invalid input format. Please try again.");
                    }
                    catch (ValueRangeException vre)
                    {
                        Console.WriteLine($": {vre.Message}"); //EDIT
                    }
                    break;
                case 3:
                    showAllChosenVehiclesLicensePlates();
                    break;
                case 4:
                    Console.WriteLine("Please enter the new required status");
                    string statusAnswer = Console.ReadLine();
                    GarageDetailsValidator.ValidateVehicleStatus(statusAnswer, out eVehicleStatus status);

                    Console.WriteLine("Please enter the licensePlate");
                    licensePlate = Console.ReadLine();
                    try
                    {
                        m_Garage.ChangeVehicleStatus(licensePlate, status);
                        Console.WriteLine($"Vehicle with license plate {licensePlate} has been changed to {status} status successfully.");
                    }
                    catch(ArgumentException ae)
                    {
                        Console.WriteLine($"Error: {ae.Message}"); //EDIT
                    }
                    break;
                case 5:
                    Console.WriteLine("Please enter the licensePlate");
                    licensePlate = Console.ReadLine();
                    try
                    {
                        m_Garage.InflateTires(licensePlate);
                        Console.WriteLine($"Tires of vehicle with license plate {licensePlate} have been inflated successfully.");
                    }
                    catch(ArgumentException ae)
                    {
                        Console.WriteLine($"Error: {ae.Message}"); //EDIT
                    }
                    break;
                case 6:
                    Console.WriteLine("Please enter the license plate number");
                    licensePlate = Console.ReadLine(); 

                    Console.WriteLine("Please enter the fuel type");
                    Enum.TryParse(Console.ReadLine(), out eFuelType fuelType);

                    Console.WriteLine("Please enter the fuel amount");
                    float fuelAmount = float.Parse(Console.ReadLine());

                    try
                    {
                        m_Garage.RefuelVehicle(licensePlate, fuelType, fuelAmount);
                        Console.WriteLine($"Vehicle with license plate {licensePlate} has been refueled successfully.");
                    }
                    catch(ArgumentException ae)
                    {
                        Console.WriteLine($"Error: {ae.Message}"); //EDIT
                    }
                    break;
                case 7:
                    Console.WriteLine("Please enter the license plate of the vehicle you want to recharge: ");
                    licensePlate = Console.ReadLine();

                    Console.WriteLine("Please enter the amount of minutes to recharge: ");
                    float minutesAmount = float.Parse(Console.ReadLine());

                    try
                    {
                        m_Garage.RechargeVehicle(licensePlate, minutesAmount);
                        Console.WriteLine($"Vehicle with license plate {licensePlate} has been recharged successfully.");
                    }
                    catch(ArgumentException ae)
                    {
                        Console.WriteLine($"Error: {ae.Message}"); //EDIT
                    }
                    break;
                case 8:
                    Console.WriteLine("Please enter the license plate of the vehicle you want to view:");
                    licensePlate = Console.ReadLine();

                    try
                    {
                        m_Garage.ShowAllDetailsOfSpecificVehicle(licensePlate);
                    }
                    catch(ArgumentException ae)
                    {
                        Console.WriteLine($"Error: {ae.Message}"); //EDIT
                    }
                    break;
            }
        }

        private void addAllVehicles()
        {
            string fileName = "Vehicles.db";
            List<string[]> vehiclesData = new List<string[]>(); // List to hold all vehicles data

            string[] lines = File.ReadAllLines(fileName); // Read all lines from the file

            foreach (string line in lines)
            {
                if (line.Trim() == "*****") // check for end of file 
                {
                    break;
                }

                string[] vehicleDetails = line.Split(','); // Split the line by comma
                vehiclesData.Add(vehicleDetails); // Add the vehicle details to the list
            }

            foreach (string[] vehicle in vehiclesData)
            {
                m_Garage.AddNewVehicle(vehicle);
            }
        }

        //VehicleType, LicensePlate, ModelName, EnergyPercentage, TierModel, CurrAirPressure,  OwnerName, OwnerPhone, [SPECIFIC VEHICLE PROPERTIES]

        private void addNewVehicleFromUser()
        {
            Console.WriteLine("Please enter the vehicle's License plate");
            string licensePlate = Console.ReadLine();
            while (!GarageDetailsValidator.LicensePlateNumberValidator(licensePlate))
            {
                Console.WriteLine("Please enter the vehicle's License plate");
                licensePlate = Console.ReadLine();
            }

            ImpoundedVehicle o_Vehicle;
            m_Garage.FindLicensePlate(licensePlate, out o_Vehicle);
            
            if(o_Vehicle == null) // vehicle not found, entering new vehicle
            {
                string[] vehicleDetails = new string[10];
                Console.WriteLine("Please enter the vehicle's VehicleType: ");
                vehicleDetails[0] = Console.ReadLine();

                Console.WriteLine("Please enter the vehicle's LicensePlate: ");
                vehicleDetails[1] = Console.ReadLine();

                Console.WriteLine("Please enter the vehicle's ModelName: ");
                vehicleDetails[2] = Console.ReadLine();

                Console.WriteLine("Please enter the vehicle's EnergyPercentage: ");
                vehicleDetails[3] = Console.ReadLine();

                Console.WriteLine("Please enter the vehicle's TierModel: ");
                vehicleDetails[4] = Console.ReadLine();

                Console.WriteLine("Please enter the vehicle's CurrAirPressure: ");
                vehicleDetails[5] = Console.ReadLine();

                Console.WriteLine("Please enter the vehicle's OwnerName: ");
                vehicleDetails[6] = Console.ReadLine();

                Console.WriteLine("Please enter the vehicle's OwnerPhone: ");
                vehicleDetails[7] = Console.ReadLine();

                if(vehicleDetails[0] == "FuelCar" || vehicleDetails[0] == "ElectricCar")
                {
                    Console.WriteLine("Please enter the car's Color: ");
                    vehicleDetails[8] = Console.ReadLine();

                    Console.WriteLine("Please enter the car's Amount of doors: ");
                    vehicleDetails[9] = Console.ReadLine();

                }
                else if (vehicleDetails[0] == "FuelMotorcycle" || vehicleDetails[0] == "ElectricMotorcycle")
                {
                    Console.WriteLine("Please enter the Motorcycle's Type of license: ");
                    vehicleDetails[8] = Console.ReadLine();

                    Console.WriteLine("Please enter the Motorcycle's Capacity Engine: ");
                    vehicleDetails[9] = Console.ReadLine();
                }
                else if (vehicleDetails[0] == "Truck")
                {
                    Console.WriteLine("Please enter  if the Truck contains Hazards (true/false): ");
                    vehicleDetails[8] = Console.ReadLine();

                    Console.WriteLine("Please enter the Truck's Cargo Capacity: ");
                    vehicleDetails[9] = Console.ReadLine();
                }

                m_Garage.AddNewVehicle(vehicleDetails);
            }
            else if(o_Vehicle != null) // vehicle exist in garage
            {
                Console.WriteLine("Vehicle already in garage - been changed to In Repair");
                o_Vehicle.Status = eVehicleStatus.InRepair;
            }
        }

        private void showAllChosenVehiclesLicensePlates()
        {
            Console.WriteLine("Please choose a status to filter by: ");
            Console.WriteLine("1. In Repair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid");
            Console.WriteLine("4. All");

            string choice = Console.ReadLine();
            int optionChoice;
            UserChoiceValidator.VehicleStatusChoiceValidator(choice, out optionChoice);

            eVehicleStatus status = (eVehicleStatus)(optionChoice - 1);
            List<string> licensePlates = m_Garage.GetLicensePlatesByStatus(status);

            if (licensePlates.Count == 0)
            {
                Console.WriteLine("No vehicles found with the selected status.");
            }
            else
            {
                Console.WriteLine("Vehicles with the selected status:");
                foreach (string licensePlate in licensePlates)
                {
                    Console.WriteLine(licensePlate);
                }
            }
        }
    }
}
