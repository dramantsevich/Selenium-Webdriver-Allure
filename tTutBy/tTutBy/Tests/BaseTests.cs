using Allure.Commons;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using tTutBy.Pages;
using tTutBy.Pages.Popups;

namespace tTutBy.Tests
{
    [AllureSuite("AllTests")]
    public class BaseTests : AllureReport
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
            AllureLifecycle.Instance.RunStep("Start website",() =>
            {
                this.driver = DriverSingleton.GetDriver();
                this.controller = new BrowserController(this.driver);

                controller.StartWebSite(webSiteUrl);

                this.login = controller.GetMail();
                this.password = controller.GetPassword();

                this.homePage = new HomePage(this.driver);
            }, webSiteUrl);
        }

        [TearDown]
        public void TearDown()
        {
            AllureLifecycle.Instance.RunStep("Close all windows", () =>
            {
                MakeScreenshot();
                DriverSingleton.CloseDriver();
            });
        }

        public static void MakeScreenshot(string screenshotName = "Screen")
        {
            var uuid = $"{Guid.NewGuid():N}"; 

            AllureLifecycle.Instance.StartStep("screenshot at the end of the test", uuid);
            AllureLifecycle.Instance.AddAttachment($"{screenshotName} [{DateTime.Now:HH:mm:ss}]",
                "image/png",
                DriverSingleton.GetDriver().TakeScreenshot().AsByteArray);
            AllureLifecycle.Instance.UpdateStep(uuid, _ => _.status = Status.failed);
            AllureLifecycle.Instance.StopStep(uuid);
        }
    }
}
