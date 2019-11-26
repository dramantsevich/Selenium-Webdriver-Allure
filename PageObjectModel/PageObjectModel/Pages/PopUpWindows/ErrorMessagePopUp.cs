using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.Pages.PopUpWindows
{
    public class ErrorMessagePopUp : Page
    {
        readonly By titleLocator = By.XPath("//div[@class='Kj-JD-K7 Kj-JD-K7-bsT']");
        
        public ErrorMessagePopUp(IWebDriver driver) : base(driver) { }

        public IWebElement GetErrorTitle()
        {
            IWebElement title = webDriverWait.Until(ExpectedConditions.ElementIsVisible(this.titleLocator));
            return title;
        }
    }
}
