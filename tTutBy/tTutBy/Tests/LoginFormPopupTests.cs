using tTutBy.Pages;
using NUnit.Framework;
using NUnit.Allure.Attributes;
using Allure.Commons;


namespace tTutBy.Tests
{
    [TestFixture]
    public class LoginFormPopupTests : BaseTests
    {
        [Test]
        [AllureTag("TC-5")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSuite("LoginFormPopupTests")]
        public void LogoutFromAccount_IsLoginFormEnabled()
        {
            SigninAccount();

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
            SigninAccount();

            this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
            SupportPage supportPage = authorizeFormPopup.ClickSupportButton();

            Assert.IsTrue(supportPage.IsFAQFormDisplayed());
        }

        [Test]
        [AllureTag("TC-7")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSuite("LoginFormPopupTests")]
        public void ClickProfileButton_IsOpenProfilesPage()
        {
            SigninAccount();

            this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
            ProfilePage profilePage = authorizeFormPopup.ClickProfileButton();

            Assert.IsTrue(profilePage.IsFormSectionInputFieldsEnabled());
        }

        public void SigninAccount()
        {
            this.authorizeFormPopup = homePage.OpenLoginForm();
            authorizeFormPopup.SetLogin(login);
            authorizeFormPopup.SetPassword(password);

            this.homePage = authorizeFormPopup.LoginButtonClick();
        }
    }
}
