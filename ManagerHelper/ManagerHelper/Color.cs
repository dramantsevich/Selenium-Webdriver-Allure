using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerHelper
{
    public class Color
    {
        public static bool IsColorValid(string selectedColor)
        {
            if (selectedColor == "1" || selectedColor == "2" || selectedColor == "3" || selectedColor == "4")
                return true;
            else
            {
                Console.WriteLine("Selected color is incorrect, try to input color: 1-Green, 2-Black, 3-Red, 4-Blue");
                return false;
            }
        }

        public static void SetSelectedColor(Car car, string selectedColor)
        {
            switch (selectedColor)
            {
                case "1":
                    car.Color = "Green";
                    break;
                case "2":
                    car.Color = "Black";
                    break;
                case "3":
                    car.Color = "Red";
                    break;
                case "4":
                    car.Color = "Blue";
                    break;
            }
        }
    }
}
