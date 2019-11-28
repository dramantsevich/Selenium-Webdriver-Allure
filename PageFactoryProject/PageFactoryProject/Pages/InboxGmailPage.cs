using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System;
using OpenQA.Selenium.Support.UI;
using PageFactoryProject.Pages.PopUpsObjects;
using System.Threading;
using SeleniumExtras.PageObjects;
//using OpenQA.Selenium.Support.PageObjects;

namespace PageFactoryProject.Pages
{
    public class InboxGmailPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='gb_Nf gb_Qa gb_Dg gb_i']/a")]
        private readonly IWebElement GoogleAccount;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search mail']")]
        private readonly IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Search Mail']")]
        private readonly IWebElement SearchMailButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='p2DdMb']//div[@class='aT5-aOt-I-JX-Jw']")]
        private readonly IWebElement AddOns;

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji T-I-KE L3']")]
        private readonly IWebElement NewMessagePopUp;

        [FindsBy(How = How.XPath, Using = "//*[@role='checkbox']")]
        private readonly IList<IWebElement> AllCheckboxes;

        [FindsByAll]
        [FindsBy(How = How.XPath, Using = "//div[2]/span[@class='bA4']/span")]
        private readonly IList<IWebElement> AllMessages;

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']")]
        private readonly IWebElement DeleteSelectedMessagesButton;

        private By messagesByThemeLocator;
        private By messageByFileNameLocator;
        private By messageByEmailLocator;

        public InboxGmailPage(IWebDriver driver) : base(driver) { }

        public GoogleAccountPopUp OpenAccountManager()
        {
            GoogleAccount.Click();

            return new GoogleAccountPopUp(driver);
        }

        public void SetSearchMailField(string searchMail)
        {
            SearchField.SendKeys(searchMail);
        }

        public void SearchMessageByTheme(string themeOfMessage)
        {
            SetSearchMailField(themeOfMessage);

            SearchMailButton.Click();
        }

        public AddOnsPopUp OpenAddOnsPopUp()
        {
            AddOns.Click();

            return new AddOnsPopUp(driver);
        }

        public MessagePopUp OpenNewMessagePopUp()
        {
            NewMessagePopUp.Click();

            return new MessagePopUp(driver);
        }

        public IList<IWebElement> GetMessagesFrom(string email)
        {
            List<IWebElement> listOfFoundMessages = new List<IWebElement>();

            try
            {
                foreach (IWebElement message in AllMessages)
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

        public void DeleteAllSentMessagesFrom(string mail)
        {
            int countOfMessages = GetMessagesFrom(mail).Count;
            Console.WriteLine(countOfMessages);

            for (int i = 0; i < countOfMessages; i++)
            {
                Thread.Sleep(500);

                AllCheckboxes.ElementAt(i + 1).Click();
            }
            try
            {
                //DeleteSelectedMessagesButton.Click();
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException e)
            {
                Console.WriteLine(e.Message + $"\nMessages from {mail} to delete not found");
            }
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
