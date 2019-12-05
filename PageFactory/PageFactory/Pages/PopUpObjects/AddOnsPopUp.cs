using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageFactory.Pages.PopUpObjects
{
    public class AddOnsPopUp : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='glass-content']/iframe")]
        [CacheLookup]
        private IWebElement AddOnsFrame;

        [FindsBy(How = How.XPath, Using = "//div[@class='Sikpge']/a[@class='h4Cscd']")]
        [CacheLookup]
        private readonly IWebElement Title;

        public AddOnsPopUp(IWebDriver driver) : base(driver)
        {
            driver.SwitchTo().Frame(AddOnsFrame);
        }

        public string GetTitleText()
        {
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='h4Cscd']")));

            return Title.GetAttribute("title");
        }

        public bool IsDisplayed()
        {
            if (Title.Displayed)
                return true;
            else
                return false;
        }
    }
}
