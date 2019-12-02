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

            string actualMailOnPage = currentAccountMail.Text;
            string expectedMail = controller.GetFirstMail();

            Assert.AreEqual(expectedMail, actualMailOnPage);
        }

        [Test]
        public void SignOutFromAccount()
        {
            this.accountPopUp = inboxGmailPage.OpenAccountManager();

            SigninChooserPage signinChooserPage = accountPopUp.SignOutFromAccount();

            string signinChooserPageUrl = signinChooserPage.GetCurrentUrl();
            string currentUrl = this.driver.Url;

            Assert.AreEqual(signinChooserPageUrl, currentUrl);
        }

        [Test]
        public void SearchMessageByTheme()
        {
            string themeOfMessage = "Xinuos Inc.";

            inboxGmailPage.SearchMessageByTheme(themeOfMessage);

            IWebElement foundMessage = inboxGmailPage.GetSearchedMessageByTheme(themeOfMessage);

            Assert.IsTrue(foundMessage.Displayed);
        }

        [Test]
        public void OpenAddOnsPopup_IsVisible()
        {
            AddOnsPopUp addOnsPopUp = inboxGmailPage.OpenAddOnsPopUp();

            string addOnsTitleText = addOnsPopUp.GetTitleText();

            Assert.IsTrue(addOnsTitleText.Length > 0);
        }

        [TearDown]
        public void TearDown()
        {
            controller.CloseGmail();
        }
    }
}