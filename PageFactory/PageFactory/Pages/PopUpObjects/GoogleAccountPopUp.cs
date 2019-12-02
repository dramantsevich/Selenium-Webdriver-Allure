using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageFactory.Pages.PopUpObjects
{
    public class GoogleAccountPopUp : Page
    {
        [FindsBy(How = How.XPath, Using = "//a[@id='gb_71']")]
        [CacheLookup]
        private readonly IWebElement SignOutButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='gb_ob']")]
        [CacheLookup]
        public IWebElement CurrentAccountMail { get; set; }

        public GoogleAccountPopUp(IWebDriver driver) : base(driver) { }

        public SigninChooserPage SignOutFromAccount()
        {
            SignOutButton.Click();

            return new SigninChooserPage(driver);
        }
    }
}