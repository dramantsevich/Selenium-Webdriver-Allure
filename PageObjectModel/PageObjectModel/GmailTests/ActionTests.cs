using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Pages;
using PageObjectModel.Pages.PopUpWindows;
using System.Threading;

namespace PageObjectModel.Tests
{
    class ActionTests
    {
        private IWebDriver driver;
        private GmailController controller;
        private InboxGmailPage inboxGmailPage;
        private AccountPopUp accountPopUp;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
            this.controller = new GmailController(this.driver);
            this.inboxGmailPage = new InboxGmailPage(this.driver);
            this.accountPopUp = new AccountPopUp(this.driver);

            string firstMail = controller.GetFirstMail();
            string firstPassword = controller.GetFirstPassword();

            controller.StartGmail();

            LoginMailPage loginMailPage = new LoginMailPage(this.driver);
            loginMailPage.SetMail(firstMail);
            loginMailPage.GoToPasswordPage();

            LoginPasswordPage loginPasswordPage = new LoginPasswordPage(this.driver);
            loginPasswordPage.SetPassword(firstPassword);
            loginPasswordPage.LoginClick();
        }

        [Test]
        public void StartGmail_isLogin()
        {
            inboxGmailPage.OpenAccountManager();

            IWebElement currentAccountMail = accountPopUp.GetCurrentAccountMail();
            
            string actualMailOnPage = currentAccountMail.Text;
            string expectedMail = controller.GetFirstMail();

            Assert.AreEqual(expectedMail, actualMailOnPage);
        }

        [Test]
        public void SignOutFromAccount()
        {
            inboxGmailPage.OpenAccountManager();

            accountPopUp.SignOutFromAccount();

            SigninChooserPage signinChooserPage = new SigninChooserPage(this.driver);

            string signinChooserPageUrl = signinChooserPage.GetCurrentUrl();

            string currentUrl = this.driver.Url;

            Assert.AreEqual(signinChooserPageUrl, currentUrl);
        }

        [Test]
        public void SearchMessageByTheme()
        {
            string themeOfMessage = "Xinuos Inc.";

            inboxGmailPage.SearchMessageByTheme(themeOfMessage);

            IWebElement foundMessage = inboxGmailPage.GetMessageByTheme(themeOfMessage);

            Assert.IsTrue(foundMessage.Displayed);
        }

        [Test]
        public void OpenAddOnsPopUp_IsVisible()
        {
            inboxGmailPage.OpenAddOnsPopUp();

            AddOnsPopUp addOnsPopUp = new AddOnsPopUp(this.driver);

            IWebElement addOnsTitle = addOnsPopUp.GetAddOnsTitle();

            Assert.IsTrue(addOnsTitle.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            controller.CloseGmail();
        }
    }
}
