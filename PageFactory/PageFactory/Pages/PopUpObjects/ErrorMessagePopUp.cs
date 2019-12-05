using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageFactory.Pages.PopUpObjects
{
    public class ErrorMessagePopUp : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='Kj-JD']/div[@class='Kj-JD-K7 Kj-JD-K7-bsT']/span[1]")]
        [CacheLookup]
        private readonly IWebElement Title;

        [FindsBy(How = How.XPath, Using = "//div[@class='Kj-JD']")]
        private readonly IWebElement ErrorMessagePopupForm;

        public ErrorMessagePopUp(IWebDriver driver) : base(driver) { }

        public string GetTitleText()
        {
            return Title.Text;
        }

        public bool IsDisplayd()
        {
            if (ErrorMessagePopupForm.Displayed)
                return true;
            else
                return false;
        }
    }
}
