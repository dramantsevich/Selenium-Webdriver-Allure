using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class LandCruiser : Car
    {
        private string model;
        private int LandCruiserCost;
        const int modelLCCost = 4500;

        public string Model
        {
            get { return model = "LandCruiser"; }
        }

        public override string ToString()
        {
            return $"{this.Model}\n {this.CarsEquipment()}\n cost:{LandCruiserCost = this.Cost + modelLCCost}";
        }

        public LandCruiser(double _engineSize, string _color, int _selectedTransmission)
        {
            EngineSize = _engineSize;
            Color = _color;
            SelectedTransmission = _selectedTransmission;
        }
    }
}
