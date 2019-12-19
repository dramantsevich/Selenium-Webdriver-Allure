using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Allure.Commons;
using System;

namespace tTutBy
{
    public class DriverSingleton : AllureReport
    {
        private static IWebDriver driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (null == driver)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    default:
                        var co = new ChromeOptions();
                        co.AddArgument("no-sandbox");

                        driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), co, TimeSpan.FromMinutes(3));
                        driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
                        break;
                }
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
