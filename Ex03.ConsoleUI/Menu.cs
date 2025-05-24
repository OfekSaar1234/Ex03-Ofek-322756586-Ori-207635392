using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class Menu
    {
        public static int ShowMainMenu()
        {
            Console.WriteLine("Welcome To The Garage Management System");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Load All Vehicles");
            Console.WriteLine("2. Add A New Vehicle");
            Console.WriteLine("3. Show All Vehicle's License Plates"); // with an option to filter by status
            Console.WriteLine("4. Change Vehicle's Details");
            Console.WriteLine("5. Inflate Tires");
            Console.WriteLine("6. Refuel Vehicle");
            Console.WriteLine("7. Recharge Vehicle");
            Console.WriteLine("8. Show All Details Of Specific Vehicle by License Plate");

            string choice = Console.ReadLine();
            int optionChoice;
            UserChoiceValidator.MenuChoiceValidator(choice, out optionChoice);

            return optionChoice;
        }

        
    }
}

