using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaManagerHelper
{
    public class LandCruiser : Car
    {
        private string model;
        const int modelLandCruiserCost = 4310;

        public string Model
        {
            get { return model = "LandCruiser"; }
        }

        public override void SetCarCost()
        {
            this.CarCost = this.ComplectationCost + modelLandCruiserCost;
        }

        public override string ToString()
        {
            return $"{DisplaySelectedConfiguration()}\n cost:{this.CarCost}";
        }

        public override string DisplaySelectedConfiguration()
        {
            return $"{Model}\n {base.DisplaySelectedConfiguration()}";
        }

        public LandCruiser(double _engineSize, string _color, int _selectedTransmission)
        {
            EngineSize = _engineSize;
            Color = _color;
            SelectedTransmission = _selectedTransmission;
            SetCarCost();
        }
    }
}
