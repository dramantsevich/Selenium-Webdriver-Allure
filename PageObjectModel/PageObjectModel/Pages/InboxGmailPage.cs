using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageObjectModel.Pages 
{
    public class InboxGmailPage : Page
    {
        readonly By googleAccountLocator = By.XPath("//a[@class='gb_D gb_Ha gb_i']");
        readonly By searchFieldLocator = By.XPath("//input[@placeholder='Search mail']");
        readonly By searchMailButtonLocator = By.XPath("//button[@aria-label='Search Mail']");
        readonly By addOnsLocator = By.XPath("//div[@id='p2DdMb']//div[@class='aT5-aOt-I-JX-Jw']");
        readonly By newMessagePopUpLocator = By.XPath("//div[@class='z0']/div[1]");
        readonly By allCheckboxesLocator = By.XPath("//div[@class='oZ-jc T-Jo J-J5-Ji ']");
        readonly By allMessagesLocator = By.XPath("//div[2]/span[@class='bA4']/span");
        readonly By deleteSelectedMessagesButtonLocator = By.XPath("//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']");
        readonly By binPopUpLocator = By.XPath("//div[@class='vh']/span[@class='aT']/span[@class='bAq'][contains (text(),' moved to Bin.')]");
        private By messagesByThemeLocator;
        private By messageByFileNameLocator;
        private By messageByEmailLocator;

        public InboxGmailPage(IWebDriver driver) : base(driver) { }
        
        public void OpenAccountManager()
        {
            IWebElement account = webDriverWait.Until(x => x.FindElement(googleAccountLocator));
            account.Click();
        }

        public void SetSearchMailField(string searchMail)
        {
            IWebElement searchField = webDriverWait.Until(x => x.FindElement(this.searchFieldLocator));
            searchField.SendKeys(searchMail);
        }

        public void SearchMessageByTheme(string themeOfMessage)
        {
            SetSearchMailField(themeOfMessage);

            IWebElement searchMailButton = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(this.searchMailButtonLocator));
            searchMailButton.Click();
        }

        public void OpenAddOnsPopUp()
        {
            IWebElement addOns = webDriverWait.Until(x => x.FindElement(this.addOnsLocator));
            addOns.Click();
        }

        public void OpenNewMessagePopUp()
        {
            IWebElement newMessage = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(this.newMessagePopUpLocator));
            newMessage.Click();
        }

        public IList<IWebElement> GetAllMessageCheckboxes()
        {
            IList<IWebElement> checkboxes = webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(this.allCheckboxesLocator));
            return checkboxes;
        }

        public IList<IWebElement> GetMessagesFrom(string email)
        {
            List<IWebElement> listOfFoundMessages = new List<IWebElement>();

            try
            {
                IList<IWebElement> tempFoundMessages = webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(this.allMessagesLocator));

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
            IList<IWebElement> allCheckboxes = GetAllMessageCheckboxes();

            int countOfMessages = GetMessagesFrom(mail).Count;

            for(int i = 0; i < countOfMessages; i++)
            {
                //Thread.Sleep(500);
                allCheckboxes.ElementAt(i).Click();
            }

            try
            {
                IWebElement deleteSelectedMessagesButton = webDriverWait.Until(ExpectedConditions.ElementIsVisible(this.deleteSelectedMessagesButtonLocator));
                deleteSelectedMessagesButton.Click();

                //IWebElement binPopUp = GetBinPopUp();
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException e)
            {
                Console.WriteLine(e.Message + $"\nMessages from {mail} to delete not found");
            }
        }

        public IWebElement GetBinPopUp()
        {
            IWebElement binPopUp = webDriverWait.Until(ExpectedConditions.ElementExists(this.binPopUpLocator));
            return binPopUp;
        }

        public IWebElement GetMessageByTheme(string themeOfMessage)
        {
            this.messagesByThemeLocator = By.XPath($"//td[@class='xY a4W']/div/div/div/span/span[contains(text(),'{themeOfMessage}')]");

            IWebElement getMessage = webDriverWait.Until(ExpectedConditions.ElementIsVisible(this.messagesByThemeLocator));
            return getMessage;
        }

        public IWebElement GetMessageByFileName(string fileName)
        {
            this.messageByFileNameLocator = By.XPath($"//td[@class='xY a4W']/div[@class='brd']/div/span[contains(text(),'{fileName}')]");

            IWebElement getMessage = webDriverWait.Until(ExpectedConditions.ElementExists(this.messageByFileNameLocator));
            return getMessage;
        }

        public bool IsMessagesFromMailNotFound(string mail)
        {
            this.messageByEmailLocator = By.XPath($"//div[2]/span[@class='bA4']/span[@email='{mail}']");

            bool isNotFoundMessage = webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(this.messageByEmailLocator));
            return isNotFoundMessage;
        }
    }
}
