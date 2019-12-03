using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TutByTemp;
using TutByTemp.Pages;
using TutByTemp.Pages.Popups;

namespace TutByCore
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private BrowserController controller;
        const string webSiteUrl = "https://www.tut.by/";
        private HomePage homePage;
        private LoginFormPopup authorizeFormPopup;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.controller = new BrowserController(this.driver);

            controller.StartWebSite(webSiteUrl);

            string login = controller.GetMail();
            string password = controller.GetPassword();

            this.homePage = new HomePage(this.driver);

            this.authorizeFormPopup = homePage.OpenLoginForm();
            authorizeFormPopup.SetLogin(login);
            authorizeFormPopup.SetPassword(password);

            this.homePage = authorizeFormPopup.LoginButtonClick();
        }

        [Test]
        public void ClickSupportButton_IsOpenProfilesPage()
        {
            this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
            ProfilesPage profilesPage = authorizeFormPopup.ClickSupportButton();

            string profilesPageUrl = profilesPage.GetCurrentUrl();
            string currentUrl = this.driver.Url;

            Assert.AreEqual(profilesPageUrl, currentUrl);
        }

        [TearDown]
        public void TearDown()
        {
            controller.CloseAllWindows();
        }
    }
}