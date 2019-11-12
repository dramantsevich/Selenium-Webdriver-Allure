using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace GmailViaSelenium
{
    public class GmailSelenium
    {
        private IWebDriver driver;
        private string webSiteUrl;

        public static DefaultWait<IWebDriver> GetFluentWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(30);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }

        public void StartWebBrowser()
        {
            driver = new ChromeDriver();
            webSiteUrl = "https://gmail.com";

            driver.Navigate().GoToUrl(webSiteUrl);
        }

        public void LogInAccount()
        {
            IWebElement email;
            IWebElement identifierNext;
            IWebElement password;
            IWebElement passwordNext;

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            email = fluentWait.Until(x => x.FindElement(By.Name("identifier")));
            email.SendKeys("d.ramantsevich@gmail.com");

            identifierNext = fluentWait.Until(x => x.FindElement(By.Id("identifierNext")));
            identifierNext.Click();

            password = fluentWait.Until(x => x.FindElement(By.Name("password")));
            password.SendKeys("7182470Dima");

            passwordNext = fluentWait.Until(x => x.FindElement(By.Id("passwordNext")));
            passwordNext.Click();
        }

        public void ButtonSearch()
        {
            IWebElement searchInMailField;
            IWebElement searchButton;

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            searchInMailField = fluentWait.Until(x => x.FindElement(By.XPath("//input[@placeholder='Search mail']")));
            searchInMailField.SendKeys("Xinuos");

            searchButton = fluentWait.Until(x => x.FindElement(By.XPath("//button[@aria-label='Search Mail']")));
            searchButton.Click();
        }

        public void WriteMessage()
        {

        }
    }
}
