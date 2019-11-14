using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TestGmailViaSelenium
{
    class GmailMessagesTests
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
        public void SentMessage()
        {
            fluentWait = FluentWait.GetFluentWait(chromeDriver);

            gmailActions.SentMessage(this.currentEmail);

            foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Theme1')]")));

            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void SentMessageWithAttachedFile_SentCorrectFileExtension()
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;

            string fileCurrentPath = @"..\..\..\Account.txt";

            string path = Path.GetFullPath(Path.Combine(currentPath, fileCurrentPath));

            fluentWait = FluentWait.GetFluentWait(chromeDriver);

            gmailActions.SentMessageWithAttachedFile(this.currentEmail, path);

            foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Account.txt')]")));

            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void SentMessageWithAttachedFile_SentIncorrectFileExtension()
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;

            string fileCurrentPath = @"..\..\..\iTechArt.7z";

            string path = Path.GetFullPath(Path.Combine(currentPath, fileCurrentPath));

            fluentWait = FluentWait.GetFluentWait(chromeDriver);

            gmailActions.SentMessageWithAttachedFile(this.currentEmail, path);

            IAlert alert = fluentWait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();

            foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[@class='y2']/span[contains(text(),'')]")));

            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void SentEmptyMessageForm_IsDisplayedErrorPopUpWindow()
        {
            IWebElement errorForm;

            fluentWait = FluentWait.GetFluentWait(chromeDriver);

            gmailActions.SentEmptyMessageForm();

            errorForm = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='Kj-JD-K7 Kj-JD-K7-bsT']")));

            Assert.IsTrue(errorForm.Displayed);
        }

        [Test]
        public void DeleteMessageFrom_DeleteAllMessagesFromGivenEmail()
        {
            fluentWait = FluentWait.GetFluentWait(chromeDriver);

            gmailActions.DeleteSentMessagesFrom(this.currentEmail);

            bool isFoundMessage = gmailActions.IsElementPresent(By.XPath($"//div[2]/span[@class='bA4']/span[@email='{this.currentEmail}']"));

            Assert.IsTrue(isFoundMessage);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(2000);
            gmailActions.CloseGmail();
        }
    }
}
