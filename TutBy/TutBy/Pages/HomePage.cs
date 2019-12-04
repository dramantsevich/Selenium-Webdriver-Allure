using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TutBy.Pages.Popups;

namespace TutBy.Pages
{
    public class HomePage : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='b-auth-i']/a[@class='enter']")]
        [CacheLookup]
        private readonly IWebElement LoginForm;

        [FindsBy(How = How.XPath, Using = "//span[@class='uname']")]
        [CacheLookup]
        private readonly IWebElement Account;

        [FindsBy(How = How.XPath, Using = "//a[@class='enter logedin']")]
        [CacheLookup]
        private readonly IWebElement LogedinAccountForm;

        [FindsBy(How = How.XPath, Using = "//a[@class='topbar-burger']")]
        [CacheLookup]
        private readonly IWebElement TopBarPanelButton;

        [FindsBy(How = How.XPath, Using = "//ul[@class='b-topbar-i']//li[4]//a[1]")]
        [CacheLookup]
        private readonly IWebElement FinanceButton;

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
            else 
                return false;
        }

        public TopBarPanel OpenTopBarPanel()
        {
            TopBarPanelButton.Click();

            return new TopBarPanel(this.driver);
        }
    
        public FinancePage OpenFinancePage()
        {
            FinanceButton.Click();

            return new FinancePage(this.driver);
        }
    }
}
