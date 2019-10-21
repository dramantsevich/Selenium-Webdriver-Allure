using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerHelper
{
    public class LandCruiser : Car
    {
        private string model;

        public string Model
        {
            get { return model = typeof(LandCruiser).Name; }
        }

        public LandCruiser(double _engineSize, string _color, int _selectedTransmission)
        {
            EngineSize = _engineSize;
            Color = _color;
            SelectedTransmission = _selectedTransmission;
        }

        public LandCruiser() { }

        public override string CarInformation()
        {
            return $"{Model}\n {base.CarInformation()}";
        }
    }
}