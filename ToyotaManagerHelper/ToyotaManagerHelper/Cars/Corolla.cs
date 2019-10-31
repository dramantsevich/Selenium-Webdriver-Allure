namespace ToyotaManagerHelper.Cars
{
    public class Corolla : Car
    {
        public Corolla(string model, double engineSize, string color, string transmission)
            : base(model, engineSize, color, transmission)
        {
        }

        public Corolla() { }

        public Corolla(string model) { this.Model = model; }

        public override string ToString()
        {
            return $"{base.ToString()}\n cost:{this.GetCarCost()}$";
        }

        public override int GetCarCost()
        {
            return (this.Model.Length * 640) + base.GetCarCost();
        }
    }
}
