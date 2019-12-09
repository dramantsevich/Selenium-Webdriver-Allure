using TutBy.Pages;
using NUnit.Framework;
using TutBy.Pages.Popups;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using OpenQA.Selenium.Chrome;

namespace TutBy.Tests
{
    [TestFixture]
    public class ResourcePageTests : BaseTests
    {
        [Test]
        [AllureTag("TC-8")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSuite("LoginFormPopupTests")]
        public void LogoClick_IsHomePageOpen()
        {
            MakeScreenshotWhenFail(homePage.Logo, () =>
            {
                TopBarPanel topBarPanel = homePage.OpenTopBarPanel();

                ResourcePage resourcePage = topBarPanel.AllSectionsButtonClick();

                HomePage pageHome = resourcePage.LogoClick();

                Assert.IsTrue(pageHome.IsDisplayed());
            });
        } 
    }
}
