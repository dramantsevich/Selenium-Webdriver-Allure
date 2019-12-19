using Allure.Commons;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
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
        [AllureSeverity(SeverityLevel.Minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSubSuite("TopBarPanelTests")]
        public void AllSectionsButtonClick_IsResourcePageOpen()
        {
            TopBarPanel topBarPanel = homePage.OpenTopBarPanel();

            ResourcePage resourcePage = topBarPanel.AllSectionsButtonClick();

            AllureLifecycle.Instance.Verify.That("Portal sections displayed", () => resourcePage.IsPortalSectionsDisplayed(), Is.True);
        }
    }
}
