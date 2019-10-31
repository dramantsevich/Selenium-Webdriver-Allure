namespace ToyotaManagerHelper
{
    using System;
    using ToyotaManagerHelper.Cars;

    public class CarCreator : Car
    {
        private readonly Car car;

        public CarCreator(Car car, string model)
        {
            this.car = car;
            this.Model = model;
        }

        public void SetConfigurations()
        {
            Console.WriteLine("Input engine size: 1 - 1.8, 2 - 2.0, 3 - 3.0");
            string selectedEngineSize = Console.ReadLine();

            if (this.IsEngineSizeValid(selectedEngineSize))
            {
                Console.WriteLine("Input color: 1-Green, 2-Black, 3-Red, 4-Blue");
                string selectedColor = Console.ReadLine();

                if (this.IsColorValid(selectedColor))
                {
                    Console.WriteLine("Input transmission: 1-Manual, 2-Automatic, 3-CVT");
                    string selectedTransmission = Console.ReadLine();
                    if (this.IsTransmissionValid(selectedTransmission))
                    {
                        this.SetSelectedEngineSize(selectedEngineSize);

                        this.SetSelectedColor(selectedColor);

                        this.SetSelectedTransmission(selectedTransmission);
                    }
                }
            }
        }

        public bool IsEngineSizeValid(string selectedEngineSize)
        {
            if (selectedEngineSize == "1" || selectedEngineSize == "2" || selectedEngineSize == "3")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Selected engine size is incorrect, try to input engine size: 1 - 1.8, 2 - 2.0, 3 - 3.0");
                return false;
            }
        }

        public bool IsColorValid(string selectedColor)
        {
            if (selectedColor == "1" || selectedColor == "2" || selectedColor == "3" || selectedColor == "4")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Selected color is incorrect, try to input color: 1-Green, 2-Black, 3-Red, 4-Blue");
                return false;
            }
        }

        public bool IsTransmissionValid(string selectedTransmission)
        {
            if (selectedTransmission == "1" || selectedTransmission == "2" || selectedTransmission == "3")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Selected transmission is incorrect, try to input transmission: 1-Manual, 2-Automatic, 3-CVT");
                return false;
            }
        }

        public void SetSelectedEngineSize(string selectedEngineSize)
        {
            switch (selectedEngineSize)
            {
                case "1":
                    this.EngineSize = 1.8;
                    break;
                case "2":
                    this.EngineSize = 2.0;
                    break;
                case "3":
                    this.EngineSize = 3.0;
                    break;
            }
        }

        public void SetSelectedColor(string selectedColor)
        {
            switch (selectedColor)
            {
                case "1":
                    this.Color = "Green";
                    break;
                case "2":
                    this.Color = "Black";
                    break;
                case "3":
                    this.Color = "Red";
                    break;
                case "4":
                    this.Color = "Blue";
                    break;
            }
        }

        public void SetSelectedTransmission(string selectedTransmission)
        {
            switch (selectedTransmission)
            {
                case "1":
                    this.Transmission = "Manual";
                    break;
                case "2":
                    this.Transmission = "Automatic";
                    break;
                case "3":
                    this.Transmission = "CVT";
                    break;
            }
        }

        public override int GetCarCost()
        {
            return (this.Model.Length * 460) + base.GetCarCost();
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n cost:{this.GetCarCost()}$";
        }
    }
}
