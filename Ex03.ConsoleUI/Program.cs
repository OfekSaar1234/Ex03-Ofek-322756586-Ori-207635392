using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageManagmentSystem garageManagmentSystem = new GarageManagmentSystem();
            garageManagmentSystem.ChooseOptionFromMenu();
        }
    }
}


//ToDo:
// Check all methods privacy (public/private/protected)
// Check all methods names convention (PascalCase)
// Check all methods parameters names convention (camelCase)
// Check all classes names convention abstract/sealed/interface/enum (PascalCase)
// check all imports if needed
// Check all classes privacy (public/private/protected)
// we didnt use polymorphism in the project...... no virtual (the word in the project)
// Implement Enum for vehicle types
// Implement ValueRangeExeption
// check where to put exceptions in general (when to use bool and when to throw exception)
// check validations in all places
// make word polymoprphism tree (inheritance / composition etc)


// exceptions we need to use (Format, Argument, ValueRange)