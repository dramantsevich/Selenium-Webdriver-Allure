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
                    double engineSize = Convert.ToDouble(words[1]);

                    if (words[0] == typeof(LandCruiser).Name)
                    {
                        switch (words[3])
                        {
                            case "Manual":
                                cars.Add(new LandCruiser(engineSize, words[2], 1));
                                break;
                            case "Automatic":
                                cars.Add(new LandCruiser(engineSize, words[2], 2));
                                break;
                            case "CVT":
                                cars.Add(new LandCruiser(engineSize, words[2], 3));
                                break;
                        }
                    }
                    if (words[0] == typeof(Camry).Name)
                    {
                        switch (words[3])
                        {
                            case "Manual":
                                cars.Add(new Camry(engineSize, words[2], 1));
                                break;
                            case "Automatic":
                                cars.Add(new Camry(engineSize, words[2], 2));
                                break;
                            case "CVT":
                                cars.Add(new Camry(engineSize, words[2], 3));
                                break;
                        }
                    }
                    if (words[0] == typeof(Corolla).Name)
                    {
                        switch (words[3])
                        {
                            case "Manual":
                                cars.Add(new Corolla(engineSize, words[2], 1));
                                break;
                            case "Automatic":
                                cars.Add(new Corolla(engineSize, words[2], 2));
                                break;
                            case "CVT":
                                cars.Add(new Corolla(engineSize, words[2], 3));
                                break;
                        }
                    }
                }
            }
        }
        public static void CreateSelectedModel(string str)
        {
            Car selectedModel = new Car();

            if (str == "1")
            {
                selectedModel = new LandCruiser();

                SetConfigurations(selectedModel);
            }
            if (str == "2")
            {
                selectedModel = new Camry();

                SetConfigurations(selectedModel);
            }
            if (str == "3")
            {
                selectedModel = new Corolla();

                SetConfigurations(selectedModel);
            }
        }
        public static void SetConfigurations(Car car)
        {// тесты на вводимые значения
            //проверка что если ъоть 1 конфиг тачки не равен null или 0
            Console.WriteLine("Input engine size (1.8, 2.0, 3.0)"); 
            string selectedEngineSize = Console.ReadLine();
            SetEngineSize(car, selectedEngineSize);

            Console.WriteLine("Input color: 1-Green, 2-Black, 3-Red, 4-Blue");
            string selectedColor = Console.ReadLine();
            SetSelectedColor(car, selectedColor);

            Console.WriteLine("Input transmission: 1-Manual, 2-Automatic, 3-CVT");
            string selectedTransmission = Console.ReadLine();
            SetSelectedTransmission(car, selectedTransmission);

            DisplaySelectedConfiguration(car);
        }

        public static Car SetEngineSize(Car car, string selectedEngineSize)
        {
            double selectedEngineSizeToDouble = Convert.ToDouble(selectedEngineSize);

            if (car.EngineSize == 0)
            {
                car.EngineSize = selectedEngineSizeToDouble;
                return car;
            }
            else
                Console.WriteLine("Incorrect data in engine size");

            return null;
        }

        public static Car SetSelectedColor(Car car, string selectedColor)
        {
            switch (selectedColor)
            {
                case "1":
                    car.Color = "Green";
                    return car;
                case "2":
                    car.Color = "Black";
                    return car;
                case "3":
                    car.Color = "Red";
                    return car;
                case "4":
                    car.Color = "Blue";
                    return car;
                default: Console.WriteLine("Incorrect data in selected color");
                    return null;
            }
        }

        public static Car SetSelectedTransmission(Car car, string selectedTransmission)
        {

            switch (selectedTransmission)
            {
                case "1":
                    car.SelectedTransmission = 1;
                    return car;
                case "2":
                    car.SelectedTransmission = 2;
                    return car;
                case "3":
                    car.SelectedTransmission = 3;
                    return car;
                default:
                    Console.WriteLine("Incorrect data in selected transmission");
                    return null;
            }
        }

        public static void DisplaySelectedConfiguration(Car car)
        {
            Console.WriteLine(car.CarInformation());
        }

        public static void SortCarCost(List<Car> cars)
        {//a - first car, b - next car
            cars.Sort((a, b) => a.Cost.CompareTo(b.Cost));
            DisplayCarsInformation(cars);
        }

        public static void CarsInPriceRange(List<Car> cars, int a, int b)
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
        public static void DisplayCarsInformation(List<Car> cars)
        {
            foreach (Car c in cars)
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

                        if (selectedModel == "1" || selectedModel == "2" || selectedModel == "3")
                        {
                            CreateSelectedModel(selectedModel);
                        }
                        else Console.WriteLine("\n\n\n Incorrect data, try to input: 1 - LandCruiser, 2 - Camry, 3 - Corolla");

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


