using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TestGmailViaSelenium
{
    public class GmailTests
    {
        private IWebDriver driver;
        private IWebElement foundMessage;
        DefaultWait<IWebDriver> fluentWait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            GmailController.StartGmail(driver);
        }

        [Test]
        public void ButtonSearh_FoundMessage()
        {
            IWebElement searchInMailField;
            IWebElement searchButton;
            
            fluentWait = GmailController.GetFluentWait(driver);

            searchInMailField = fluentWait.Until(x => x.FindElement(By.XPath("//input[@placeholder='Search mail']")));
            searchInMailField.SendKeys("Xinuos");

            searchButton = fluentWait.Until(x => x.FindElement(By.XPath("//button[@aria-label='Search Mail']")));
            searchButton.Click();

            foundMessage = fluentWait.Until(x => x.FindElement(By.Name("Xinuos Inc.")));
            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void QuitFromAccount()
        {
            IWebElement account;
            IWebElement logOutFromAccount;

            string currentURL = "https://accounts.google.com/ServiceLogin/signinchooser?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin";

            fluentWait = GmailController.GetFluentWait(driver);

            account = fluentWait.Until(x => x.FindElement(By.XPath("//a[@class='gb_D gb_Fa gb_i']")));
            account.Click();

            logOutFromAccount = fluentWait.Until(x => x.FindElement(By.XPath("//a[@id='gb_71']")));
            logOutFromAccount.Click();

            bool actualResult = fluentWait.Until(ExpectedConditions.UrlContains(currentURL));

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void GetAddOnsFrame_IsVisible()
        {
            IWebElement getAddOns;
            IWebElement newFrame;
            bool isTrue = false;

            fluentWait = GmailController.GetFluentWait(driver);

            getAddOns = fluentWait.Until(x => x.FindElement(By.XPath("//div[@id='p2DdMb']//div[@class='aT5-aOt-I-JX-Jw']")));
            getAddOns.Click();

            if (GmailController.IsElementPresent(By.XPath("//div[@id='glass-content']"), driver))
            {
                newFrame = fluentWait.Until(x => x.FindElement(By.XPath("//div[@id='glass-content']/iframe")));
                driver.SwitchTo().Frame(newFrame);

                if (GmailController.IsElementPresent(By.XPath("//span[@class='yQsxXc']"), driver))
                {
                    isTrue = true;
                    System.Console.WriteLine("New frame is displayed");
                    Assert.IsTrue(isTrue);
                }
                else
                {
                    System.Console.WriteLine("fail");
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(2000);
            driver.Close();
            driver.Quit();
        }
    }
}