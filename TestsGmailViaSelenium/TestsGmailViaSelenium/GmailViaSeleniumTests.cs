using NUnit.Framework;
using NUnit.Compatibility;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsGmailViaSelenium
{
    [TestFixture]
    public class GmailViaSeleniumTests
    {
        IWebDriver driver = new FirefoxDriver();
        
        [TestFixtureSetUp]
        public void AfterTests()
        {
            driver.Url = "https:/gmail.com"; 

            var email = driver.FindElement(By.Id("identifierId"));
            email.SendKeys("d.ramantsevich@gmail.com");

            driver.FindElement(By.CssSelector(".RveJvd")).Click();

            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("7182470Dima");

            driver.FindElement(By.CssSelector("#passwordNext > span:nth-child(3) > span:nth-child(1)")).Click();
        }

        [Test]
        public void ButtonSearch_IsWork()
        {
            var searchText = driver.FindElement(By.Name("q"));
            searchText.SendKeys("Xinuos");
            driver.FindElement(By.CssSelector(".gb_mf")).Click();
        }

        [Test]
        public void WriteMessage()
        {
            var btnWriteMessage = driver.FindElement(By.CssSelector(".T-I-KE"));
            btnWriteMessage.Click();

            var to = driver.FindElement(By.Name("to"));
            to.SendKeys("d.ramantsevich@gmail.com");

            var theme = driver.FindElement(By.Name("subjectbox"));
            theme.SendKeys("Theme1");

            var message = driver.FindElement(By.XPath("//*[@id=':q8']"));
            message.SendKeys("Theme1 theme1 theme1 theme1 theme1 theme1 theme1");

            driver.FindElement(By.XPath("//*[@id=':ot']")).Click();
        }

        [Test]
        public void DeleteMessage()
        {
            WriteMessage();

            var needToDelete = driver.FindElement(By.Name("я"));

            if(needToDelete.Text == "я")
            {
                driver.FindElement(By.XPath(@"#\:m9 > li:nth-child(2)")).Click();
            }
            else
            {
                Console.WriteLine("Message from me dont exist");
            }
        }

        [Test]
        public void QuitFromAccount()
        {
            driver.FindElement(By.CssSelector(".gb_xa")).Click();
            driver.FindElement(By.CssSelector("#gb_71")).Click();
        }

        [TearDown]
        public void BeforeTests()
        {
            driver.Close();
        }

    }
}
