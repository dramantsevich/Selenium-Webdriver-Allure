using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestGmailViaSelenium.PageObjects_PageFactory.PopUpObjects
{
    class AddOnsPopUp
    {
        private readonly IWebDriver driver;

        /// <summary>Title from add-ons popup</summary>
        [FindsBy(How = How.XPath, Using = "//span[@class='yQsxXc']")]
        public IWebElement Title { get; set; }

        /// <summary>Get the title from add-ons popup</summary>
        public string GetAddOnsTitle()
        {
            return Title.Text;
        }

        public AddOnsPopUp(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
