using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsGmailViaSelenium
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            //IWebDriver driver = new FirefoxDriver();

            //driver.Url = "https://google.com";

            //var url = driver.Title;

            //Assert.IsTrue(url == "Google");
            IWebDriver driver;

            driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://toolsqa.com/automation-practice-form");

            IList<IWebElement> rdBtn_Sex = driver.FindElements(By.Name("sex"));

            Boolean bValue = false;

            bValue = rdBtn_Sex.ElementAt(0).Selected;

            if (bValue == true)
            {
                rdBtn_Sex.ElementAt(1).Click();
            }
            else
            {
                rdBtn_Sex.ElementAt(0).Click();
            }

            IWebElement rdBtn_Exp = driver.FindElement(By.Id("exp-4"));
            rdBtn_Exp.Click();

            IList<IWebElement> chkBx_Profession = driver.FindElements(By.Name("profession"));

            int iSize = chkBx_Profession.Count;

            for(int i = 0; i < iSize; i++)
            {
                string value = chkBx_Profession.ElementAt(i).GetAttribute("value");

                if(value.Equals("Automation Tester"))
                {
                    chkBx_Profession.ElementAt(i).Click();
                    break;
                }
            }

            IWebElement oCheckBox = driver.FindElement(By.CssSelector("input[value='QTP']"));
            oCheckBox.Click();

            driver.Close();
        }

        [Test]
        public void Test2()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Url = "http://toolsqa.com/automation-practice-form";

            SelectElement oSelection = new SelectElement(driver.FindElement(By.Id("continents")));

            oSelection.SelectByIndex(1);

            oSelection.SelectByText("Africa");

            IList<IWebElement> oSize = oSelection.Options;

            int iListSize = oSize.Count;

            for(int i =0; i < iListSize; i++)
            {
                string sValue = oSelection.Options.ElementAt(i).Text;
                Console.WriteLine("value: " + sValue);

                if (sValue.Equals("Africa"))
                {
                    oSelection.SelectByIndex(i);
                    break;
                }
            }

            driver.Close();
        }

        [Test]
        public void Test3()
        {
            IWebDriver driver;

            driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("https://www.toolsqa.com/automation-practice-form");

            SelectElement oSelection = new SelectElement(driver.FindElement(By.Name("selenium_commands")));

            oSelection.SelectByIndex(1);
            oSelection.DeselectByIndex(1);

            oSelection.SelectByText("Browser Commands");
            oSelection.DeselectByText("Browser Commands");

            IList<IWebElement> oSize = oSelection.Options;
            int iLitSize = oSize.Count;

            for(int i = 0; i < iLitSize; i++)
            {
                string sValue = oSelection.Options.ElementAt(i).Text;
                Console.WriteLine("Value: " + sValue);

                oSelection.SelectByIndex(i);
            }

            oSelection.DeselectAll();

            driver.Close();

        }
    }
}