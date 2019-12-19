using Allure.Commons;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace tTutBy.Pages.Popups
{
    public class LoginFormPopup : Page
    {
        [FindsBy(How = How.Name, Using = "login")]
        [CacheLookup]
        private readonly IWebElement LoginField;

        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        private readonly IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//div[@id='animated_mainmenu']//div[4]/input[@type='submit']")]
        [CacheLookup]
        private readonly IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='button wide auth__reg']")]
        [CacheLookup]
        private readonly IWebElement LogoutButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='authorize']//li[3]//a[1]")]
        [CacheLookup]
        private readonly IWebElement SupportButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='authorize']//li[1]//a[1]")]
        [CacheLookup]
        private readonly IWebElement ProfileButton;

        public LoginFormPopup(IWebDriver driver) : base(driver) { }

        public void SetLogin(string login)
        {
            AllureLifecycle.Instance.RunStep("Set login(set data in first field)", () =>
            {
                LoginField.SendKeys(login);
            }, login);
        }

        [AllureHideParams]
        public void SetPassword(string password)
        {
            AllureLifecycle.Instance.RunStep("Set password(set data in second field)", () =>
            {
                PasswordField.SendKeys(password);
            }, password);
        }

        public HomePage LoginButtonClick()
        {
            AllureLifecycle.Instance.RunStep("Go back to HomePage(click to login button)", () =>
            {
                LoginButton.Click();
            });

            return new HomePage(driver);
        }

        public HomePage LogoutButtonClick()
        {
            AllureLifecycle.Instance.RunStep("Logout from account(click to logout button)", () =>
            {
                LogoutButton.Click();
            });

            return new HomePage(driver);
        }

        public SupportPage ClickSupportButton()
        {
            AllureLifecycle.Instance.RunStep("Open support page(click to support button)", () =>
            {
                SupportButton.Click();
            });

            return new SupportPage(this.driver);
        }

        public ProfilePage ClickProfileButton()
        {
            AllureLifecycle.Instance.RunStep("Open profile page(click to profile button)", () => 
            {
                ProfileButton.Click();
            });

            return new ProfilePage(this.driver);
        }
    }
}
