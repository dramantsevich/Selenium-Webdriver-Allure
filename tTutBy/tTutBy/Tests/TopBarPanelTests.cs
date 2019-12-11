using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using tTutBy.Pages;
using tTutBy.Pages.Popups;

namespace tTutBy.Tests
{
    [TestFixture]
    public class TopBarPanelTests : BaseTests
    {
        [Test]
        [AllureTag("TC-7")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSuite("TopBarPanelTests")]
        public void AllSectionsButtonClick_IsResourcePageOpen()
        {
            TopBarPanel topBarPanel = homePage.OpenTopBarPanel();

            ResourcePage resourcePage = topBarPanel.AllSectionsButtonClick();

            Assert.IsTrue(resourcePage.IsPortalSectionsDisplayed());
        }
    }
}
