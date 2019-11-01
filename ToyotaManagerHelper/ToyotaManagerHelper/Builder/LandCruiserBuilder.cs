using ToyotaManagerHelper.CarConfigurations;
using System;

namespace ToyotaManagerHelper.Builder
{
    public class LandCruiserBuilder : CarBuilderBase
    {
        public LandCruiserBuilder() : base()
        {

        }

        public override void BuildModel()
        {
            car.Model = "LandCruiser";
        }

        public override void BuildModel(string model)
        {
            car.Model = model;
        }

        public override void BuildEngine()
        {

            Console.WriteLine("Input engine size: 1 - 1.8, 2 - 2.0, 3 - 3.0");
            string selectedEngineSize = Console.ReadLine();

            EngineSize EngineSize = new EngineSize(selectedEngineSize);
            
            if(EngineSize.isEngineSizeTrue == true)
            {
                car.EngineSize = EngineSize.engineSize;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public override void BuildEngine(string engine)
        {
            car.EngineSize = Convert.ToDouble(engine);
        }

        public override void BuildColor()
        {
            Console.WriteLine("Input color: 1-Green, 2-Black, 3-Red, 4-Blue");
            string selectedColor = Console.ReadLine();

            Color Color = new Color(selectedColor);

            if(Color.isColorTrue == true)
            {
                car.Color = Color.color;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public override void BuildColor(string color)
        {
            car.Color = color;
        }

        public override void BuildTransmission()
        {
            Console.WriteLine("Input transmission: 1-Manual, 2-Automatic, 3-CVT");
            string selectedTransmission = Console.ReadLine();

            Transmission Transmission = new Transmission(selectedTransmission);

            if(Transmission.isTransmissionTrue == true)
            {
                car.Transmission = Transmission.transmission;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public override void BuildTransmission(string transmission)
        {
            car.Transmission = transmission;
        }

        public override void BuildCarWithFullCOnfigurations()
        {
            this.BuildModel();
            this.BuildEngine();
            this.BuildColor();
            this.BuildTransmission();
        }
    }
}
