using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Corolla : Car
    {
        private string model;
        private int CorollaCost;
        const int modelCorollaCost = 2550;

        public string Model
        {
            get { return model = "Corolla"; }
        }

        public override string ToString()
        {
            return $"{this.Model}\n {this.CarsEquipment()}\n cost:{CorollaCost = this.Cost + modelCorollaCost}";
        }

        public Corolla(double _engineSize, string _color, int _selectedTransmission)
        {
            EngineSize = _engineSize;
            Color = _color;
            SelectedTransmission = _selectedTransmission;
        }
    }
}
