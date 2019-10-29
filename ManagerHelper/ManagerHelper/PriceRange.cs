using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerHelper
{
    public class PriceRange
    {
        public static bool IsPriceRangeValid(int startingPrice, int endingPrice)
        {
            if (startingPrice >= 0 && endingPrice >= 0)
                if (startingPrice <= endingPrice)
                    return true;
                else
                {
                    Console.WriteLine("Please enter starting price less then ending price");
                    return false;
                }
            else
            {
                Console.WriteLine("Please enter price more then 0");
                return false;
            }

        }

        public static (string, string) SetPriceRange(string startingPrice, string endingPrice)
        {
            int startingPriceToInt = Convert.ToInt32(startingPrice);
            int endingPriceToInt = Convert.ToInt32(endingPrice);

            if (IsPriceRangeValid(startingPriceToInt, endingPriceToInt))
            {
                return (startingPrice, endingPrice);
            }

            return (null, null);
        }

        public static List<Car> GetCarsInPriceRange(List<Car> cars, string startingPrice, string endingPrice)
        {
            int startingPriceToInt = Convert.ToInt32(startingPrice);
            int endingPriceToInt = Convert.ToInt32(endingPrice);

            List<Car> carsInPriceRange = new List<Car>();

            foreach (Car car in cars)
            {
                if (car.Cost >= startingPriceToInt && car.Cost <= endingPriceToInt)
                {
                    carsInPriceRange.Add(car);
                    return carsInPriceRange;
                }
            }

            if (carsInPriceRange.Count == 0)
            {
                Console.WriteLine("In this range there are no available cars");
            }

            return null;
        }
    }
}
