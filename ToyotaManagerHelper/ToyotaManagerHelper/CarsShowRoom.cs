namespace ToyotaManagerHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToyotaManagerHelper.Cars;

    public class CarsShowRoom
    {
        private readonly List<Car> cars;

        public CarsShowRoom(IEnumerable<Car> cars)
        {
            this.cars = cars.ToList();
        }

        public CarsShowRoom SortedCarCost()
        {
            return new CarsShowRoom(this.cars.OrderBy(c => c.GetCarCost()));
        }

        public bool IsPriceRangeValid(int startingPrice, int endingPrice)
        {
            if (startingPrice >= 0 && endingPrice >= 0)
            {
                if (startingPrice <= endingPrice)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Please enter starting price less then ending price");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Please enter price more then 0");
                return false;
            }
        }

        public (string, string) SetPriceRange(string startingPrice, string endingPrice)
        {
            int startingPriceToInt = Convert.ToInt32(startingPrice);
            int endingPriceToInt = Convert.ToInt32(endingPrice);

            if (this.IsPriceRangeValid(startingPriceToInt, endingPriceToInt))
            {
                return (startingPrice, endingPrice);
            }

            return ("0", "0");
        }

        public CarsShowRoom GetCarsInPriceRange(CarsShowRoom carsInShowRoom, string startingPrice, string endingPrice)
        {
            int startingPriceToInt = Convert.ToInt32(startingPrice);
            int endingPriceToInt = Convert.ToInt32(endingPrice);
            CarsShowRoom carsInShowRoomInPriceRange;

            List<Car> carsInPriceRange = new List<Car>();

            foreach (Car car in carsInShowRoom.cars)
            {
                if (car.GetCarCost() >= startingPriceToInt && car.GetCarCost() <= endingPriceToInt)
                {
                    carsInPriceRange.Add(car);
                }
            }

            carsInShowRoomInPriceRange = new CarsShowRoom(carsInPriceRange);

            if (carsInShowRoomInPriceRange.cars.Count == 0)
            {
                Console.WriteLine("In this range there are no available cars");

                return carsInShowRoomInPriceRange = null;
            }

            return carsInShowRoomInPriceRange;
        }

        public void DisplayListCars()
        {
            try
            {
                foreach (Car car in this.cars)
                {
                    Console.WriteLine(car.ToString());
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error: NullReferenceException");
            }
        }
    }
}
