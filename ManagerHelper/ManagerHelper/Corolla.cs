using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerHelper
{
    public class Corolla : Car
    {
        private string model;

        public string Model
        {
            get { return model = typeof(Corolla).Name; }
        }

        public Corolla(double _engineSize, string _color, int _selectedTransmission)
        {
            EngineSize = _engineSize;
            Color = _color;
            SelectedTransmission = _selectedTransmission;
        }

        public Corolla() { }

        public override string CarInformation()
        {
            return $"{Model}\n {base.CarInformation()}";
        }
    }
}
