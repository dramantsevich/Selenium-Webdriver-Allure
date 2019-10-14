using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaManager
{
    [Serializable]
    public class Camry : Car
    {
        private string model;
        const int modelCamryCost = 3050;

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
            return $"{this.Model}\n {this.CarsEquipment()}\n cost:{CarCost}";
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
