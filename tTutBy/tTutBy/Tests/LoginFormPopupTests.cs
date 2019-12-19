using tTutBy.Pages;
using NUnit.Framework;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using Allure.Commons;

namespace tTutBy.Tests
{
    [TestFixture]
    public class LoginFormPopupTests : BaseTests
    {
        [Test]
        [AllureTag("TC-5")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSubSuite("LoginFormPopupTests")]
        public void LogoutFromAccount_IsLoginFormEnabled()
        {
            SigninAccount();

            this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
            authorizeFormPopup.LogoutButtonClick();

            AllureLifecycle.Instance.Verify.That("Login form enabled", () => homePage.IsLoginFormEnabled(), Is.True);
        }

        [Test]
        [AllureTag("TC-6")]
        [AllureSeverity(SeverityLevel.Minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSubSuite("LoginFormPopupTests")]
        public void ClickSupportButton_IsOpenSupportPage()
        {
            SigninAccount();

            this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
            SupportPage supportPage = authorizeFormPopup.ClickSupportButton();

            AllureLifecycle.Instance.Verify.That("FAQ form displayed", () => supportPage.IsFAQFormDisplayed(), Is.True);
        }

        [Test]
        [AllureTag("TC-7")]
        [AllureSeverity(SeverityLevel.Minor)]
        [AllureOwner("Ramantsevich Dzmitry")]
        [AllureSubSuite("LoginFormPopupTests")]
        public void ClickProfileButton_IsOpenProfilesPage()
        {
            SigninAccount();

            this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
            ProfilePage profilePage = authorizeFormPopup.ClickProfileButton();

            AllureLifecycle.Instance.Verify.That("Form section input fields enabled", () => profilePage.IsFormSectionInputFieldsEnabled(), Is.True);
        }

        public void SigninAccount()
        {
            AllureLifecycle.Instance.RunStep("Sign in account", () =>
            {
                this.authorizeFormPopup = homePage.OpenLoginForm();
                authorizeFormPopup.SetLogin(login);
                authorizeFormPopup.SetPassword(password);

                this.homePage = authorizeFormPopup.LoginButtonClick();
            });
        }
    }
}
