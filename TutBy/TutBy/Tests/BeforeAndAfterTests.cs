using TutBy.Pages;
using TutBy.Pages.Popups;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Allure.Commons;

namespace TutBy.Tests
{
    public class BeforeAndAfterTests
    {
        protected IWebDriver driver;
        protected BrowserController controller;
        private protected string webSiteUrl = "https://www.tut.by/";
        protected HomePage homePage;
        protected LoginFormPopup authorizeFormPopup;
        protected string login;
        protected string password;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public void SetUp()
        {

            this.driver = new ChromeDriver();
            this.controller = new BrowserController(this.driver);

            controller.StartWebSite(webSiteUrl);

            this.login = controller.GetMail();
            this.password = controller.GetPassword();

            this.homePage = new HomePage(this.driver);
        }

        [TearDown]
        public void TearDown()
        {
            controller.CloseAllWindows();
        }
    }
}
