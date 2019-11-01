using System;
using ToyotaManagerHelper.Builder;
using System.Collections.Generic;

namespace ToyotaManagerHelper
{
    class ManagerHelper
    {
        static void Main(string[] args)
        {
            bool isQuit = false;
            List<Car> listOfCars = new List<Car>();

            AvailableCars.GetAvailableCars(listOfCars);

            ToyotaShowRoom toyotaShowRoomController = new ToyotaShowRoom(listOfCars);

            do {
                Console.Clear();

                Console.WriteLine("1 - to view information about cars\n" +
                "2 - to calculate the cost of the car depending on the selected configuration\n" +
                "3 - to sort cars by price\n" +
                "4 - to find a complete set that corresponds to a given price range\n" +
                "5 - quit\n");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    #region 1 - to view information about cars
                    case "1":
                        Console.Clear();

                        toyotaShowRoomController.DisplayListCars();

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion

                    #region 2 - to calculate cost of selected config car
                    case "2":
                        Console.Clear();

                        Console.WriteLine("Enter model: 1 - LandCruiser, 2 - Camry, 3 - Corolla");
                        string selectedNumberModel = Console.ReadLine();

                        toyotaShowRoomController.CreateCarSelectedConfiguration(selectedNumberModel);

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion

                    #region 3 - to show sorted cars by price
                    case "3":
                        Console.Clear();

                        toyotaShowRoomController.SortedCarsByPrice().DisplayListCars();

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion

                    #region 4 - to show cars in price range
                    case "4":
                        Console.Clear();

                        try
                        {
                            Console.WriteLine("Enter range of the price for the car: \nStarting price at ");
                            string startingPrice = Console.ReadLine();

                            Console.WriteLine("to ");
                            string endingPrice = Console.ReadLine();

                            toyotaShowRoomController.SetPriceRange(startingPrice, endingPrice);
                            toyotaShowRoomController.GetCarsInPriceRange(toyotaShowRoomController, startingPrice, endingPrice).DisplayListCars();

                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("The entered values are incorrect: NullReferenceException");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("The entered values are incorrect: FormatException");
                        }

                        Console.WriteLine("\n\n\nFor return to menu press any key");
                        Console.ReadKey();
                        break;
                    #endregion

                    #region 5 - to quit
                    case "5":
                        isQuit = true;
                        break;
                        #endregion
                }
            } while (!isQuit);

        }
    }
}
