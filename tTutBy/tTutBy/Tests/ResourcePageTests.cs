using tTutBy.Pages;
using NUnit.Framework;
using tTutBy.Pages.Popups;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace tTutBy.Tests
{
    [TestFixture]
    public class ResourcePageTests : BaseTests
    {
        [Test]
        [AllureTag("TC-8")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSuite("ResourcePageTests")]
        public void LogoClick_IsHomePageOpen()
        {
            TopBarPanel topBarPanel = homePage.OpenTopBarPanel();

            ResourcePage resourcePage = topBarPanel.AllSectionsButtonClick();

            HomePage pageHome = resourcePage.LogoClick();

            Assert.IsTrue(pageHome.IsNewsBlockDisplayed());
        }
    }
}
