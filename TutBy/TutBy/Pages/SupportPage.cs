using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TutBy.Pages
{
    public class SupportPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//form[@class='b-form']")]
        [CacheLookup]
        private readonly IWebElement FAQForm;

        public SupportPage(IWebDriver driver) : base(driver) 
        {
            SwitchToSupportPage(driver);
        }
    
        public bool IsFAQFormDisplayed()
        {
            if (FAQForm.Displayed)
                return true;
            else
                return false;
        }

        public void SwitchToSupportPage(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }
    }
}
