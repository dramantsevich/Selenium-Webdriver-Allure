using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using PageFactory.Pages;
using PageFactory.Pages.PopUpObjects;

namespace PageFactory.Tests
{
    [TestFixture]
    public class MessagesTests
    {
        private IWebDriver driver;
        private GmailController controller;
        private InboxGmailPage inboxGmailPage;
        string firstMail;
        string firstPassword;
        string themeOfMessage;
        string messageBody;
        string fileName;
        string pathFileName;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
            this.controller = new GmailController(this.driver);

            this.firstMail = controller.GetFirstMail();
            this.firstPassword = controller.GetFirstPassword();

            controller.StartGmail();

            LoginMailPage loginMailPage = new LoginMailPage(this.driver);
            loginMailPage.SetMail(firstMail);

            LoginPasswordPage loginPasswordPage = loginMailPage.GoToPasswordPage();
            loginPasswordPage.SetPassword(firstPassword);

            this.inboxGmailPage = loginPasswordPage.LoginClick();
        }

        [Test]
        public void SendMessage_IsSended()
        {
            this.themeOfMessage = "Test method SentMessage";
            this.messageBody = "sent a message to the method being tested SentMessage()";

            MessagePopUp messagePopUp = inboxGmailPage.OpenNewMessagePopUp();
            messagePopUp.SendFullMessage(this.firstMail, this.themeOfMessage, this.messageBody);

            Assert.IsTrue(inboxGmailPage.GetMessageByTheme(themeOfMessage).Displayed);
        }

        [Test]
        public void SendMessageWithAttachedFile_sentCorrectFileExtension()
        {
            this.themeOfMessage = "Message with attached file";
            this.messageBody = "sent a message to the method being tested SentMessageWithAttachedFile()";
            this.fileName = "Account.txt";
            this.pathFileName = controller.GetFilePath(fileName);

            MessagePopUp messagePopUp = inboxGmailPage.OpenNewMessagePopUp();
            messagePopUp.SendMessageWithAttachedFile(this.firstMail, this.themeOfMessage, this.messageBody, pathFileName);

            Assert.IsTrue(inboxGmailPage.GetMessageByFileName(fileName).Displayed);
        }


        [Test]
        public void SendMessageWithAttachedFile_SentMessageWithoutFile()
        {
            this.themeOfMessage = "incorrect file extension";
            this.messageBody = "sent a message to the method being tested SentMessageWithAttachedFile() with incorrect file extension";
            this.fileName = "iTechArt.7z";
            this.pathFileName = controller.GetFilePath(fileName);

            MessagePopUp messagePopUp = inboxGmailPage.OpenNewMessagePopUp();
            messagePopUp.SendMessageWithAttachedFile(this.firstMail, this.themeOfMessage, this.messageBody, pathFileName);
            messagePopUp.ConfirmAlertPopUp();

            Assert.IsTrue(inboxGmailPage.GetMessageByTheme(themeOfMessage).Displayed);
        }

        [Test]
        public void SendEmptyMessage_IsDisplayedErrorPopUp()
        {
            MessagePopUp messagePopUp = inboxGmailPage.OpenNewMessagePopUp(); 

            ErrorMessagePopUp errorMessagePopUp = messagePopUp.SendMessage();

            Thread.Sleep(100);

            Assert.IsTrue(errorMessagePopUp.IsDisplayd());
        }

        [Test]
        public void DeleteAllSendMessagesFrom_IsMessagesFromMailClear()
        {
            inboxGmailPage.DeleteAllSentMessagesFrom(this.firstMail);

            Thread.Sleep(1000);

            Assert.IsTrue(inboxGmailPage.IsMessagesFromMailNotFound(this.firstMail));
        }

        [TearDown]
        public void TearDown()
        {
            controller.CloseGmail();
        }
    }
}
