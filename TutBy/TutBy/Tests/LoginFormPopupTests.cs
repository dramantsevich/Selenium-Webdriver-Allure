using TutBy.Pages;
using TutBy.Pages.Popups;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using OpenQA.Selenium.Chrome;

namespace TutBy.Tests
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
            MakeScreenshotWhenFail(homePage.Logo, () =>
            {
                SigninAccount();

                this.authorizeFormPopup = homePage.OpenLogedinAccountForm();
                authorizeFormPopup.LogoutButtonClick();

                Assert.IsTrue(homePage.IsLoginFormEnabled());
            });
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

            MakeScreenshotWhenFail(supportPage.Header, () =>
            {
                Assert.IsTrue(supportPage.IsDisplayed());
            });
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

            MakeScreenshotWhenFail(profilePage.Header, () =>
            {
                Assert.IsTrue(profilePage.IsDisplayed());
            });
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
