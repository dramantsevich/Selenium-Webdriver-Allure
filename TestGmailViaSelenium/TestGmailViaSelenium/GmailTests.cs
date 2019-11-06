using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Collections.Generic;

namespace TestGmailViaSelenium
{
    public class GmailTests
    {
        private IWebDriver driver;
        private string webSiteUrl;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            webSiteUrl = "https://gmail.com/";

            driver.Navigate().GoToUrl(webSiteUrl);

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            IWebElement email = fluentWait.Until(x => x.FindElement(By.Name("identifier")));
            email.SendKeys("d.ramantsevich@gmail.com");

            IWebElement identifierNext = fluentWait.Until(x => x.FindElement(By.Id("identifierNext")));
            identifierNext.Click();

            IWebElement password = fluentWait.Until(x => x.FindElement(By.Name("password")));
            password.SendKeys("7182470Dima");

            IWebElement passwordNext = fluentWait.Until(x => x.FindElement(By.Id("passwordNext")));
            passwordNext.Click();
        }

        public static DefaultWait<IWebDriver> GetFluentWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(25);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(1700);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }

        [Test]
        public void ButtonSearh_FoundMessage()
        {
            Thread.Sleep(3000);
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            IWebElement searchInMailField = driver.FindElement(By.Name("q"));
            searchInMailField.SendKeys("Xinuos");

            IWebElement searchInMailButton = fluentWait.Until(x => x.FindElement(By.CssSelector(".gb_mf")));
            searchInMailButton.Click();

            IWebElement foundMessage = fluentWait.Until(x => x.FindElement(By.Name("Xinuos")));
            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void WriteMessage()
        {
            Thread.Sleep(3000);
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            IWebElement writeMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='z0']/div[1]")));
            writeMessageButton.Click();

            IWebElement writeTo = fluentWait.Until(x => x.FindElement(By.Name("to")));
            writeTo.SendKeys("d.ramantsevich@gmail.com");

            IWebElement theme = fluentWait.Until(x => x.FindElement(By.Name("subjectbox")));
            theme.SendKeys("Theme1");

            IWebElement messageBody = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            messageBody.SendKeys("qwerty");
            messageBody.SendKeys(Keys.Control + Keys.Enter);

            IWebElement foundMessage = fluentWait.Until(x => x.FindElement(By.Name("ÿ")));
            Assert.IsNotNull(foundMessage);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [Test]
        public void DeleteMessage()
        {
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            IWebElement foundMessage;
            IWebElement deleteMessageButton;
            IWebElement selectFoundMessage;

            //span[@data-hovercard-owner-id='132']

            if (IsElementPresent(By.XPath(".//*[text()='das']/")))
            {
                foundMessage = fluentWait.Until(x => x.FindElement(By.Name("ÿ")));

                if (foundMessage.GetAttribute("name") == "ÿ")
                {
                    Console.WriteLine("EXIST");

                    selectFoundMessage = fluentWait.Until(x => x.FindElement(By.XPath("/html[1]/body[1]/div[7]/div[3]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[3]/div[1]/table[1]/tbody[1]/tr[1]/td[2]/div[1]")));
                    selectFoundMessage.Click();

                    deleteMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//ul[@id=':2w']//li[@class='bqX bru']")));
                    deleteMessageButton.Click();

                    foundMessage = null;

                    Assert.IsNull(foundMessage);
                }
                else { 
                    Console.WriteLine("fail"); 
                }
            }
            else
            {
                Assert.Fail("fail");
            }
        }

        [Test]
        public void QuitFromAccount()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".gb_xa")).Click();
            driver.FindElement(By.CssSelector("#gb_71")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
        }
    }
}