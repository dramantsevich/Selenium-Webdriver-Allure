using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageFactory.Pages;
using PageFactory.Pages.PopUpObjects;

namespace PageFactory.Tests
{
    [TestFixture]
    class ActionTests
    {
        private IWebDriver driver;
        private GmailController controller;
        private InboxGmailPage inboxGmailPage;
        private GoogleAccountPopUp accountPopUp;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
            this.controller = new GmailController(this.driver);

            string firstMail = controller.GetFirstMail();
            string firstPassword = controller.GetFirstPassword();

            controller.StartGmail();

            LoginMailPage loginMailPage = new LoginMailPage(this.driver);
            loginMailPage.SetMail(firstMail);

            LoginPasswordPage loginPasswordPage = loginMailPage.GoToPasswordPage();
            loginPasswordPage.SetPassword(firstPassword);

            this.inboxGmailPage = loginPasswordPage.LoginClick();
        }

        [Test]
        public void StartGmail_isLogin()
        {
            this.accountPopUp = inboxGmailPage.OpenAccountManager();

            IWebElement currentAccountMail = accountPopUp.CurrentAccountMail;

            Assert.AreEqual(controller.GetFirstMail(), currentAccountMail.Text);
        }

        [Test]
        public void SignOutFromAccount_IsSignOut()
        {
            this.accountPopUp = inboxGmailPage.OpenAccountManager();

            SigninChooserPage signinChooserPage = accountPopUp.SignOutFromAccount();

            Assert.AreEqual(signinChooserPage.GetCurrentUrl(), this.driver.Url);
        }

        [Test]
        public void SearchMessageByTheme_IsSearchedMessageDisplayed()
        {
            string themeOfMessage = "Xinuos Inc.";

            inboxGmailPage.SearchMessageByTheme(themeOfMessage);

            Assert.IsTrue(inboxGmailPage.GetSearchedMessageByTheme(themeOfMessage).Displayed);
        }

        [Test]
        public void OpenAddOnsPopup_IsVisible()
        {
            AddOnsPopUp addOnsPopUp = inboxGmailPage.OpenAddOnsPopUp();

            Assert.IsTrue(addOnsPopUp.IsDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            controller.CloseGmail();
        }
    }
}