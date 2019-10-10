using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Camry : Car
    {
        private string model;
        private int CamryCost;
        const int modelCamryCost = 3050;

        public string Model
        {
            get { return model = "Camry"; }
        }

        public override string ToString()
        {
            return $"{this.Model}\n {this.CarsEquipment()}\n cost:{CamryCost = this.Cost + modelCamryCost}";
        }

        public Camry(double _engineSize, string _color, int _selectedTransmission)
        {
            EngineSize = _engineSize;
            Color = _color;
            SelectedTransmission = _selectedTransmission;
        }
    }
}
