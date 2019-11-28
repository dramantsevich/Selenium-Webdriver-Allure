using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageFactoryProject.Pages.PopUpsObjects
{
   public class ErrorMessagePopUp : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='Kj-JD-K7 Kj-JD-K7-bsT']/span[1]")]
        public IWebElement Title { get; set; }

        public ErrorMessagePopUp(IWebDriver driver) : base(driver) { }
    }
}
