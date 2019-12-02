using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageFactory.Pages.PopUpObjects
{
    public class ErrorMessagePopUp : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='Kj-JD-K7 Kj-JD-K7-bsT']/span[1]")]
        [CacheLookup]
        private readonly IWebElement Title;

        public ErrorMessagePopUp(IWebDriver driver) : base(driver) { }

        public string GetTitleText()
        {
            string titleText = Title.Text;

            return titleText;
        }
    }
}
