using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ToyotaManager
{
    public class Program
    {
        public static List<int> SortedComplectationOfCars(List<Car> cars)
        {
            var sortedCars = from c in cars //сортировка комплектующего без учёта модели автомобиля
                             orderby c.ComplectationCost
                             select c;

            List<int> costs = new List<int>();

            foreach (Car c in sortedCars)
            {
                costs.Add(c.ComplectationCost);
                Console.WriteLine(c.CarCost);
            }

            Console.WriteLine("\n\n");
            return costs;
        }

        public static List<int> SortedCarCost(List<Car> cars)
        {
            List<int> carCosts = new List<int>();

            var sortedCarCost = from c in cars
                                orderby c.CarCost
                                select c;
           
            foreach (Car c in sortedCarCost)
            {
                carCosts.Add(c.CarCost);
                Console.WriteLine(c.CarCost);
            }
            Console.WriteLine("\n\n");
            return carCosts;
        }

        public static List<Car> GetComplectationOfPriceRange(List<Car> cars, int a, int b)
        {
            //the price range for the car [x,y]
            List<Car> carsInPriceRange = new List<Car>();

            foreach(Car c in cars)
            {
                if (c.CarCost >= a && c.CarCost <= b)
                {
                    carsInPriceRange.Add(c);
                    Console.WriteLine(c.ToString());
                }
            }
            Console.WriteLine("\n\n");
            return carsInPriceRange;
        }

        public static void Serialize(List<Car> cars)
        {
            string dir = @"D:\Study\iTechArt";
            string serializationFile = Path.Combine(dir, "Cars.bin");

            using (Stream stream = File.Open(serializationFile, FileMode.OpenOrCreate))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, cars);
            }
            Console.WriteLine("Serialization is done\n");
        }

        public static void Deserialize()
        {
            string dir = @"D:\Study\iTechArt";
            string serializationFile = Path.Combine(dir, "Cars.bin");
            
            Console.WriteLine("Deserialization is done\n");

            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                List<Car> cars = (List<Car>)bformatter.Deserialize(stream);

                foreach (Car c in cars)
                {
                    Console.WriteLine(c.ToString());
                }
            }
        }

        static void Main(string[] args)
        {
            #region
            LandCruiser LC1 = new LandCruiser(1.8, "Blue", 1);
            LandCruiser LC2 = new LandCruiser(2.6, "Red", 2);
            LandCruiser LC3 = new LandCruiser(3.0, "Yellow", 3);

            Camry Camry1 = new Camry(2.0, "White", 2);
            Camry Camry2 = new Camry(1.6, "Orange", 1);
            Camry Camry3 = new Camry(3.2, "Blue", 3);

            Corolla Corolla1 = new Corolla(3.0, "Black", 3);
            Corolla Corolla2 = new Corolla(1.8, "Orange", 1);
            Corolla Corolla3 = new Corolla(2.6, "Red", 2);

            List<Car> cars = new List<Car>();
            cars.Add(LC1);
            cars.Add(Camry1);
            cars.Add(Corolla1);
            cars.Add(LC2);
            cars.Add(Camry2);
            cars.Add(Corolla2);
            cars.Add(LC3);
            cars.Add(Camry3);
            cars.Add(Corolla3);
            #endregion 

            foreach (Car c in cars)
            {
                Console.WriteLine(c.ToString());
            }

            SortedComplectationOfCars(cars);

            SortedCarCost(cars);

            Console.WriteLine("Input range of the price for the car[a,b]: ");
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            GetComplectationOfPriceRange(cars, Convert.ToInt32(a), Convert.ToInt32(b));

            Serialize(cars);

            Deserialize();

            Console.ReadKey();
        }
    }
}
