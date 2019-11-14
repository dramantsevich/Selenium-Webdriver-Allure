using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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

        [TestCase(@"\AttachFile.txt")]
        public void SentMessageWithAttachedFile_SentCorrectFileExtension(string fileName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            fluentWait = FluentWait.GetFluentWait(chromeDriver);

            gmailActions.SentMessageWithAttachedFile(this.currentEmail, $@"{path}{fileName}");

            foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'AttachFile.txt')]")));

            Assert.IsNotNull(foundMessage);
        }

        [TestCase(@"\iTechArt.7z")]
        public void SentMessageWithAttachedFile_SentIncorrectFileExtension(string fileName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            fluentWait = FluentWait.GetFluentWait(chromeDriver);

            gmailActions.SentMessageWithAttachedFile(this.currentEmail, $@"{path}{fileName}");

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
