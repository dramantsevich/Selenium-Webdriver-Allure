using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaManagerHelper
{
    public class Car
    {
        enum transmission
        {
            Manual = 1,
            Automatic,
            CVT
        }
        
        public double EngineSize { get; set; }
        public string Color { get; set; }
        private int selectedTransmission;

        const int colorCost = 400;
        public int complectationCost;
        private int transmissionCost;

        public int CarCost { get; set; }

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
            get { return complectationCost =  Convert.ToInt32(220 * EngineSize) + colorCost + transmissionCost; }
        }

        public virtual void SetCarCost()
        {

        }

        public virtual string DisplaySelectedConfiguration()
        {
            return $"engineSize:{EngineSize} color:{Color} transmission:{(transmission)SelectedTransmission} complectation cost:{complectationCost}";
        }
    }
}
