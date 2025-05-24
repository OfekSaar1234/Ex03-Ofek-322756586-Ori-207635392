using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UserChoiceValidator
    {
        public static void MenuChoiceValidator(string i_Choice, out int o_OptionChoice)
        {
            bool parseSuccess = int.TryParse(i_Choice, out o_OptionChoice);

            while (string.IsNullOrEmpty(i_Choice) || !parseSuccess || o_OptionChoice < 1 || o_OptionChoice > 8)
            {
                Console.WriteLine("Invalid input. Please enter an option between 1 and 8.");
                i_Choice = Console.ReadLine();
                parseSuccess = int.TryParse(i_Choice, out o_OptionChoice);
            }
        }

        public static void VehicleStatusChoiceValidator(string i_Choice, out int o_VehicleStatusChoice)
        {
            bool parseSuccess = int.TryParse(i_Choice, out o_VehicleStatusChoice);

            while (string.IsNullOrEmpty(i_Choice) || !parseSuccess || o_VehicleStatusChoice < 1 || o_VehicleStatusChoice > 4)
            {
                Console.WriteLine("Invalid input. Please enter an option between 1 and 4.");
                i_Choice = Console.ReadLine();
                parseSuccess = int.TryParse(i_Choice, out o_VehicleStatusChoice);
            }
        }
    }
}
