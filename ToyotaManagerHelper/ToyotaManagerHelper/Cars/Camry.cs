namespace ToyotaManagerHelper.Cars
{
    public class Camry : Car
    {
        public Camry(string model, double engineSize, string color, string transmission)
            : base(model, engineSize, color, transmission)
        {
        }

        public Camry()
        {
        }

        public Camry(string model) { this.Model = model; }

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
