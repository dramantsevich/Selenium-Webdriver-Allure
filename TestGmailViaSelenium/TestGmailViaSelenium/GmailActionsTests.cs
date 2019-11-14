using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;

namespace TestGmailViaSelenium
{
    public class GmailActionsTests
    {
        private IWebElement foundMessage;
        private IWebDriver chromeDriver;
        private GmailActionsController gmailActions;
        DefaultWait<IWebDriver> fluentWait;
        private string currentEmail;
        private string currentPassword;

        public GmailActionsController ChromeDriver(GmailActionsController gmailActions, IWebDriver chromeDriver)
        {
            gmailActions = new GmailActionsController(chromeDriver);
            this.gmailActions = gmailActions;
            return this.gmailActions;
        }

        [SetUp]
        public void SetUp()
        {
            List<string> emails = new List<string>();
            List<string> passwords = new List<string>();
            this.chromeDriver = new ChromeDriver();

            GetAccounts.GetAccount(emails, passwords);

            this.currentEmail = emails[0];
            this.currentPassword = passwords[0];

            ChromeDriver(gmailActions, this.chromeDriver);
            gmailActions.StartGmail(this.currentEmail, this.currentPassword);
        }

        [Test]
        public void StartGmail_LogInGmail()
        {
            //in method SetUp use method startGmail
            IWebElement account;
            IWebElement accountAddres;

            fluentWait = FluentWait.GetFluentWait(this.chromeDriver);

            account = fluentWait.Until(x => x.FindElement(By.XPath("//a[@class='gb_D gb_Fa gb_i']")));
            account.Click();

            accountAddres = fluentWait.Until(x => x.FindElement(By.XPath($"//div[contains(text(), '{this.currentEmail}')]")));

            Assert.IsTrue(accountAddres.Displayed);
        }

        [Test]
        public void QuitFromAccount()
        {
            fluentWait = FluentWait.GetFluentWait(this.chromeDriver);
            
            string currentURL = "https://accounts.google.com/ServiceLogin/signinchooser?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin";

            gmailActions.QuitFromAccount();

            bool actualResult = fluentWait.Until(ExpectedConditions.UrlContains(currentURL));

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void ButtonSearch_FoundMessage()
        {
            fluentWait = FluentWait.GetFluentWait(chromeDriver);

            gmailActions.ButtonSearch();

            foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Xinuos Inc.')]")));
            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void GetAddOns_IsVisible()
        {
            IWebElement newFrame;
            IWebElement titleOfNewFrame;
            fluentWait = FluentWait.GetFluentWait(chromeDriver);

            gmailActions.GetAddOns();

            newFrame = fluentWait.Until(x => x.FindElement(By.XPath("//div[@id='glass-content']/iframe")));
            chromeDriver.SwitchTo().Frame(newFrame);

            titleOfNewFrame = fluentWait.Until(x => x.FindElement(By.XPath("//span[@class='yQsxXc']")));

            Assert.IsTrue(titleOfNewFrame.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(2000);
            gmailActions.CloseGmail();
        }
    }
}
