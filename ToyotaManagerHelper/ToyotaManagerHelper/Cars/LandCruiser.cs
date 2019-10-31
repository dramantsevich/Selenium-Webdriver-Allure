namespace ToyotaManagerHelper.Cars
{
    public class LandCruiser : Car
    {
        public LandCruiser(string model, double engineSize, string color, string transmission)
            : base(model, engineSize, color, transmission)
        {
        }

        public LandCruiser() { }

        public LandCruiser(string model) { this.Model = model; }

        public override string ToString()
        {
            return $"{base.ToString()}\n cost:{this.GetCarCost()}$";
        }

        public override int GetCarCost()
        {
            return (this.Model.Length * 460) + base.GetCarCost();
        }
    }
}
