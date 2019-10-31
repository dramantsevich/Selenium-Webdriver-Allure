namespace ToyotaManagerHelper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using ToyotaManagerHelper.Cars;

    public class AvailableCars
    {
        public static void GetAvailableCars(List<Car> cars)
        {
            string path = @"..\..\..\Resources\CarsAvailable.txt";

            using (StreamReader textStreamReader = new StreamReader(path))
            {
                string line;

                while ((line = textStreamReader.ReadLine()) != null)
                {
                    string[] carsParameters = line.Split(new char[] { ' ' }); // divide each line into words

                    string model = carsParameters[0];
                    double engineSize = Convert.ToDouble(carsParameters[1]);
                    string color = carsParameters[2];
                    string transmission = carsParameters[3];

                    if (model == typeof(LandCruiser).Name)
                    {
                        cars.Add(new LandCruiser(model, engineSize, color, transmission));
                    }

                    if (model == typeof(Camry).Name)
                    {
                        cars.Add(new Camry(model, engineSize, color, transmission));
                    }

                    if (model == typeof(Corolla).Name)
                    {
                        cars.Add(new Corolla(model, engineSize, color, transmission));
                    }
                }
            }
        }
    }
}
