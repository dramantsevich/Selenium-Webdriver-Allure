using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerHelper
{
    public class Car
    {
        enum transmission
        {
            Manual = 1,
            Automatic,
            CVT
        }

        //fields
        public double EngineSize { get; set; }
        private string color;
        private int selectedTransmission;
        private int cost;

        private int transmissionCost;
        private int colorCost;
        const int LandCruiserCost = 4310;
        const int CamryCost = 3020;
        const int CorollaCost = 2570;

        public string Color
        {
            get { return color; }
            set
            {
                if(value == "Green")
                {
                    colorCost = 333 * value.Length;
                    color = value;
                }
                if (value == "Black")
                {
                    colorCost = 254 * value.Length;
                    color = value;
                }
                if (value == "Red")
                {
                    colorCost = 238 * value.Length;
                    color = value;
                }
                if (value == "Blue")
                {
                    colorCost = 220 * value.Length;
                    color = value;
                }
            }
        }
        public int SelectedTransmission
        {
            get { return selectedTransmission; }
            set
            {
                if ((int)transmission.Manual == 1)
                {
                    transmissionCost = 2120;
                    selectedTransmission = value;
                }
                if ((int)transmission.Automatic == 2)
                {
                    transmissionCost = 3630;
                    selectedTransmission = value;
                }
                if ((int)transmission.CVT == 3)
                {
                    transmissionCost = 2930;
                    selectedTransmission = value;
                }
            }
        }
        public int Cost
        {
            get
            {
                if (this.GetType().Name == "LandCruiser")
                {
                    return cost = LandCruiserCost + Convert.ToInt32(220 * this.EngineSize) + colorCost + this.transmissionCost;
                }
                if (this.GetType().Name == "Corolla")
                {
                    return cost = CorollaCost + Convert.ToInt32(220 * this.EngineSize) + colorCost + this.transmissionCost;
                }
                if (this.GetType().Name == "Camry")
                {
                    return cost = CamryCost + Convert.ToInt32(220 * this.EngineSize) + colorCost + this.transmissionCost;
                }
                return cost;
            }
        }

        public virtual string CarInformation()
        {
            return $"engine size: {EngineSize}   color:{Color}   transmission:{(transmission)SelectedTransmission}\n cost:{Cost}$";
        }
    }
}
