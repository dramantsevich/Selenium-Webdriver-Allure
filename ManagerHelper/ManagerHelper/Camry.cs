using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerHelper
{
    public class Camry : Car
    {
        private string model;

        public string Model
        {
            get { return model = typeof(Camry).Name; }
        }

        public Camry(double _engineSize, string _color, int _selectedTransmission)
        {
            EngineSize = _engineSize;
            Color = _color;
            SelectedTransmission = _selectedTransmission;
        }

        public Camry() { }

        public override string CarInformation()
        {
            return $"{Model}\n {base.CarInformation()}";
        }
    }
}