using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerHelper
{
    public class EngineSize
    {
        public static bool IsEngineSizeValid(string selectedEngineSize)
        {
            if (selectedEngineSize == "1" || selectedEngineSize == "2" || selectedEngineSize == "3")
                return true;
            else
            {
                Console.WriteLine("Selected engine size is incorrect, try to input engine size: 1 - 1.8, 2 - 2.0, 3 - 3.0");
                return false;
            }
        }

        public static void SetSelectedEngineSize(Car car, string selectedEngineSize)
        {
            switch (selectedEngineSize)
            {
                case "1":
                    car.EngineSize = 1.8;
                    break;
                case "2":
                    car.EngineSize = 2.0;
                    break;
                case "3":
                    car.EngineSize = 3.0;
                    break;
            }
        }
    }
}
