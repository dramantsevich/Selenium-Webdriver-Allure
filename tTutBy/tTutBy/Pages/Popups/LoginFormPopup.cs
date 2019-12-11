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
            LoginField.SendKeys(login);
        }

        public void SetPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public HomePage LoginButtonClick()
        {
            LoginButton.Click();

            return new HomePage(driver);
        }

        public HomePage LogoutButtonClick()
        {
            LogoutButton.Click();

            return new HomePage(driver);
        }

        public SupportPage ClickSupportButton()
        {
            SupportButton.Click();

            return new SupportPage(this.driver);
        }

        public ProfilePage ClickProfileButton()
        {
            ProfileButton.Click();

            return new ProfilePage(this.driver);
        }
    }
}
