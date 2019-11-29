using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageFactoryProject.Pages;
using PageFactoryProject.Pages.PopUpsObjects;
using System;
using System.Threading;

namespace PageFactoryProject.Tests
{
    class MessagesTests
    {
        private IWebDriver driver;
        private IWebElement foundMessage;
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
        public void SendMessage()
        {
            this.themeOfMessage = "Test method SentMessage";
            this.messageBody = "sent a message to the method being tested SentMessage()";

            MessagePopUp messagePopUp = inboxGmailPage.OpenNewMessagePopUp();
            messagePopUp.SendFullMessage(this.firstMail, this.themeOfMessage, this.messageBody);

            this.foundMessage = inboxGmailPage.GetMessageByTheme(themeOfMessage);

            Assert.IsTrue(foundMessage.Displayed);
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

            this.foundMessage = inboxGmailPage.GetMessageByFileName(fileName);

            Assert.IsTrue(foundMessage.Displayed);
        }


        [Test]
        public void SendMessageWithAttachedFile_SentIncorrectFileExtension()
        {
            this.themeOfMessage = "incorrect file extension";
            this.messageBody = "sent a message to the method being tested SentMessageWithAttachedFile() with incorrect file extension";
            this.fileName = "iTechArt.7z";
            this.pathFileName = controller.GetFilePath(fileName);

            MessagePopUp messagePopUp = inboxGmailPage.OpenNewMessagePopUp();
            messagePopUp.SendMessageWithAttachedFile(this.firstMail, this.themeOfMessage, this.messageBody, pathFileName);
            messagePopUp.ConfirmAlertPopUp();

            this.foundMessage = inboxGmailPage.GetMessageByTheme(themeOfMessage);

            Assert.IsTrue(foundMessage.Displayed);
        }

        [Test]
        public void SendEmptyMessage_IsDisplayedErrorPopUp()
        {
            MessagePopUp messagePopUp = inboxGmailPage.OpenNewMessagePopUp();

            ErrorMessagePopUp errorMessagePopUp = messagePopUp.SendMessage();

            string errorPopUpTitleText = errorMessagePopUp.GetTitleText();

            Console.WriteLine(errorPopUpTitleText);

            Assert.IsTrue(errorPopUpTitleText.Length > 0);
        }

        [Test]
        public void DeleteAllSendMessagesFrom_IsMessagesFromMailClear()
        {
            inboxGmailPage.DeleteAllSentMessagesFrom(this.firstMail);

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
