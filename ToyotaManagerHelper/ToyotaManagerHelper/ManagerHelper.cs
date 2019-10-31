namespace ToyotaManagerHelper
{
    using System;
    using System.Collections.Generic;
    using ToyotaManagerHelper.Cars;

    public class ManagerHelper
    {
        static void Main(string[] args)
        {
            List<Car> listOfCars = new List<Car>();
            bool isQuit = false;
            CarCreator carCreatorController;

            AvailableCars.GetAvailableCars(listOfCars);

            CarsShowRoom carShowRoomController = new CarsShowRoom(listOfCars);

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
                    #region
                    case "1":
                        Console.Clear();

                        carShowRoomController.DisplayListCars();

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion

                    #region
                    case "2":
                        Console.Clear();

                        Console.WriteLine("Enter model: 1 - LandCruiser, 2 - Camry, 3 - Corolla");
                        string selectedNumberModel = Console.ReadLine();

                        if (IsModelValid(selectedNumberModel))
                        {
                            switch (selectedNumberModel)
                            {
                                case "1":
                                    carCreatorController = new CarCreator(new LandCruiser(), "LandCruiser");

                                    carCreatorController.SetConfigurations();
                                    Console.WriteLine(carCreatorController.ToString());

                                    break;
                                case "2":
                                    carCreatorController = new CarCreator(new Camry(), "Camry");

                                    carCreatorController.SetConfigurations();
                                    Console.WriteLine(carCreatorController.ToString());

                                    break;
                                case "3":
                                    carCreatorController = new CarCreator(new Corolla(), "Corolla");

                                    carCreatorController.SetConfigurations();
                                    Console.WriteLine(carCreatorController.ToString());

                                    break;
                            }
                        }

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion

                    #region
                    case "3":
                        Console.Clear();

                        carShowRoomController.SortedCarCost().DisplayListCars();

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion

                    #region
                    case "4":
                        Console.Clear();

                        try
                        {
                            Console.WriteLine("Enter range of the price for the car: \nStarting price at ");
                            string startingPrice = Console.ReadLine();

                            Console.WriteLine("to ");
                            string endingPrice = Console.ReadLine();

                            carShowRoomController.SetPriceRange(startingPrice, endingPrice);
                            carShowRoomController.GetCarsInPriceRange(carShowRoomController, startingPrice, endingPrice).DisplayListCars();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("The entered values are incorrect: FormatException");
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("The entered values are incorrect: NullReferenceException");
                        }

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion

                    #region
                    case "5":
                        isQuit = true;
                        break;
                    #endregion
                }
            }
            while (!isQuit);
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
    }
}
