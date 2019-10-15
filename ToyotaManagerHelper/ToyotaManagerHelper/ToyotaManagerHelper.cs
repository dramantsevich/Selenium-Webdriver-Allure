using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ToyotaManagerHelper
{
    public class ToyotaManagerHelper
    {
        public static List<Car> AvailableCarsFromFile(List<Car> cars)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), @"CarsAvailable.txt");

            using (StreamReader sr = new StreamReader(Path.GetFullPath(path)))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ' });//divide each line into words
                    double d = Convert.ToDouble(words[1]);
                    

                    if (words[0] == typeof(LandCruiser).Name)
                    {
                        if (words[3] == "Manual" || words[3] == "manual")
                        {
                            cars.Add(new LandCruiser(d, words[2], 1));
                        }
                        if (words[3] == "Automatic" || words[3] == "automatic")
                        {
                            cars.Add(new LandCruiser(d, words[2], 2));
                        }
                        if (words[3] == "CVT" || words[3] == "cvt")
                        {
                            cars.Add(new LandCruiser(d, words[2], 3));
                        }
                    }
                    if (words[0] == typeof(Corolla).Name)
                    {
                        if (words[3] == "Manual" || words[3] == "manual")
                        {
                            cars.Add(new Corolla(d, words[2], 1));
                        }
                        if (words[3] == "Automatic" || words[3] == "automatic")
                        {
                            cars.Add(new Corolla(d, words[2], 2));
                        }
                        if (words[3] == "CVT" || words[3] == "cvt")
                        {
                            cars.Add(new Corolla(d, words[2], 3));
                        }
                    }
                    if (words[0] == typeof(Camry).Name)
                    {
                        if (words[3] == "Manual" || words[3] == "manual")
                        {
                            cars.Add(new Camry(d, words[2], 1));
                        }
                        if (words[3] == "Automatic" || words[3] == "automatic")
                        {
                            cars.Add(new Camry(d, words[2], 2));
                        }
                        if (words[3] == "CVT" || words[3] == "cvt")
                        {
                            cars.Add(new Camry(d, words[2], 3));
                        }
                    }
                }
            }

            return cars;
        }
        
        public static List<int> DisplayCarConfiguration(List<Car> cars)
        {
            var sortedCars = from c in cars //сортировка комплектующего без учёта модели автомобиля
                             orderby c.ComplectationCost
                             select c;

            List<int> costs = new List<int>();

            foreach (Car c in sortedCars)
            {
                costs.Add(c.ComplectationCost);
                Console.WriteLine(c.DisplaySelectedConfiguration());
            }
            return costs;
        }

        public static List<int> DisplayCarCost(List<Car> cars)
        {
            List<int> carCosts = new List<int>();

            var sortedCarCost = from c in cars
                                orderby c.CarCost
                                select c;

            foreach (Car c in sortedCarCost)
            {
                carCosts.Add(c.CarCost);
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine("\n\n");
            return carCosts;
        }

        public static List<Car> GetComplectationOfPriceRange(List<Car> cars, int a, int b)
        {
            //the price range for the car [x,y]
            List<Car> carsInPriceRange = new List<Car>();

            foreach (Car c in cars)
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

        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            bool isQuit = false;
            
            AvailableCarsFromFile(cars);

            while (!isQuit)
            {
                Console.Clear();

                Console.WriteLine("1 - to view information about cars\n" +
                "2 - calculate the cost of the car depending on the selected configuration\n" +
                "3 - sort cars by price\n" +
                "4 - find a package that matches a given price range\n" +
                "5 - quit\n");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        foreach (Car c in cars)
                        {
                            Console.WriteLine(c.ToString());
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        DisplayCarConfiguration(cars);
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        DisplayCarCost(cars);
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Input range of the price for the car[a,b]: ");
                        string a = Console.ReadLine();
                        string b = Console.ReadLine();
                        GetComplectationOfPriceRange(cars, Convert.ToInt32(a), Convert.ToInt32(b));
                        Console.ReadKey();
                        break;
                    case "5":
                        isQuit = true;
                        break;
                }
            } 

            

            Console.ReadKey();
        }
    }

}

