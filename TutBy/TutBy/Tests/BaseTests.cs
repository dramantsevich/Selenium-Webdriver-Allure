using AShotNet;
using AShotNet.Coordinates;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TutBy.Pages;
using TutBy.Pages.Popups;

namespace TutBy.Tests
{
    [AllureNUnit]
    [AllureParentSuite("AllTests")]
    public class BaseTests : ClearResultsDir
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

        protected void MakeScreenshotWhenFail(IWebElement webElement, Action action)
        {
            try
            {
                action();
            }
            catch
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Screenshots";

                new AShot()
                    .CoordsProvider(new WebDriverCoordsProvider())
                    .TakeScreenshot(driver)
                    .getImage()
                    .Save($@"{screenFolder}\{driver.Title}{DateTime.Now.ToString("HH_mm_ss")}.jpg");
            }
        }

        [TearDown]
        public void TearDown()
        {
            controller.CloseAllWindows();
        }
    }
}
