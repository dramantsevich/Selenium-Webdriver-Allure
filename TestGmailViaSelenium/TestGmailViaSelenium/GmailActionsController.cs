using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestGmailViaSelenium
{
    public class GmailActionsController
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        IWebElement messageBody;
        IWebElement attachFile;
        IWebElement writeMessageButton;

        public GmailActionsController(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebDriver StartGmail(string email, string password)
        {
            string webSiteUrl;
            IWebElement emailWebElement;
            IWebElement identifierNext;
            IWebElement passwordWebElement;
            IWebElement passwordNext;

            List<string> emails = new List<string>();
            List<string> passwords = new List<string>();

            GetAccounts.GetAccount(emails, passwords);

            webSiteUrl = "https://gmail.com/";

            this.driver.Navigate().GoToUrl(webSiteUrl);

            fluentWait = FluentWait.GetFluentWait(this.driver);

            emailWebElement = fluentWait.Until(x => x.FindElement(By.Name("identifier")));
            emailWebElement.SendKeys(email);

            identifierNext = fluentWait.Until(x => x.FindElement(By.Id("identifierNext")));
            identifierNext.Click();

            passwordWebElement = fluentWait.Until(x => x.FindElement(By.Name("password")));
            passwordWebElement.SendKeys(password);

            passwordNext = fluentWait.Until(x => x.FindElement(By.Id("passwordNext")));
            passwordNext.Click();

            return this.driver;
        }

        public void QuitFromAccount()
        {
            IWebElement account;
            IWebElement logOutFromAccount;

            fluentWait = FluentWait.GetFluentWait(this.driver);

            account = fluentWait.Until(x => x.FindElement(By.XPath("//a[@class='gb_D gb_Fa gb_i']")));
            account.Click();

            logOutFromAccount = fluentWait.Until(x => x.FindElement(By.XPath("//a[@id='gb_71']")));
            logOutFromAccount.Click();
        }

        public void ButtonSearch()
        {
            IWebElement searchInMailField;
            IWebElement searchButton;
            fluentWait = FluentWait.GetFluentWait(this.driver);

            searchInMailField = fluentWait.Until(x => x.FindElement(By.XPath("//input[@placeholder='Search mail']")));
            searchInMailField.SendKeys("Xinuos");

            searchButton = fluentWait.Until(x => x.FindElement(By.XPath("//button[@aria-label='Search Mail']")));
            searchButton.Click();
        }

        public void GetAddOns()
        {
            IWebElement getAddOns;

            fluentWait = FluentWait.GetFluentWait(this.driver);

            getAddOns = fluentWait.Until(x => x.FindElement(By.XPath("//div[@id='p2DdMb']//div[@class='aT5-aOt-I-JX-Jw']")));
            getAddOns.Click();
        }

        public void Message(string email)
        {
            IWebElement writeTo;
            IWebElement theme;

            fluentWait = FluentWait.GetFluentWait(this.driver);

            writeMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']")));
            writeMessageButton.Click();

            writeTo = fluentWait.Until(x => x.FindElement(By.Name("to")));
            writeTo.SendKeys(email);

            theme = fluentWait.Until(x => x.FindElement(By.Name("subjectbox")));
            theme.SendKeys("Theme1");
        }

        public void SentMessage(string email)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);

            Message(email);

            messageBody = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            messageBody.SendKeys("qwerty");
            messageBody.SendKeys(Keys.Control + Keys.Enter);
        }

        public void SentMessageWithAttachedFile(string email, string pathFile)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);

            Message(email);

            attachFile = fluentWait.Until(x => x.FindElement(By.XPath("//input[@name='Filedata']")));
            attachFile.SendKeys(pathFile);

            messageBody = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            messageBody.SendKeys(Keys.Control + Keys.Enter);
        }

        public void SentEmptyMessageForm()
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);

            writeMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']")));
            writeMessageButton.Click();

            messageBody = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            messageBody.SendKeys(Keys.Control + Keys.Enter);
        }

        public void DeleteSentMessagesFrom(string email)
        {
            IWebElement deleteSelectedMessagesButton;
            IList<IWebElement> selectFoundMessagesFromFoundEmail;
            IList<IWebElement> selectCheckboxes;
            fluentWait = FluentWait.GetFluentWait(this.driver);

            if (IsElementPresent(By.XPath($"//div[2]/span[@class='bA4']/span[@email='{email}']")))
            {
                Thread.Sleep(2000);
                selectFoundMessagesFromFoundEmail = fluentWait.Until(x => x.FindElements(By.XPath($"//div[2]/span[@class='bA4']/span[@email='{email}']")));
                selectCheckboxes = fluentWait.Until(x => x.FindElements(By.XPath("//div[@class='oZ-jc T-Jo J-J5-Ji ']")));

                for(int i = 0; i < selectFoundMessagesFromFoundEmail.Count; i++)
                {
                    selectCheckboxes.ElementAt(i).Click();
                }

                deleteSelectedMessagesButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']")));
                deleteSelectedMessagesButton.Click();
            }
        }

        public void CloseGmail()
        {
            this.driver.Close();
        }

        public bool IsElementPresent(By by)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);

            try
            {
                fluentWait.Until(x => x.FindElements(by));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
