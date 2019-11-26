using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        private InboxGmailPage inboxGmailPage;
        private MessagePopUp messagePopUp;
        string firstMail;
        string firstPassword;
        string themeOfMessage;
        string messageBody;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
            this.inboxGmailPage = new InboxGmailPage(this.driver);
            this.messagePopUp = new MessagePopUp(this.driver);
            this.controller = new GmailController(this.driver);

            this.firstMail = controller.GetFirstMail();
            this.firstPassword = controller.GetFirstPassword();

            controller.StartGmail();

            LoginMailPage loginMailPage = new LoginMailPage(this.driver);
            loginMailPage.SetMail(firstMail);
            loginMailPage.GoToPasswordPage();

            LoginPasswordPage loginPasswordPage = new LoginPasswordPage(this.driver);
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
            themeOfMessage = "incorrect file extension";
            messageBody = "sent a message to the method being tested SentMessageWithAttachedFile() with incorrect file extension";
            string fileName = "iTechArt.7z";

            inboxGmailPage.OpenNewMessagePopUp();

            messagePopUp.SendMessageWithAttachedFile(this.firstMail, themeOfMessage, messageBody, fileName);

            messagePopUp.ConfirmAlert();

            foundMessage = inboxGmailPage.GetMessageByTheme(themeOfMessage);

            System.Console.WriteLine(foundMessage.Displayed);

            Assert.IsTrue(foundMessage.Displayed);
        }

        [Test]
        public void SendEmptyMessage_IsDisplayedErrorPopUp()
        {
            IWebElement errorPopUpTitle;

            inboxGmailPage.OpenNewMessagePopUp();

            messagePopUp.SendMessage();

            ErrorMessagePopUp errorMessagePopUp = new ErrorMessagePopUp(this.driver);

            errorPopUpTitle = errorMessagePopUp.GetErrorTitle();

            Assert.IsTrue(errorPopUpTitle.Displayed);
        }

        [Test]
        public void DeleteSendMessagesFrom_IsMessagesFromMailClear()
        {
            inboxGmailPage.DeleteSentMessageFrom(this.firstMail);

            bool isNotFoundMessage = inboxGmailPage.IsMessagesFromMailNotFound(this.firstMail);

            Thread.Sleep(1000);

            Assert.IsTrue(isNotFoundMessage);
        }

        [TearDown]
        public void TearDown()
        {
            controller.CloseGmail();
        }
    }
}
