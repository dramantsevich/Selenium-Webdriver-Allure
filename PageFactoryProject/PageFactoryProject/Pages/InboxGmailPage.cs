using OpenQA.Selenium;
using System.Collections.Generic;
using System;
using OpenQA.Selenium.Support.UI;
using PageFactoryProject.Pages.PopUpsObjects;
using SeleniumExtras.PageObjects;

namespace PageFactoryProject.Pages
{
    public class InboxGmailPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='gb_Nf gb_Qa gb_Dg gb_i']/a")]
        [CacheLookup]
        private readonly IWebElement GoogleAccountPopUp;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search mail']")]
        [CacheLookup]
        private readonly IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Search Mail']")]
        [CacheLookup]
        private readonly IWebElement SearchMailButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='p2DdMb']//div[@class='aT5-aOt-I-JX-Jw']")]
        [CacheLookup]
        private readonly IWebElement AddOnsPopUp;

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji T-I-KE L3']")]
        [CacheLookup]
        private readonly IWebElement NewMessagePopUp;

        [FindsBy(How = How.XPath, Using = "//div[@class='oZ-jc T-Jo J-J5-Ji ' and @role='checkbox']")]
        private readonly IList<IWebElement> AllMessagesCheckboxes;

        [FindsBy(How = How.XPath, Using = "//div[2]/span[@class='bA4']/span")]
        private readonly IList<IWebElement> AllMessages;

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']")]
        [CacheLookup]
        private readonly IWebElement DeleteSelectedMessagesButton;

        private By messagesByThemeLocator;
        private By messageByFileNameLocator;
        private By messageByEmailLocator;

        public InboxGmailPage(IWebDriver driver) : base(driver) { }

        public GoogleAccountPopUp OpenAccountManager()
        {
            GoogleAccountPopUp.Click();

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
            AddOnsPopUp.Click();

            return new AddOnsPopUp(driver);
        }

        public MessagePopUp OpenNewMessagePopUp()
        {
            NewMessagePopUp.Click();

            return new MessagePopUp(driver);
        }

        public Dictionary<IWebElement, IWebElement> GetDictionaryChechboxEmail() 
        {
            Dictionary<IWebElement, IWebElement> checkboxEmailPairs = new Dictionary<IWebElement, IWebElement>();

            for(int i = 0; i < AllMessages.Count; i++)
            {
                checkboxEmailPairs.Add(AllMessages[i], AllMessagesCheckboxes[i]);
            }

            return checkboxEmailPairs;
        }

        public Dictionary<IWebElement, IWebElement> GetCheckboxesFromMail(string mail)
        {
            Dictionary<IWebElement, IWebElement> checkboxesFromMailPairs = new Dictionary<IWebElement, IWebElement>();

            foreach(var checkboxesFromMail in GetDictionaryChechboxEmail())
            {
                if(checkboxesFromMail.Key.GetAttribute("email") == mail)
                {
                    checkboxesFromMailPairs.Add(checkboxesFromMail.Key, checkboxesFromMail.Value);
                }
            }

            return checkboxesFromMailPairs;
        }

        public void SelectCheckboxesFromMail(string mail)
        {
            Dictionary<IWebElement, IWebElement> checkboxesFromMailPairs = GetCheckboxesFromMail(mail);

            foreach(var checkbox in checkboxesFromMailPairs)
            {
                checkbox.Value.Click();
            }
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
            SelectCheckboxesFromMail(mail);

            try
            {
                DeleteSelectedMessagesButton.Click();
            }
            catch(System.Reflection.TargetInvocationException ex)
            {
                Console.WriteLine(ex.Message + $"\nMessages from {mail} to delete not found");
            }
        }

        public IWebElement GetSearchedMessageByTheme(string themeOfMessage)
        {
            this.messageByEmailLocator = By.XPath($"//div[@class='nH']/div[2]/div[@class='ae4 UI']/div[2]/div/table/tbody/tr/td[@class='xY a4W']/div/div/div/span/span[contains(text(),'{themeOfMessage}')]");

            IWebElement getMessage = webDriverWait.Until(ExpectedConditions.ElementIsVisible(this.messageByEmailLocator));

            return getMessage;
        }

        public IWebElement GetMessageByTheme(string themeOfMessage)
        {
            this.messagesByThemeLocator = By.XPath($"//div[6]/div/div[@class='ae4 aDM']/div/div/table/tbody/tr/td[@class='xY a4W']/div/div/div/span/span[contains(text(),'{themeOfMessage}')]");

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
