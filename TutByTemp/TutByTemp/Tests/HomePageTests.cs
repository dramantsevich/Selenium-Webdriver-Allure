using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TutByTemp.Pages;
using TutByTemp.Pages.Popups;

namespace TutByTemp.Tests
{
    [TestFixture]
    public class HomePageTests
    {
        private IWebDriver driver;
        private BrowserController controller;
        const string webSiteUrl = "https://www.tut.by/";
        private HomePage homePage;
        private LoginFormPopup authorizeFormPopup;

        //[SetUp]
        //public void SetUp()
        //{
        //    this.driver = new ChromeDriver();
        //    this.controller = new BrowserController(this.driver);

        //    controller.StartWebSite(webSiteUrl);

        //    string login = controller.GetMail();
        //    string password = controller.GetPassword();

        //    this.homePage = new HomePage(this.driver);

        //    this.authorizeFormPopup = homePage.OpenLoginForm();
        //    authorizeFormPopup.SetLogin(login);
        //    authorizeFormPopup.SetPassword(password);

        //    this.homePage = authorizeFormPopup.LoginButtonClick();
        //}

        //[Test]
        //public void StartTutBy_IsLogin()
        //{
        //    Assert.IsTrue(homePage.IsLoggedInAccount());
        //}

        //[Test]
        //public void LogoutFromAccount()
        //{
        //    this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
        //    authorizeFormPopup.LogoutButtonClick();

        //    Assert.IsTrue(homePage.IsLoginFormEnabled());
        //}

        //[Test]
        //public void ClickSupportButton_IsOpenProfilesPage()
        //{
        //    this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
        //    ProfilesPage profilesPage = authorizeFormPopup.ClickSupportButton();

        //    string profilesPageUrl = profilesPage.GetCurrentUrl();
        //    string currentUrl = this.driver.Url;

        //    Assert.AreEqual(profilesPageUrl, currentUrl);
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    controller.CloseAllWindows();
        //}
    }
}
