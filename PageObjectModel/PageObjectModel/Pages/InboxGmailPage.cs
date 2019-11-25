using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PageObjectModel.Pages
{
    public class InboxGmailPage
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        readonly By googleAccount = By.XPath("//a[@class='gb_D gb_Ha gb_i']");
        readonly By searchField = By.XPath("//input[@placeholder='Search mail']");
        readonly By searchMailButton = By.XPath("//button[@aria-label='Search Mail']");
        readonly By addOns = By.XPath("//div[@id='p2DdMb']//div[@class='aT5-aOt-I-JX-Jw']");
        readonly By newMessagePopUp = By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']");
        readonly By allCheckboxes = By.XPath("//div[@class='oZ-jc T-Jo J-J5-Ji ']");
        readonly By allMessages = By.XPath("//div[2]/span[@class='bA4']/span");
        readonly By deleteSelectedMessagesButton = By.XPath("//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']");
        readonly By binPopUp = By.XPath("//div[@class='vh']/span[@class='aT']/span[@class='bAq'][contains (text(),' moved to Bin.')]");
        private By getMessageByTheme;
        private By getMessageByFileName;
        private By getMessageByEmail;

        public InboxGmailPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public void OpenAccountManager()
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement account = fluentWait.Until(x => x.FindElement(googleAccount));

            account.Click();
        }

        public void SetSearchMailField(string searchMail)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement searchField = fluentWait.Until(x => x.FindElement(this.searchField));

            searchField.SendKeys(searchMail);
        }

        public void SearchMessageByTheme(string themeOfMessage)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement searchMailButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(this.searchMailButton));

            SetSearchMailField(themeOfMessage);

            searchMailButton.Click();
        }

        public void OpenAddOnsPopUp()
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement addOns = fluentWait.Until(x => x.FindElement(this.addOns));

            addOns.Click();
        }

        public void OpenNewMessagePopUp()
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement newMessage = fluentWait.Until(ExpectedConditions.ElementToBeClickable(this.newMessagePopUp));

            newMessage.Click();
        }

        public IList<IWebElement> GetAllMessageCheckboxes()
        {
            IList<IWebElement> checkboxes;
            fluentWait = FluentWait.GetFluentWait(this.driver);

            checkboxes = fluentWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(this.allCheckboxes));

            return checkboxes;
        }

        public IList<IWebElement> GetMessagesFrom(string email)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IList<IWebElement> tempFoundMessages;

            List<IWebElement> listOfFoundMessages = new List<IWebElement>();

            try
            {
                tempFoundMessages = fluentWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(this.allMessages));

                foreach (IWebElement message in tempFoundMessages)
                {
                    if (message.GetAttribute("email") == email)
                    {
                        listOfFoundMessages.Add(message);
                    }
                }

                return listOfFoundMessages;
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException e)
            {
                Console.WriteLine(e.Message + $"\nMessages from {email} not found");
                return listOfFoundMessages;
            }
        }

        public void DeleteSentMessageFrom(string mail)
        {
            IWebElement binPopUp;
            IWebElement deleteSelectedMessagesButton;
            IList<IWebElement> allCheckboxes = GetAllMessageCheckboxes();

            fluentWait = FluentWait.GetFluentWait(this.driver);

            int countOfMessages = GetMessagesFrom(mail).Count;

            for(int i = 0; i < countOfMessages; i++)
            {
                Thread.Sleep(500);
                allCheckboxes.ElementAt(i).Click();
            }

            try
            {
                deleteSelectedMessagesButton = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.deleteSelectedMessagesButton));
                deleteSelectedMessagesButton.Click();

                binPopUp = GetBinPopUp();
                Thread.Sleep(3000);
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException e)
            {
                Console.WriteLine(e.Message + $"\nMessages from {mail} to delete not found");
            }
        }

        public IWebElement GetBinPopUp()
        {
            IWebElement binPopUp;

            fluentWait = FluentWait.GetFluentWait(this.driver);

            binPopUp = fluentWait.Until(ExpectedConditions.ElementExists(this.binPopUp));

            return binPopUp;
        }

        public IWebElement GetMessageByTheme(string themeOfMessage)
        {
            IWebElement getMessage;

            fluentWait = FluentWait.GetFluentWait(this.driver);

            this.getMessageByTheme = By.XPath($"//td[@class='xY a4W']/div/div/div/span/span[contains(text(),'{themeOfMessage}')]");

            getMessage = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.getMessageByTheme));

            return getMessage;
        }

        public IWebElement GetMessageByFileName(string fileName)
        {
            IWebElement getMessage;

            fluentWait = FluentWait.GetFluentWait(this.driver);

            this.getMessageByFileName = By.XPath($"//td[@class='xY a4W']/div[@class='brd']/div/span[contains(text(),'{fileName}')]");

            getMessage = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.getMessageByFileName));

            return getMessage;
        }

        public bool IsMessagesFromMailNotFound(string mail)
        {
            GmailController controller = new GmailController(this.driver);

            string firstMail = controller.GetFirstMail();
            
            this.getMessageByEmail = By.XPath($"//div[2]/span[@class='bA4']/span[@email='{firstMail}']");

            bool isNotFoundMessage = fluentWait.Until(ExpectedConditions.InvisibilityOfElementLocated(this.getMessageByEmail));

            return isNotFoundMessage;
        }
    }
}
