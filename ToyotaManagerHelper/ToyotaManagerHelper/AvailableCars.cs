using System.Collections.Generic;
using System.IO;
using ToyotaManagerHelper.Builder;

namespace ToyotaManagerHelper
{
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
                    string engineSize = carsParameters[1];
                    string color = carsParameters[2];
                    string transmission = carsParameters[3];

                    if(model == "LandCruiser")
                    {
                        var lcBuilder = new LandCruiserBuilder();
                        lcBuilder.BuildModel(model);
                        lcBuilder.BuildEngine(engineSize);
                        lcBuilder.BuildColor(color);
                        lcBuilder.BuildTransmission(transmission);

                        var lcCar = lcBuilder.GetCar();

                        cars.Add(lcCar);
                    }

                    if(model == "Camry")
                    {
                        var camryBuilder = new CamryBuilder();
                        camryBuilder.BuildModel(model);
                        camryBuilder.BuildEngine(engineSize);
                        camryBuilder.BuildColor(color);
                        camryBuilder.BuildTransmission(transmission);

                        var camryCar = camryBuilder.GetCar();

                        cars.Add(camryCar);
                    }

                    if(model == "Corolla")
                    {
                        var corollaBuilder = new CorollaBuilder();
                        corollaBuilder.BuildModel(model);
                        corollaBuilder.BuildEngine(engineSize);
                        corollaBuilder.BuildColor(color);
                        corollaBuilder.BuildTransmission(transmission);

                        var corollaCar = corollaBuilder.GetCar();

                        cars.Add(corollaCar);
                    }
                }
            }
        }

    }
}
