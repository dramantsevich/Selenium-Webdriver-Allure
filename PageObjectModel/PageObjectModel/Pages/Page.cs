using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectModel.Pages
{
    public class Page
    {
        internal DefaultWait<IWebDriver> webDriverWait;
        protected IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            webDriverWait = GetWebDriverWait(driver);
        }

        static public DefaultWait<IWebDriver> GetWebDriverWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> webDriverWait = new DefaultWait<IWebDriver>(driver);
            webDriverWait.Timeout = TimeSpan.FromSeconds(20);
            webDriverWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return webDriverWait;
        }
    }
}
