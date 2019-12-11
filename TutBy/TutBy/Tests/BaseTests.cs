using Allure.Commons;
using AShotNet;
using AShotNet.Coordinates;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TutBy.Pages;
using TutBy.Pages.Popups;

namespace TutBy.Tests
{
    [AllureNUnit]
    [AllureParentSuite("AllTests")]
    public class BaseTests
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
            this.driver = new ChromeDriver();
            this.controller = new BrowserController(this.driver);

            controller.StartWebSite(webSiteUrl);

            this.login = controller.GetMail();
            this.password = controller.GetPassword();

            this.homePage = new HomePage(this.driver);
        }

        public void MakeScreenshot()
        {
            string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Screenshots";
            string screenName = $"{DateTime.Now.ToString("HH_mm_ss")}{driver.Title}.jpg";
            string fullPath = $@"{screenFolder}\{screenName}";

            new AShot()
             .CoordsProvider(new WebDriverCoordsProvider())
             .TakeScreenshot(driver)
             .getImage()
             .Save(fullPath);

            AllureLifecycle.Instance.AddAttachment("Screen", "Screenshot", fullPath);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                MakeScreenshot();
            }

            controller.CloseAllWindows();
        }
    }
}
