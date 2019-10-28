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

                    string model = words[0];
                    double engineSize = Convert.ToDouble(words[1]);
                    string color = words[2];
                    string transmission = words[3];
                    int manualTransmission = 1;
                    int automaticTransmission = 2;
                    int CVTTransmission = 3;

                    if (model == typeof(LandCruiser).Name)
                    {
                        switch (transmission)
                        {
                            case "Manual":
                                cars.Add(new LandCruiser(engineSize, color, manualTransmission));
                                break;
                            case "Automatic":
                                cars.Add(new LandCruiser(engineSize, color, automaticTransmission));
                                break;
                            case "CVT":
                                cars.Add(new LandCruiser(engineSize, color, CVTTransmission));
                                break;
                        }
                    }
                    if (model == typeof(Camry).Name)
                    {
                        switch (transmission)
                        {
                            case "Manual":
                                cars.Add(new Camry(engineSize, color, manualTransmission));
                                break;
                            case "Automatic":
                                cars.Add(new Camry(engineSize, color, automaticTransmission));
                                break;
                            case "CVT":
                                cars.Add(new Camry(engineSize, color, CVTTransmission));
                                break;
                        }
                    }
                    if (model == typeof(Corolla).Name)
                    {
                        switch (transmission)
                        {
                            case "Manual":
                                cars.Add(new Corolla(engineSize, color, manualTransmission));
                                break;
                            case "Automatic":
                                cars.Add(new Corolla(engineSize, color, automaticTransmission));
                                break;
                            case "CVT":
                                cars.Add(new Corolla(engineSize, color, CVTTransmission));
                                break;
                        }
                    }
                }
            }
        }

        public static void CreateSelectedModel()
        {
            Console.WriteLine("Enter model: 1 - LandCruiser, 2 - Camry, 3 - Corolla");
            string selectedModel = Console.ReadLine();

            if(IsModelValid(selectedModel))
            {
                Console.WriteLine("Input engine size: 1 - 1.8, 2 - 2.0, 3 - 3.0");
                string selectedEngineSize = Console.ReadLine();

                if (IsEngineSizeValid(selectedEngineSize)) 
                {
                    Console.WriteLine("Input color: 1-Green, 2-Black, 3-Red, 4-Blue");
                    string selectedColor = Console.ReadLine();

                    if (IsColorValid(selectedColor))
                    {
                        Console.WriteLine("Input transmission: 1-Manual, 2-Automatic, 3-CVT");
                        string selectedTransmission = Console.ReadLine();
                        if (IsTransmissionValid(selectedTransmission))
                        {
                            switch (selectedModel)
                            {
                                case "1":
                                    Car createdSelectedModelLandCruiser = new LandCruiser();

                                    SetConfigurations(createdSelectedModelLandCruiser, selectedEngineSize, selectedColor, selectedTransmission);
                                    break;
                                case "2":
                                    Car createdSelectedModelCamry = new Camry();

                                    SetConfigurations(createdSelectedModelCamry, selectedEngineSize, selectedColor, selectedTransmission);
                                    break;
                                case "3":
                                    Car createdSelectedModelCorolla = new Corolla();

                                    SetConfigurations(createdSelectedModelCorolla, selectedEngineSize, selectedColor, selectedTransmission);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public static bool IsModelValid(string selectedModel)
        {
            if (selectedModel == "1" || selectedModel == "2" || selectedModel == "3")
                return true;
            else
            {
                Console.WriteLine("The entered value is incorrect, try to input model: 1 - LandCruiser, 2 - Camry, 3 - Corolla");
                return false;
            }
        }

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
        public static bool IsColorValid(string selectedColor)
        {
            if (selectedColor == "1" || selectedColor == "2" || selectedColor == "3" || selectedColor == "4")
                return true;
            else
            {
                Console.WriteLine("Selected color is incorrect, try to input color: 1-Green, 2-Black, 3-Red, 4-Blue");
                return false;
            }
        }
        public static bool IsTransmissionValid(string selectedTransmission)
        {
            if (selectedTransmission == "1" || selectedTransmission == "2" || selectedTransmission == "3")
                return true;
            else { 
                Console.WriteLine("Selected transmission is incorrect, try to input transmission: 1-Manual, 2-Automatic, 3-CVT");
            return false;}
        }
        public static void SetConfigurations(Car car, string selectedEngineSize, string selectedColor, string selectedTransmission)
        {
            SetSelectedEngineSize(car, selectedEngineSize);

            SetSelectedColor(car, selectedColor);

            SetSelectedTransmission(car, selectedTransmission);

            DisplaySelectedCar(car);
        }

        public static Car SetSelectedEngineSize(Car car, string selectedEngineSize)
        {
            switch (selectedEngineSize)
            {
                case "1":
                    car.EngineSize = 1.8;
                    return car;
                case "2":
                    car.EngineSize = 2.0;
                    return car;
                case "3":
                    car.EngineSize = 3.0;
                    return car;
            }
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
            }
            return null;
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
            }
            return null;
        }

        public static void DisplaySelectedCar(Car car)
        {
            Console.WriteLine(car.CarInformation());
        }

        public static List<Car> SortCarCost(List<Car> cars)
        {
            cars.Sort((firstCar, nextCar) => firstCar.Cost.CompareTo(nextCar.Cost));
            return cars;
        }

        public static bool IsPriceRangeValid(int startingPrice, int endingPrice)
        {
            if (startingPrice >= 0 && endingPrice >= 0)
                if(startingPrice <= endingPrice)
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

                        CreateSelectedModel();

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion
                    #region case "3"
                    case "3":
                        Console.Clear();

                        SortCarCost(cars);
                        DisplayCarsInformation(cars);

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion
                    #region case "4"
                    case "4":
                        Console.Clear();

                        try
                        {
                            Console.WriteLine("Enter range of the price for the car: \nStarting price at ");
                            string startingPrice = Console.ReadLine();

                            Console.WriteLine("to ");
                            string endingPrice = Console.ReadLine();

                            SetPriceRange(startingPrice, endingPrice);
                            GetCarsInPriceRange(cars, startingPrice, endingPrice);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("The entered values are incorrect");
                        }

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


