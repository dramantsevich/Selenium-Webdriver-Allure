using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ManagerHelper
{
    public class ManagerHelper
    {
        public static IEnumerable<Car> GetAvailableCars(List<Car> cars)
        {
            //Assembly _assembly;
            string path = @"..\..\..\Properties\CarsAvailable.txt";
            //StreamReader _textStreamReader;

            //_assembly = Assembly.GetExecutingAssembly();
            //_textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("ManagerHelper.CarsAvailable.txt"));
            //_textStreamReader = new StreamReader(Properties.Resources.CarsAvailable);

            using (StreamReader _textStreamReader = new StreamReader(path))
            {
                string line;

                while ((line = _textStreamReader.ReadLine()) != null)
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
            IEnumerable<Car> castedCars = cars.Cast<Car>();
            return castedCars;
        }
        public static void DisplaySortedCarInformation(IEnumerable<Car> cars)
        {
            foreach (Car c in cars)
            {
                Console.WriteLine(c.CarInformation());
            }
        }

        public static Car CreateSelectedModel(string str)
        {
            Car selectedModel = new Car();

            if ((str == typeof(LandCruiser).Name) || (str.ToUpper() == typeof(LandCruiser).Name) || (str.ToLower() == typeof(LandCruiser).Name))
            {
                selectedModel = new LandCruiser();
            }
            if ((str == typeof(Camry).Name) || (str.ToUpper() == typeof(Camry).Name) || (str.ToLower() == typeof(Camry).Name))
            {
                selectedModel = new Camry();
            }
            if ((str == typeof(Corolla).Name) || (str.ToUpper() == typeof(Corolla).Name) || (str.ToLower() == typeof(Corolla).Name))
            {
                selectedModel = new Corolla();
            }

            return selectedModel;
        }

        public static void DisplayCalculatedCostConfiguration(Car obj)
        {
            bool isTrue = true;

            Console.WriteLine("Input engine size (1.8, 2.0, 3.0)");
            string selectedEngineSize = Console.ReadLine();

            do
            {
                try
                {
                    obj.EngineSize = Convert.ToDouble(selectedEngineSize.Replace(".", ","));
                    isTrue = false;
                }
                catch
                {
                    Console.WriteLine("Try input engine size (1.8, 2.0, 3.0): for example '1.8' or '1,8'");
                    selectedEngineSize = Console.ReadLine();
                }
            } while (isTrue);

            Console.WriteLine("Input color: Green, Black, Red, Blue");
            string selectedColor = Console.ReadLine();

            do
            {
                if (selectedColor == "Green" || selectedColor == "Black" || selectedColor == "Red" || selectedColor == "Blue")
                {
                    obj.Color = selectedColor;
                    isTrue = false;
                }
                else
                {
                    Console.WriteLine("Try to input: Green, Black, Red, Blue");
                    selectedColor = Console.ReadLine();
                }
            } while (isTrue);
            

            Console.WriteLine("Input transmission: 1-Manual, 2-Automatic, 3-CVT");
            string selectedTransmission = Console.ReadLine();

            do
            {
                if (Convert.ToInt32(selectedTransmission) == 1 || Convert.ToInt32(selectedTransmission) == 2 || Convert.ToInt32(selectedTransmission) == 3)
                {
                    obj.SelectedTransmission = Convert.ToInt32(selectedTransmission);
                    isTrue = false;
                }
                else
                {
                    Console.WriteLine("Try to input: 1-Manual, 2-Automatic, 3-CVT");
                    selectedTransmission = Console.ReadLine();
                }
            } while (isTrue);

            Console.WriteLine($"\n {obj.CarInformation()}");
        }

        public static IEnumerable<Car> SortCarCost(IEnumerable<Car> cars)
        {
            var sort = from c in cars
                       orderby c.Cost
                       select c;

            IEnumerable<Car> sortedCarsCost = sort.Cast<Car>();

            return sortedCarsCost;
        }

        public static IEnumerable<Car> CarsInPriceRange(IEnumerable<Car> cars, int a,int b)
        {
            //Price range for cars [a,b]
            List<Car> listCarsInRange = new List<Car>();

            foreach(Car car in cars)
            { 
                if (car.Cost >= a && car.Cost <= b)
                {
                    listCarsInRange.Add(car);
                }
            }
            IEnumerable<Car> carsInRange = listCarsInRange.Cast<Car>();

            return carsInRange;
        }


        static void Main(string[] args)
        {
            List<Car> listCars = new List<Car>();
            IEnumerable<Car> cars = listCars.Cast<Car>();
            bool isQuit = false;

            GetAvailableCars(listCars);

            while (!isQuit)
            {
                Console.Clear();

                Console.WriteLine("1 - to view information about cars\n" +
                "2 - to calculate the cost of the car depending on the selected configuration\n" +
                "3 - to sort cars by price\n" +
                "4 - to find a complete set that corresponds to a given price range\n" +
                "5 - quit\n");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        
                        foreach(Car c in cars)
                        {
                            Console.WriteLine(c.CarInformation());
                        }

                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Input model: LandCruiser, Camry, Corolla");
                        string selectedModel = Console.ReadLine();

                        bool isTrue = true;

                        do
                        {
                            if (selectedModel == "LandCruiser" || selectedModel == "Camry" || selectedModel == "Corolla")
                            {
                                DisplayCalculatedCostConfiguration(CreateSelectedModel(selectedModel));
                                isTrue = false;
                            }
                            else
                            {
                                Console.WriteLine("Try to input: LandCruiser, Camry, Corolla");
                                selectedModel = Console.ReadLine();
                            }
                        } while (isTrue);

                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();

                        //DisplayCarInformation(CarCost(cars));
                        DisplaySortedCarInformation(SortCarCost(cars));

                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();

                        Console.WriteLine("Input range[a,b] of the price for the car: ");
                        string a = Console.ReadLine();
                        string b = Console.ReadLine();

                        DisplaySortedCarInformation(SortCarCost(CarsInPriceRange(cars, Convert.ToInt32(a), Convert.ToInt32(b))));

                        Console.ReadKey();
                        break;
                    case "5":
                        isQuit = true;
                        break;
                }
            }

        }
    }
}