using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using TutBy.Pages;
using TutBy.Pages.Popups;

namespace TutBy.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class TopBarPanelTests : BeforeAndAfterTests
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

            string resourcePageUrl = resourcePage.GetCurrentUrl();
            string currentUrl = this.driver.Url;

            Assert.AreEqual(resourcePageUrl, currentUrl);
        }
    }
}
