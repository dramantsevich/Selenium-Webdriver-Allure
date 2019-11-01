using System;
using System.Collections.Generic;
using System.Linq;
using ToyotaManagerHelper.Builder;

namespace ToyotaManagerHelper
{
    public class ToyotaShowRoom
    {
        CarBuilderBase carBuilder;
        Car builtCar;
        private readonly List<Car> cars;

        public ToyotaShowRoom(IEnumerable<Car> cars)
        {
            this.cars = cars.ToList();
        }

        public Car CreateCarSelectedConfiguration(string selectedNumberModel)
        {
            if (IsModelValid(selectedNumberModel))
            {
                switch (selectedNumberModel)
                {
                    case "1":
                        carBuilder = new LandCruiserBuilder();
                        try
                        {
                            carBuilder.BuildCarWithFullCOnfigurations();

                            this.builtCar = carBuilder.GetCar();

                            Console.WriteLine(this.builtCar.ToString());
                        }
                        catch(NullReferenceException)
                        {
                            Console.WriteLine("Incorrect data: NullReferebceException");
                        }

                        break;

                    case "2":
                        carBuilder = new CamryBuilder();
                        
                        try
                        {
                            carBuilder.BuildCarWithFullCOnfigurations();

                            this.builtCar = carBuilder.GetCar();

                            Console.WriteLine(this.builtCar.ToString());
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Incorrect data: NullReferebceException");
                        }

                        break;

                    case "3":
                        carBuilder = new CorollaBuilder();
                        try
                        {
                            carBuilder.BuildCarWithFullCOnfigurations();

                            builtCar = carBuilder.GetCar();

                            Console.WriteLine(builtCar.ToString());
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Incorrect data: NullReferebceException");
                        }

                        break;
                }
            }
            return builtCar;
        }

        public static bool IsModelValid(string selectedModel)
        {
            if (selectedModel == "1" || selectedModel == "2" || selectedModel == "3")
            {
                return true;
            }
            else
            {
                Console.WriteLine("The entered value is incorrect, try to input model: 1 - LandCruiser, 2 - Camry, 3 - Corolla");
                return false;
            }
        }

        public ToyotaShowRoom SortedCarsByPrice()
        {
            return new ToyotaShowRoom(this.cars.OrderBy(price => price.GetCarCost()));
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

        public ToyotaShowRoom GetCarsInPriceRange(ToyotaShowRoom carsInShowRoom, string startingPrice, string endingPrice)
        {
            int startingPriceToInt = Convert.ToInt32(startingPrice);
            int endingPriceToInt = Convert.ToInt32(endingPrice);
            ToyotaShowRoom carsInShowRoomInPriceRange;

            List<Car> carsInPriceRange = new List<Car>();

            foreach (Car car in carsInShowRoom.cars)
            {
                if (car.GetCarCost() >= startingPriceToInt && car.GetCarCost() <= endingPriceToInt)
                {
                    carsInPriceRange.Add(car);
                }
            }

            carsInShowRoomInPriceRange = new ToyotaShowRoom(carsInPriceRange);

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
