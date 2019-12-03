using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TutByTemp.Pages.Popups;

namespace TutByTemp.Pages
{
    public class HomePage : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='b-auth-i']/a[@class='enter']")]
        private readonly IWebElement LoginForm;

        [FindsBy(How = How.XPath, Using = "//span[@class='uname']")]
        private readonly IWebElement Account;

        [FindsBy(How = How.XPath, Using = "//a[@class='enter logedin']")]
        private readonly IWebElement LogedinAccountForm;

        public HomePage(IWebDriver driver) : base(driver) { }

        public LoginFormPopup OpenLoginForm()
        {
            LoginForm.Click();

            return new LoginFormPopup(driver);
        }

        public LoginFormPopup OpenLogedinAccountForm()
        {
            LogedinAccountForm.Click();

            return new LoginFormPopup(driver);
        }

        public string GetCurrentUrl()
        {
            string currentUrl = this.driver.Url;
            
            return currentUrl;
        }

        public bool IsLoggedInAccount()
        {
            if (Account.Text.Length > 0)
                return true;
            else return false;
        }

        public bool IsLoginFormEnabled()
        {
            if (LoginForm.Enabled)
                return true;
            else return false;
        }
    }
}
