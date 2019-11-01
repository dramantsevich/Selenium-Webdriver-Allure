using ToyotaManagerHelper.CarConfigurations;

namespace ToyotaManagerHelper.Builder
{
    public abstract class CarBuilderBase //: Car
    {
        protected Car car;

        protected CarBuilderBase()
        {
            this.car = new Car();
        }

        //protected CarBuilderBase(string model, double engineSize, string color, string transmission) : base(model, engineSize, color, transmission)
        //{

        //}

        public Car GetCar()
        {
            return car;
        }

        public abstract void BuildModel();
        public abstract void BuildModel(string model);
        public abstract void BuildEngine();
        public abstract void BuildEngine(string engine);
        public abstract void BuildColor();
        public abstract void BuildColor(string color);
        public abstract void BuildTransmission();
        public abstract void BuildTransmission(string transmission);
        public abstract void BuildCarWithFullCOnfigurations();
    }
}
