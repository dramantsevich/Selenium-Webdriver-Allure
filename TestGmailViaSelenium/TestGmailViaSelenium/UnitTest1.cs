using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestGmailViaSelenium
{
    public class Tests
    {
        private IWebDriver driver;
        private string webSiteUrl;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            webSiteUrl = "https://gmail.com/";

            driver.Navigate().GoToUrl(webSiteUrl);

            var email = driver.FindElement(By.Name("identifier"));
            email.SendKeys("d.ramantsevich@gmail.com");

            var identifierNext = driver.FindElement(By.Id("identifierNext"));
            identifierNext.Click();

            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("7182470Dima");

            var passwordNext = driver.FindElement(By.Id("passwordNext"));
            passwordNext.Click();
        }

        public static DefaultWait<IWebDriver> GetFluentWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(50);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }

        [Test]
        public void ButtonSearh_FoundMessage()
        {
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
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            IWebElement writeMessageButton = driver.FindElement(By.CssSelector(".T-I-KE"));
            writeMessageButton.Click();

            IWebElement writeTo = driver.FindElement(By.XPath("//*[@id=':pl']"));
            writeTo.SendKeys("d.ramantsevich@gmail.com");

            IWebElement theme = driver.FindElement(By.Name("subjectbox"));
            theme.SendKeys("Theme1");

            IWebElement messageBody = driver.FindElement(By.XPath("//*[@id=':q8']"));
            messageBody.SendKeys("qwerty");

            IWebElement sentMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=':ot']")));
            sentMessageButton.Click();

            IWebElement foundMessage = fluentWait.Until(x => x.FindElement(By.Name("ÿ")));
            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void DeleteMessage()
        {
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            IWebElement foundMessage = fluentWait.Until(x => x.FindElement(By.Name("ÿ")));
            IWebElement deleteMessageButton;

            if (foundMessage != null)
            {
                //fluentWait.Until(x => x.FindElement(By.CssSelector(@"#\:2x > li:nth-child(2)"))).Click();

                //deleteMessageButton = driver.FindElement(By.CssSelector(@"#\:2x > li:nth-child(2)"));
                new WebDriverWait(driver, TimeSpan.FromSeconds(50)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div/div[2]/div/div[1]/div/div/div[6]/div/div[1]/div[3]/div/table/tbody/tr[1]/td[10]/ul/li[2]"))).Click();

                foundMessage = null;

                Assert.IsNull(foundMessage);
            }
            else
            {
                Assert.Fail("Message from 'ÿ' not found");
            }
        }

        [Test]
        public void QuitFromAccount()
        {
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