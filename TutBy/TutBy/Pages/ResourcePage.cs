using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TutBy.Pages
{
    public class ResourcePage : Page
    {
        [FindsBy(How = How.XPath, Using = "//a[@class='header-logo']")]
        [CacheLookup]
        private readonly IWebElement Logo;

        public ResourcePage(IWebDriver driver) : base(driver) { }
        
        public HomePage LogoClick()
        {
            Logo.Click();

            return new HomePage(this.driver);
        }

        public bool IsDisplayed()
        {
            if (Logo.Displayed)
                return true;
            else
                return false;
        }
    }
}
