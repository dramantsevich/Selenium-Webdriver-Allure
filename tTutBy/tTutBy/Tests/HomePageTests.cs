using tTutBy.Pages;
using tTutBy.Pages.Popups;
using NUnit.Framework;
using Allure.NUnit.Attributes;
using Allure.Commons.Model;
using Allure.Commons;

namespace tTutBy.Tests
{
    [TestFixture]
    public class HomePageTests : BaseTests
    {
        [Test]
        [AllureTag("TC-2")]
        [AllureSeverity(SeverityLevel.Blocker)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSubSuite("HomePageTests")]
        public void StartTutBy_IsLogin()
        {
            HomePage page = new HomePage(this.driver);

            this.authorizeFormPopup = homePage.OpenLoginForm();
            authorizeFormPopup.SetLogin(login);
            authorizeFormPopup.SetPassword(password);

            this.homePage = authorizeFormPopup.LoginButtonClick();

            AllureLifecycle.Instance.Verify.That("Logged in account", () => homePage.IsLoggedInAccount(), Is.True);
        }

        [Test]
        [AllureTag("TC-3")]
        [AllureSeverity(SeverityLevel.Minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSubSuite("HomePageTests")]
        public void OpenTopBarPanel_IsOpenTopBarPanel()
        {
            TopBarPanel topBarPanel = homePage.OpenTopBarPanel();

            AllureLifecycle.Instance.Verify.That("Open top bar panel", () => topBarPanel.IsTopBarPanelDisplayed(), Is.True);
        }

        [Test]
        [AllureTag("TC-4")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSubSuite("HomePageTests")]
        public void OpenFinancePage_IsOpenFinancePage()
        {
            FinancePage financePage = homePage.OpenFinancePage();

            AllureLifecycle.Instance.Verify.That("Equal widgets displayed", ()=> financePage.IsEqualWidgetsDispayed(), Is.True);
        }
    }
}
