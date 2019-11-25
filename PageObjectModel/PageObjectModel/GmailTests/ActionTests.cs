using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using PageObjectModel.Pages.PopUpWindows;
namespace PageObjectModel.Tests
{
    class ActionTests
    {
        private IWebDriver driver;
        private GmailController controller;
        private LoginMailPage loginMailPage;
        private LoginPasswordPage loginPasswordPage;
        private InboxGmailPage inboxGmailPage;
        private AccountPopUp accountPopUp;
        private AddOnsPopUp addOnsPopUp;
        DefaultWait<IWebDriver> fluentWait;

        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
            this.controller = new GmailController(this.driver);
            this.loginMailPage = new LoginMailPage(this.driver);
            this.loginPasswordPage = new LoginPasswordPage(this.driver);
            this.inboxGmailPage = new InboxGmailPage(this.driver);
            this.accountPopUp = new AccountPopUp(this.driver);

            string firstMail = controller.GetFirstMail();
            string firstPassword = controller.GetFirstPassword();

            controller.StartGmail();

            loginMailPage.SetMail(firstMail);
            loginMailPage.GoToPasswordPage();

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
            string signinChoorePageUrl;
            SigninChooserPage signinChooserPage;
            fluentWait = FluentWait.GetFluentWait(this.driver);

            inboxGmailPage.OpenAccountManager();

            accountPopUp.SignOutFromAccount();

            signinChooserPage = new SigninChooserPage(this.driver);

            signinChoorePageUrl = signinChooserPage.GetCurrentUrl();//.берет текущий юрл, а не юрл когда вышел из аккаунта

            bool isUrlContainsCurrentUrl = fluentWait.Until(ExpectedConditions.UrlContains(signinChoorePageUrl));

            Assert.IsFalse(isUrlContainsCurrentUrl);
        }

        [Test]
        public void SearchMessageByTheme()
        {
            IWebElement foundMessage;
            string themeOfMessage = "Xinuos Inc.";

            inboxGmailPage.SearchMessageByTheme(themeOfMessage);

            fluentWait = FluentWait.GetFluentWait(this.driver);

            foundMessage = inboxGmailPage.GetMessageByTheme(themeOfMessage);

            Assert.IsTrue(foundMessage.Displayed);
        }

        [Test]
        public void OpenAddOnsPopUp_IsVisible()
        {
            inboxGmailPage.OpenAddOnsPopUp();

            this.addOnsPopUp = new AddOnsPopUp(this.driver);

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
