using tTutBy.Pages;
using NUnit.Framework;
using tTutBy.Pages.Popups;
using Allure.NUnit.Attributes;
using Allure.Commons.Model;
using Allure.Commons;

namespace tTutBy.Tests
{
    [TestFixture]
    public class ResourcePageTests : BaseTests
    {
        [Test]
        [AllureTag("TC-8")]
        [AllureSeverity(SeverityLevel.Minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSubSuite("ResourcePageTests")]
        public void LogoClick_IsHomePageOpen()
        {
            TopBarPanel topBarPanel = homePage.OpenTopBarPanel();

            ResourcePage resourcePage = topBarPanel.AllSectionsButtonClick();

            HomePage pageHome = resourcePage.LogoClick();

            AllureLifecycle.Instance.Verify.That("News block displayed", () => pageHome.IsNewsBlockDisplayed(), Is.True);
        }
    }
}
