using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using tTutBy.Pages;
using tTutBy.Pages.Popups;

namespace tTutBy.Tests
{
    [AllureNUnit]
    [AllureParentSuite("AllTests")]
    public class BaseTests : TestListener
    {
        protected IWebDriver driver;
        protected BrowserController controller;
        private protected string webSiteUrl = "https://www.tut.by/";
        protected HomePage homePage;
        protected LoginFormPopup authorizeFormPopup;
        protected string login;
        protected string password;


        [SetUp]
        public void SetUp()
        {
            this.driver = DriverSingleton.GetDriver();
            this.controller = new BrowserController(this.driver);

            controller.StartWebSite(webSiteUrl);

            this.login = controller.GetMail();
            this.password = controller.GetPassword();

            this.homePage = new HomePage(this.driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
                TestListener.OnTestFailure();

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                TestListener.OnTestSuccess();

            DriverSingleton.CloseDriver();
        }
    }
}
