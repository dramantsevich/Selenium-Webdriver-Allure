using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerHelper
{
    public class Transmission
    {
        public static bool IsTransmissionValid(string selectedTransmission)
        {
            if (selectedTransmission == "1" || selectedTransmission == "2" || selectedTransmission == "3")
                return true;
            else
            {
                Console.WriteLine("Selected transmission is incorrect, try to input transmission: 1-Manual, 2-Automatic, 3-CVT");
                return false;
            }
        }
        public static void SetSelectedTransmission(Car car, string selectedTransmission)
        {
            switch (selectedTransmission)
            {
                case "1":
                    car.SelectedTransmission = 1;
                    break;
                case "2":
                    car.SelectedTransmission = 2;
                    break;
                case "3":
                    car.SelectedTransmission = 3;
                    break;
            }
        }
    }
}
