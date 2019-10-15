using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaManagerHelper
{
    public class Corolla : Car
    {
        private string model;
        const int modelCorollaCost = 2570;

        public string Model
        {
            get { return model = "Corolla"; }
        }

        public override void SetCarCost()
        {
            this.CarCost = this.ComplectationCost + modelCorollaCost;
        }

        public override string ToString()
        {
            return $"{DisplaySelectedConfiguration()}\n cost:{CarCost}";
        }
        
        public override string DisplaySelectedConfiguration()
        {
            return $"{Model}\n {base.DisplaySelectedConfiguration()}";
        }

        public Corolla(double _engineSize, string _color, int _selectedTransmission)
        {
            EngineSize = _engineSize;
            Color = _color;
            SelectedTransmission = _selectedTransmission;
            SetCarCost();
        }
    }
}
