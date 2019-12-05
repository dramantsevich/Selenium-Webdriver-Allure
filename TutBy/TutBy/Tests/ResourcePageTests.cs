using TutBy.Pages;
using NUnit.Framework;
using TutBy.Pages.Popups;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace TutBy.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class ResourcePageTests : BeforeAndAfterTests
    {
        [Test]
        [AllureTag("TC-8")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSuite("LoginFormPopupTests")]
        public void LogoClick_IsHomePageOpen()
        {
            TopBarPanel topBarPanel = homePage.OpenTopBarPanel();

            ResourcePage resourcePage = topBarPanel.AllSectionsButtonClick();
            
            HomePage pageHome = resourcePage.LogoClick();

            Assert.IsTrue(pageHome.IsDisplayed());
        } 
    }
}
