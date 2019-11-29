using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.PageObjects;

namespace PageFactoryProject.Pages
{
    public class Page
    {
        protected DefaultWait<IWebDriver> webDriverWait;
        protected IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;

            this.webDriverWait = GetWebDriverWait(this.driver);

            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
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
