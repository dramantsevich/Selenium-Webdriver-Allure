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

        public static void CreateSelectedModel(string selectedModel)
        {
            if(IsModelValid(selectedModel))
            {
                Console.WriteLine("Input engine size: 1 - 1.8, 2 - 2.0, 3 - 3.0");
                string selectedEngineSize = Console.ReadLine();

                if (EngineSize.IsEngineSizeValid(selectedEngineSize)) 
                {
                    Console.WriteLine("Input color: 1-Green, 2-Black, 3-Red, 4-Blue");
                    string selectedColor = Console.ReadLine();

                    if (Color.IsColorValid(selectedColor))
                    {
                        Console.WriteLine("Input transmission: 1-Manual, 2-Automatic, 3-CVT");
                        string selectedTransmission = Console.ReadLine();
                        if (Transmission.IsTransmissionValid(selectedTransmission))
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
      
        public static void SetConfigurations(Car car, string selectedEngineSize, string selectedColor, string selectedTransmission)
        {
            EngineSize.SetSelectedEngineSize(car, selectedEngineSize);

            Color.SetSelectedColor(car, selectedColor);

            Transmission.SetSelectedTransmission(car, selectedTransmission);

            DisplaySelectedCar(car);
        }

        public static void DisplaySelectedCar(Car car)
        {
            Console.WriteLine(car.CarInformation());
        }

        public static void SortCarCost(List<Car> cars)
        {
            cars.Sort((firstCar, nextCar) => firstCar.Cost.CompareTo(nextCar.Cost));
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

                        CreateSelectedModel(selectedModel);

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

                            PriceRange.SetPriceRange(startingPrice, endingPrice);
                            PriceRange.GetCarsInPriceRange(cars, startingPrice, endingPrice);
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


