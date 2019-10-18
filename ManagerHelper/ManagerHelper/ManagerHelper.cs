using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ManagerHelper
{
    public class Managerhelper
    {
        public static void GetAvailableCars(List<Car> cars)
        {
            string path = @"..\..\..\Resources\CarsAvailable.txt";

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
        }

        public static Car CreateSelectedModel(string str)
        {
            Car selectedModel = new Car();

            if(str == "1")
            {
                selectedModel = new LandCruiser();

                SetConfigurations(selectedModel);

                return selectedModel;
            }
            if (str == "2")
            {
                selectedModel = new Camry();

                SetConfigurations(selectedModel);

                return selectedModel;
            }
            if (str == "3")
            {
                selectedModel = new Corolla();

                SetConfigurations(selectedModel);

                return selectedModel;
            }
            return null;
        }

        public static Car SetConfigurations(Car car)
        {// тесты на вводимые значения
            Console.WriteLine("Input engine size (1.8, 2.0, 3.0)");//только через запятую, не буквы; не 2,03490401340; 
            string selectedEngineSize = Console.ReadLine();

            car.EngineSize = Convert.ToDouble(selectedEngineSize.Replace(".", ","));

            Console.WriteLine("Input color: Green, Black, Red, Blue");//один из этих 4 цветов
            string selectedColor = Console.ReadLine();

            if (selectedColor == "Green" || selectedColor == "Black" || selectedColor == "Red" || selectedColor == "Blue")
            {
                car.Color = selectedColor;
            }

            Console.WriteLine("Input transmission: 1-Manual, 2-Automatic, 3-CVT");//4 - недопустимо; буквы тоже
            string selectedTransmission = Console.ReadLine();

            if (Convert.ToInt32(selectedTransmission) == 1 || Convert.ToInt32(selectedTransmission) == 2 || Convert.ToInt32(selectedTransmission) == 3)
            {
                car.SelectedTransmission = Convert.ToInt32(selectedTransmission);
            }

            return car;
        }

        static void DisplaySelectedConfiguration(Car car)
        {
            Console.WriteLine(car.CarInformation());
        }

        public static void SortCarCost(List<Car> cars)
        {//a - first car, b - next car
            cars.Sort((a,b) => a.Cost.CompareTo(b.Cost));
            DisplayCarsInformation(cars);
        }

        public static void CarsInPriceRange (List<Car> cars, int a, int b)
        {// написать тесты для интов, только инты могут передаваться; а < b иначе не выведет; больше 0
            List<Car> listCarsInRange = new List<Car>();

            foreach (Car car in cars)
            {
                if (car.Cost >= a && car.Cost <= b)
                {
                    listCarsInRange.Add(car);
                }
            }
            SortCarCost(listCarsInRange);
            DisplayCarsInformation(listCarsInRange);
        }

        static void DisplayCarsInformation(List<Car> cars)
        {
            foreach(Car c in cars)
            {
                Console.WriteLine(c.CarInformation());
            }
        }

        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            bool isQuit = false;

            GetAvailableCars(cars);

            do
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
                    #region case "1"
                    case "1":
                        Console.Clear();

                        DisplayCarsInformation(cars);

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion
                    #region case "2"
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter model: 1 - LandCruiser, 2 - Camry, 3 - Corolla");
                        string selectedModel = Console.ReadLine();

                        if(selectedModel == "1" || selectedModel == "2" || selectedModel == "3")
                        {
                            CreateSelectedModel(selectedModel);
                        }
                        else Console.WriteLine("\n\n\n Incorrect data");

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion
                    #region case "3"
                    case "3":
                        Console.Clear();

                        SortCarCost(cars);

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion
                    #region case"4"
                    case "4":
                        Console.Clear();

                        Console.WriteLine("Enter range of the price for the car: ");
                        string a = Console.ReadLine();
                        string b = Console.ReadLine();

                        CarsInPriceRange(cars, Convert.ToInt32(a), Convert.ToInt32(b));   

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion
                    case "5":
                        isQuit = true;
                        break;
                }
            } while (!isQuit);
        }
    }
}
