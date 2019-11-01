using System;

namespace ToyotaManagerHelper.CarConfigurations
{
    public class Transmission
    {
        public Transmission()
        {

        }
        public Transmission(string selectedTransmission)
        {
            if (this.IsTransmissionValid(selectedTransmission))
            {
                this.SetSelectedTransmission(selectedTransmission);
                isTransmissionTrue = true;
            }
            else isTransmissionTrue = false;
        }
        public string transmission { get; set; }
        public bool isTransmissionTrue { get; set; }

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

        public void SetSelectedTransmission(string selectedTransmission)
        {
            switch (selectedTransmission)
            {
                case "1":
                    this.transmission = "Manual";
                    break;
                case "2":
                    this.transmission = "Automatic";
                    break;
                case "3":
                    this.transmission = "CVT";
                    break;
            }
        }
    }
}
