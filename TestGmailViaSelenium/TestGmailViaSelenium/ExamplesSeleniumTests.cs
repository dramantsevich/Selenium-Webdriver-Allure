using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Collections.Generic;
using Jint;

namespace TestGmailViaSelenium
{
    class ExamplesSeleniumTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {

            driver = new ChromeDriver();
            driver.Url = "http://toolsqa.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SimpleAlert()
        {
            //This step produce an alert on screen
            driver.FindElement(By.XPath("//button[contains(text(),'Simple Alert')]")).Click();

            IAlert simpleAlert = driver.SwitchTo().Alert();

            // '.Text' is used to get the text from the Alert
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is " + alertText);

            Thread.Sleep(3000);

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            simpleAlert.Accept();
        }

        [Test]
        public void COnfirmationAlert()
        {
         //This step produce an alert on screen
            IWebElement element = driver.FindElement(By.XPath("//button[contains(text(),'Confirm Pop up')]"));

            // Switch the control of 'driver' to the Alert from main window
            IAlert confirmationAlert = driver.SwitchTo().Alert();
            Engine engine = new Engine();
            // Get the Text of Alert
            String alertText = confirmationAlert.Text;

            Console.WriteLine("Alert text is " + alertText);

            //'.Dismiss()' is used to cancel the alert '(click on the Cancel button)'
            confirmationAlert.Dismiss();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
