using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaManagerHelper
{
    public class Camry : Car
    {
        private string model;
        const int modelCamryCost = 3020;

        public string Model
        {
            get { return model = "Camry"; }
        }

        public override void SetCarCost()
        {
            this.CarCost = this.ComplectationCost + modelCamryCost;
        }

        public override string ToString()
        {
            return $"{DisplaySelectedConfiguration()}\n cost:{CarCost}";
        }

        public override string DisplaySelectedConfiguration()
        {
            return $"{Model}\n {base.DisplaySelectedConfiguration()}";
        }

        public Camry(double _engineSize, string _color, int _selectedTransmission)
        {
            EngineSize = _engineSize;
            Color = _color;
            SelectedTransmission = _selectedTransmission;
            SetCarCost();
        }
    }
}
