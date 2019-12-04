using TutBy.Pages;
using TutBy.Pages.Popups;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace TutBy.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class LoginFormPopupTests : BeforeAndAfterTests
    {
        [Test]
        [AllureTag("TC-5")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSuite("LoginFormPopupTests")]
        public void LogoutFromAccount()
        {
            this.authorizeFormPopup = homePage.OpenLoginForm();
            authorizeFormPopup.SetLogin(login);
            authorizeFormPopup.SetPassword(password);

            this.homePage = authorizeFormPopup.LoginButtonClick();

            this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
            authorizeFormPopup.LogoutButtonClick();

            Assert.IsTrue(homePage.IsLoginFormEnabled());
        }

        [Test]
        [AllureTag("TC-6")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSuite("LoginFormPopupTests")]
        public void ClickSupportButton_IsOpenSupportPage()
        {
            this.authorizeFormPopup = homePage.OpenLoginForm();
            authorizeFormPopup.SetLogin(login);
            authorizeFormPopup.SetPassword(password);

            this.homePage = authorizeFormPopup.LoginButtonClick();

            this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
            SupportPage supportPage = authorizeFormPopup.ClickSupportButton();

            string supportPageUrl = supportPage.GetCurrentUrl();
            string currentUrl = this.driver.Url;

            Assert.AreEqual(supportPageUrl, currentUrl);
        }

        [Test]
        [AllureTag("TC-7")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSuite("LoginFormPopupTests")]
        public void ClickProfileButton_IsOpenProfilesPage()
        {
            this.authorizeFormPopup = homePage.OpenLoginForm();
            authorizeFormPopup.SetLogin(login);
            authorizeFormPopup.SetPassword(password);

            this.homePage = authorizeFormPopup.LoginButtonClick();

            this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
            ProfilePage profilePage = authorizeFormPopup.ClickProfileButton();

            string profilePageUrl = profilePage.GetCurrentUrl();
            string currentUrl = this.driver.Url;

            Assert.AreEqual(profilePageUrl, currentUrl);
        }
    }
}
