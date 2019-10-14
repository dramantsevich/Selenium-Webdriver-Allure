using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaManager
{
    [Serializable]
    public class Corolla : Car
    {
        private string model;
        const int modelCorollaCost = 2550;

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
            return $"{this.Model}\n {this.CarsEquipment()}\n cost:{CarCost}";
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
