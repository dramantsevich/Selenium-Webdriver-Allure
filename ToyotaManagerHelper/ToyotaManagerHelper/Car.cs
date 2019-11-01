using System;
using System.Text;

namespace ToyotaManagerHelper
{
    public class Car
    {
        public Car()
        {

        }

        private int carCost;

        public string Model { get; set; }
        public double EngineSize { get; set; }
        public string Color { get; set; }
        public string Transmission { get; set; }
        public int GetCarCost()
        {
            try
            {
                this.carCost = (this.Model.Length * 460) + Convert.ToInt32(270 * this.EngineSize) + (this.Color.Length * 367) + (this.Transmission.Length * 210);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Incorrect data: NullReferenceException");
            }
            return this.carCost;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("{0}\n", this.Model);
            sb.AppendFormat("Engine:{0} ", this.EngineSize);
            sb.AppendFormat("Color:{0} ", this.Color);
            sb.AppendFormat("Transmission:{0}\n", this.Transmission);
            sb.AppendFormat("Cost:{0}$\n", this.GetCarCost());

            return sb.ToString();
        }
    }
}
