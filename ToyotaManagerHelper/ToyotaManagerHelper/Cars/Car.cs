namespace ToyotaManagerHelper.Cars
{
    using System;

    public class Car
    {
        private int carCost;

        public Car(string model, double engineSize, string color, string transmission)
        {
            this.Model = model;
            this.EngineSize = engineSize;
            this.Color = color;
            this.Transmission = transmission;
        }

        public Car() { }

        public string Model { get; set; }

        public double EngineSize { get; set; }

        public string Color { get; set; }

        public string Transmission { get; set; }

        public override string ToString()
        {
            return $"{this.Model}\n engine size: {this.EngineSize}   color:{this.Color}   transmission:{this.Transmission}";
        }

        public virtual int GetCarCost()
        {
            this.carCost = Convert.ToInt32(270 * this.EngineSize) + (this.Color.Length * 367) + (this.Transmission.Length * 210);

            return this.carCost;
        }
    }
}
