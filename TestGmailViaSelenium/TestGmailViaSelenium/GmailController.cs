using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace TestGmailViaSelenium
{
    static class GmailController
    {
        static string webSiteUrl;
        static IWebElement email;
        static IWebElement identifierNext;
        static IWebElement password;
        static IWebElement passwordNext;
        static IWebElement writeMessageButton;
        static IWebElement writeTo;
        static IWebElement theme;

        static public IWebDriver StartGmail(IWebDriver driver)
        {
            webSiteUrl = "https://gmail.com/";

            driver.Navigate().GoToUrl(webSiteUrl);

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            email = fluentWait.Until(x => x.FindElement(By.Name("identifier")));
            email.SendKeys("d.ramantsevich@gmail.com");

            identifierNext = fluentWait.Until(x => x.FindElement(By.Id("identifierNext")));
            identifierNext.Click();

            password = fluentWait.Until(x => x.FindElement(By.Name("password")));
            password.SendKeys("7182470Dima");

            passwordNext = fluentWait.Until(x => x.FindElement(By.Id("passwordNext")));
            passwordNext.Click();

            return driver;
        }


        public static DefaultWait<IWebDriver> GetFluentWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(30);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }

        static public void Message(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            writeMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']")));
            writeMessageButton.Click();

            writeTo = fluentWait.Until(x => x.FindElement(By.Name("to")));
            writeTo.SendKeys("d.ramantsevich@gmail.com");

            theme = fluentWait.Until(x => x.FindElement(By.Name("subjectbox")));
            theme.SendKeys("Theme1");
        }

        static public bool IsElementPresent(By by, IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            try
            {
                fluentWait.Until(x => x.FindElement(by));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
