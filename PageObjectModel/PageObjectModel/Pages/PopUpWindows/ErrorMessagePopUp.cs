using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.Pages.PopUpWindows
{
    public class ErrorMessagePopUp
    {

        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        readonly By title = By.XPath("//div[@class='Kj-JD-K7 Kj-JD-K7-bsT']");
        
        public ErrorMessagePopUp(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetErrorTitle()
        {
            IWebElement title;
            fluentWait = FluentWait.GetFluentWait(this.driver);

            title = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.title));

            return title;
        }
    }
}
