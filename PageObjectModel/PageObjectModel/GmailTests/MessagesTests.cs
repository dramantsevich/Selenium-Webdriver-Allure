using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using PageObjectModel.Pages.PopUpWindows;
using System.Threading;

namespace PageObjectModel.GmailTests
{
    class MessagesTests
    {
        private IWebElement foundMessage;
        private IWebDriver driver;
        private GmailController controller;
        private LoginMailPage loginMailPage;
        private LoginPasswordPage loginPasswordPage;
        private InboxGmailPage inboxGmailPage;
        private MessagePopUp messagePopUp;
        private ErrorMessagePopUp errorMessagePopUp;
        DefaultWait<IWebDriver> fluentWait;
        string firstMail;
        string firstPassword;
        string themeOfMessage;
        string messageBody;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
            this.controller = new GmailController(this.driver);
            this.loginMailPage = new LoginMailPage(this.driver);
            this.loginPasswordPage = new LoginPasswordPage(this.driver);
            this.inboxGmailPage = new InboxGmailPage(this.driver);
            this.messagePopUp = new MessagePopUp(this.driver);
            this.errorMessagePopUp = new ErrorMessagePopUp(this.driver);

            this.fluentWait = FluentWait.GetFluentWait(this.driver);

            this.firstMail = controller.GetFirstMail();
            this.firstPassword = controller.GetFirstPassword();

            controller.StartGmail();

            loginMailPage.SetMail(firstMail);
            loginMailPage.GoToPasswordPage();

            loginPasswordPage.SetPassword(firstPassword);
            loginPasswordPage.LoginClick();
        }

        [Test]
        public void SendMessage()
        {
            themeOfMessage = "Test method SentMessage";
            messageBody = "sent a message to the method being tested SentMessage()";

            inboxGmailPage.OpenNewMessagePopUp();

            this.messagePopUp.SendFullMessage(firstMail, themeOfMessage, messageBody);

            this.foundMessage = inboxGmailPage.GetMessageByTheme(themeOfMessage);

            Assert.IsTrue(foundMessage.Displayed);
        }

        [Test]
        public void SendMessageWithAttachedFile_sentCorrectFileExtension()
        {
            themeOfMessage = "Message with attached file";
            messageBody = "sent a message to the method being tested SentMessageWithAttachedFile()";
            string fileName = "Account.txt";

            inboxGmailPage.OpenNewMessagePopUp();

            messagePopUp.SendMessageWithAttachedFile(this.firstMail, themeOfMessage, messageBody, fileName);

            this.foundMessage = inboxGmailPage.GetMessageByFileName(fileName);
            Assert.IsTrue(foundMessage.Displayed);
        }

        [Test]
        public void SendMessageWithAttachedFile_SentIncorrectFileExtension()
        {
            themeOfMessage = "Message with incorrect file extension";
            messageBody = "sent a message to the method being tested SentMessageWithAttachedFile() with incorrect file extension";
            string fileName = "iTechArt.7z";

            inboxGmailPage.OpenNewMessagePopUp();

            messagePopUp.SendMessageWithAttachedFile(this.firstMail, themeOfMessage, messageBody, fileName);

            messagePopUp.ConfirmAlert();

            foundMessage = inboxGmailPage.GetMessageByTheme(themeOfMessage);

            Assert.IsTrue(foundMessage.Displayed);
        }

        [Test]
        public void SendEmptyMessage_IsDisplayedErrorPopUp()
        {
            IWebElement errorPopUpTitle;

            inboxGmailPage.OpenNewMessagePopUp();

            messagePopUp.SendMessage();

            errorPopUpTitle = errorMessagePopUp.GetErrorTitle();

            Assert.IsTrue(errorPopUpTitle.Displayed);
        }

        [Test]
        public void DeleteSendMessagesFrom_IsMessagesFromMailClear()
        {
            inboxGmailPage.DeleteSentMessageFrom(this.firstMail);

            bool isNotFoundMessage = inboxGmailPage.IsMessagesFromMailNotFound(this.firstMail);

            Thread.Sleep(3000);

            Assert.IsTrue(isNotFoundMessage);
        }

        [TearDown]
        public void TearDown()
        {
            controller.CloseGmail();
        }
    }
}
