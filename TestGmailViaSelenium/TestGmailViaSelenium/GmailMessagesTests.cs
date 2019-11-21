using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestGmailViaSelenium
{
    class GmailMessagesTests
    {
        private IWebElement foundMessage;
        private IWebDriver currentDriver;
        private GmailController gmailController;
        DefaultWait<IWebDriver> fluentWait;
        string firstMail;
        string firstPassword;
        string themeOfMessage;
        string messageBody;

        [SetUp]
        public void SetUp()
        {

            this.currentDriver = new ChromeDriver();

            this.gmailController = new GmailController(this.currentDriver);

            this.firstMail = gmailController.GetFirstMail();
            this.firstPassword = gmailController.GetFirstPassword();

            gmailController.StartGmail(firstMail, firstPassword);
        }

        [Test]
        public void SentMessage()
        {
            themeOfMessage = "Test method SentMessage";
            messageBody = "sent a message to the method being tested SentMessage()";

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            gmailController.SentMessage(this.firstMail, themeOfMessage, messageBody);

            foundMessage = fluentWait.Until(x => x.FindElement(By.XPath($"//span[contains(text(),'{themeOfMessage}')]")));

            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void SentMessageWithAttachedFile_SentCorrectFileExtension()
        {
            themeOfMessage = "Message with attached file";
            messageBody = "sent a message to the method being tested SentMessageWithAttachedFile()";
            string fileName = "Account.txt";
            string path = gmailController.GetFilePath(fileName);

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            gmailController.SentMessageWithAttachedFile(this.firstMail, themeOfMessage, messageBody, path);

            foundMessage = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[contains(text(),'{fileName}')]")));

            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void SentMessageWithAttachedFile_SentIncorrectFileExtension()
        {
            themeOfMessage = "Message with incorrect file extension";
            messageBody = "sent a message to the method being tested SentMessageWithAttachedFile() with incorrect file extension";
            string fileName = "iTechArt.7z";
            string path = gmailController.GetFilePath(fileName);

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            gmailController.SentMessageWithAttachedFile(this.firstMail, themeOfMessage, messageBody, path);

            IAlert alert = fluentWait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();

            foundMessage = fluentWait.Until(x => x.FindElement(By.XPath($"//span[contains(text(),'{themeOfMessage}')]")));

            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void SentEmptyMessage_IsDisplayedErrorWindow()
        {
            IWebElement errorForm;

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            gmailController.SentEmptyMessage();

            errorForm = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='Kj-JD-K7 Kj-JD-K7-bsT']")));
            
            Assert.IsTrue(errorForm.Displayed);
        }

        [Test]
        public void DeleteSentMessagesFrom_DeleteAllMessagesFromGivenEmail()
        {
            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            gmailController.DeleteSentMessagesFrom(this.firstMail);

            bool isNotFoundMessage = fluentWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath($"//div[2]/span[@class='bA4']/span[@email='{this.firstMail}']")));

            Assert.IsTrue(isNotFoundMessage);
        }

        [TearDown]
        public void TearDown()
        {
            gmailController.CloseGmail();
        }
    }
}
