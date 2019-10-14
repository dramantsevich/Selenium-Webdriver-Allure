using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaManager
{
    [Serializable]
    public class Car
    {
        enum transmission
        {
            Manual = 1,
            Automatic,
            CVT
        }
        
        private double engineSize;
        private string color;
        private int selectedTransmission;

        const int colorCost = 400;
        private int complectationCost;
        private int transmissionCost;

        public int CarCost { get; set; }

        public double EngineSize
        {
            get { return engineSize; }
            set
            {
                engineSize = value;
            }
        }

        public string Color
        {
            get { return color; }
            set
            {
                color = value;
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

        public int ComplectationCost
        {
            get { return complectationCost = 200 * Convert.ToInt32(EngineSize) + colorCost + transmissionCost; }
        }

        public virtual void SetCarCost()
        {
            //пример полиморфизма
        }

        public void DisplayComplectationCost()
        {
            Console.WriteLine(ComplectationCost);
        }

        public string CarsEquipment()
        {
            return $"engineSize:{EngineSize} color:{Color} transmission:{(transmission)SelectedTransmission}";
        }
    }
}
