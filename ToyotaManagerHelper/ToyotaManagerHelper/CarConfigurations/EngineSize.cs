using System;

namespace ToyotaManagerHelper.CarConfigurations
{
    public class EngineSize
    {
        public EngineSize()
        {

        }
        public EngineSize(string selectedEngineSize)
        {
            if (IsEngineSizeValid(selectedEngineSize))
            {
                this.SetSelectedEngineSize(selectedEngineSize);
                isEngineSizeTrue = true;
            }
            else isEngineSizeTrue = false;
        }

        public double engineSize { get; set; }
        public bool isEngineSizeTrue { get; set; }

        public bool IsEngineSizeValid(string selectedEngineSize)
        {
            if (selectedEngineSize == "1" || selectedEngineSize == "2" || selectedEngineSize == "3")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Selected engine size is incorrect, try to input engine size: 1 - 1.8, 2 - 2.0, 3 - 3.0");
                return false;
            }
        }

        public void SetSelectedEngineSize(string selectedEngineSize)
        {
            switch (selectedEngineSize)
            {
                case "1":
                    this.engineSize = 1.8;
                    break;
                case "2":
                    this.engineSize = 2.0;
                    break;
                case "3":
                    this.engineSize = 3.0;
                    break;
            }
        }
    }
}
