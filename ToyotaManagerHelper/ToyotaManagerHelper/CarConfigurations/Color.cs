using System;

namespace ToyotaManagerHelper.CarConfigurations
{
    public class Color
    {
        public Color()
        {

        }
        public Color(string selectedColor)
        {
            if (this.IsColorValid(selectedColor))
            {
                this.SetSelectedColor(selectedColor);
                isColorTrue = true;
            }
            else isColorTrue = false;
        }

        public string color { get; set; }
        public bool isColorTrue { get; set; }

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

        public void SetSelectedColor(string selectedColor)
        {
            switch (selectedColor)
            {
                case "1":
                    this.color = "Green";
                    break;
                case "2":
                    this.color = "Black";
                    break;
                case "3":
                    this.color = "Red";
                    break;
                case "4":
                    this.color = "Blue";
                    break;
            }
        }
    }
}
