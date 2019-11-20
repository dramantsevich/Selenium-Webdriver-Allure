using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestGmailViaSelenium
{
    public class GmailController
    {
        private IWebDriver currentDriver;
        DefaultWait<IWebDriver> fluentWait;

        public GmailController(IWebDriver driver)
        {
            this.currentDriver = driver;
        }

        private Dictionary<string, string> GetDictionaryAccounts()
        {
            string path = "../../../Account.txt";

            Dictionary<string, string> accounts = Account.GetAccounts(path);

            return accounts;
        }

        public string GetFirstMail()
        {
            string firstMail;

            Dictionary<string, string> accounts = GetDictionaryAccounts();

            firstMail = accounts.Keys.ElementAt(0);

            return firstMail;
        }

        public string GetFirstPassword()
        {
            string firstPassword;

            Dictionary<string, string> accounts = GetDictionaryAccounts();

            firstPassword = accounts[accounts.Keys.ElementAt(0)];

            return firstPassword;
        }

        public void StartGmail(string mail, string password)
        {
            string webSiteUrl = "https://gmail.com/";

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            this.currentDriver.Navigate().GoToUrl(webSiteUrl);

            SetMailInLogInWindow(mail);
            SetPasswordInLogInWindow(password);
        }
        
        public void SetMailInLogInWindow(string mail)
        {
            IWebElement emailField;
            IWebElement emailNextButton;

            emailField = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Name("identifier")));
            emailField.SendKeys(mail);

            emailNextButton = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Id("identifierNext")));
            emailNextButton.Click();
        }

        public void SetPasswordInLogInWindow(string password)
        {
            IWebElement passwordField;
            IWebElement passwordNextButton;

            passwordField = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Name("password")));
            passwordField.SendKeys(password);

            passwordNextButton = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Id("passwordNext")));
            passwordNextButton.Click();
        }

        public void QuitFromAccount()
        {
            IWebElement account;
            IWebElement logOutFromAccount;

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            account = fluentWait.Until(x => x.FindElement(By.XPath("//a[@class='gb_D gb_Fa gb_i']")));
            account.Click();

            logOutFromAccount = fluentWait.Until(x => x.FindElement(By.XPath("//a[@id='gb_71']")));
            logOutFromAccount.Click();
        }

        public void SerachMessageByTheme(string themeOfMessage)
        {
            IWebElement searchInMailField;
            IWebElement searchButton;
            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            searchInMailField = fluentWait.Until(x => x.FindElement(By.XPath("//input[@placeholder='Search mail']")));
            searchInMailField.SendKeys(themeOfMessage);

            searchButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@aria-label='Search Mail']")));
            searchButton.Click();
        }

        public void OpenGetAddonsForm()
        {
            IWebElement getAddOns;

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            getAddOns = fluentWait.Until(x => x.FindElement(By.XPath("//div[@id='p2DdMb']//div[@class='aT5-aOt-I-JX-Jw']")));
            getAddOns.Click();
        }

        public void OpenNewMessageForm()
        {
            IWebElement writeMessageButton;

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            writeMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']")));
            writeMessageButton.Click();
        }

        public void SetRecipientOfMessage(string email)
        {
            IWebElement writeTo;

            writeTo = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Name("to")));
            writeTo.SendKeys(email);
        }

        public void SetThemeOfMessage(string themeOfMessage)
        {
            IWebElement theme;

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            theme = fluentWait.Until(x => x.FindElement(By.Name("subjectbox")));
            theme.SendKeys(themeOfMessage);
        }

        public void SetMessageBody(string messageText)
        {
            IWebElement bodyOfMessage;

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            bodyOfMessage = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            bodyOfMessage.SendKeys(messageText);
        }

        public void SetAttachedFile(string pathFile)
        {
            IWebElement attachFile;

            attachFile = fluentWait.Until(x => x.FindElement(By.XPath("//input[@name='Filedata']")));
            attachFile.SendKeys(pathFile);
        }

        public void SentMessageButton()
        {
            IWebElement messageBody;

            messageBody = fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            messageBody.SendKeys(Keys.Control + Keys.Enter);
        }

        public void SentMessage(string email, string themeOfMessage, string messageText)
        {
            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            OpenNewMessageForm();
            SetRecipientOfMessage(email);
            SetThemeOfMessage(themeOfMessage);
            SetMessageBody(messageText);

            SentMessageButton();
        }

        public void SentMessageWithAttachedFile(string email, string themeOfMessage, string messageText, string pathFile)
        {
            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            OpenNewMessageForm();
            SetRecipientOfMessage(email);
            SetThemeOfMessage(themeOfMessage);
            SetMessageBody(messageText);
            SetAttachedFile(pathFile);

            SentMessageButton();
        }

        public void SentEmptyMessage()
        {
            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            OpenNewMessageForm();

            SentMessageButton();
        }

        public void DeleteSentMessagesFrom(string email)
        {
            IWebElement deleteSelectedMessagesButton;
            IList<IWebElement> checkboxes = GetAllMessageCheckbox();
            int countOfMessages;

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            countOfMessages = GetMessagesFrom(email).Count;

            for(int i = 0; i < countOfMessages; i++)
            {
                checkboxes.ElementAt(i).Click();
            }

            try
            {
                deleteSelectedMessagesButton = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']")));
                deleteSelectedMessagesButton.Click();
            }
            catch(OpenQA.Selenium.WebDriverTimeoutException e)
            {
                Console.WriteLine(e.Message + $"\nMessages from {email} to delete not found");
            }
        }

        public IList<IWebElement> GetMessagesFrom(string email)
        {
            List<IWebElement> listOfFoundMessages = new List<IWebElement>();
            IList<IWebElement> tempFoundMessages;

            try
            {
                fluentWait = FluentWait.GetFluentWait(this.currentDriver);

                tempFoundMessages = fluentWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath($"//div[2]/span[@class='bA4']/span[@email='{email}']")));
               
                foreach (IWebElement message in tempFoundMessages)
                {
                    listOfFoundMessages.Add(message);
                }

                return listOfFoundMessages;
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException e)
            {
                Console.WriteLine(e.Message + $"\nMessages from {email} not found");
                return listOfFoundMessages;
            }
        }

        public IList<IWebElement> GetAllMessageCheckbox()
        {
            IList<IWebElement> checkboxes;
            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            checkboxes = fluentWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='oZ-jc T-Jo J-J5-Ji ']")));

            return checkboxes;
        }

        public void CloseGmail()
        {
            this.currentDriver.Close();
        }

        public string GetFilePath(string fileName)
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string fileCurrentPath = $@"..\..\..\{fileName}";
            string path = Path.GetFullPath(Path.Combine(currentPath, fileCurrentPath));

            return path;
        }
    }
}
