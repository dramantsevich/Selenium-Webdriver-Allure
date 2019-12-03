using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TutByTemp.Pages.Popups
{
    public class LoginFormPopup : Page
    {
        [FindsBy(How = How.Name, Using = "login")]
        private readonly IWebElement LoginField;

        [FindsBy(How = How.Name, Using = "password")]
        private readonly IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//div[@id='animated_mainmenu']//div[4]/input[@type='submit']")]
        private readonly IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='button wide auth__reg']")]
        private readonly IWebElement LogoutButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='authorize']//li[3]//a[1]")]
        private readonly IWebElement SupportButton;

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

        public ProfilesPage ClickSupportButton()
        {
            SupportButton.Click();

            return new ProfilesPage(this.driver);
        }
    }
}
