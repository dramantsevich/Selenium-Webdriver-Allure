using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageFactoryProject.Pages.PopUpsObjects
{
    public class GoogleAccountPopUp : Page
    {
        [FindsBy(How = How.XPath, Using = "//a[@id='gb_71']")]
        private readonly IWebElement SignOut;

        [FindsBy(How = How.XPath, Using = "//div[@class='gb_ob']")]
        public IWebElement CurrentAccountMail { get; set; }

        public GoogleAccountPopUp(IWebDriver driver) : base(driver) { }

        public SigninChooserPage SignOutFromAccount()
        {
            SignOut.Click();

            return new SigninChooserPage(driver);
        }
    }
}
