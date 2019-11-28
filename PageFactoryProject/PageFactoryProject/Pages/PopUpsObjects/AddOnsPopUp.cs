using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageFactoryProject.Pages.PopUpsObjects
{
    public class AddOnsPopUp : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='glass-content']/iframe")]
        private IWebElement AddOnsFrame;

        [FindsBy(How = How.XPath, Using = "//a[@class='h4Cscd']")]
        public IWebElement Title { get; set; }

        public AddOnsPopUp(IWebDriver driver) : base(driver) 
        {
            driver.SwitchTo().Frame(AddOnsFrame);
        }
    }
}
