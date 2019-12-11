using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace tTutBy.Pages
{
    public class Page
    {
        protected IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;

            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        public string GetCurrentUrl()
        {
            return this.driver.Url;
        }
    }
}
