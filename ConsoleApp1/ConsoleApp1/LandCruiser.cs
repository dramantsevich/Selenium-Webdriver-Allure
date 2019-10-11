﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class LandCruiser : Car
    {
        private string model;
        const int modelLCCost = 4500;

        public string Model
        {
            get { return model = "LandCruiser"; }
        }

        public override void DisplayCarCost()
        {
            this.CarCost = this.ComplectationCost + modelLCCost;
        }

        public override string ToString()
        {
            return $"{this.Model}\n {this.CarsEquipment()}\n cost:{this.CarCost}";
        }

        public LandCruiser(double _engineSize, string _color, int _selectedTransmission)
        {
            EngineSize = _engineSize;
            Color = _color;
            SelectedTransmission = _selectedTransmission;
            DisplayCarCost();
        }
    }
}