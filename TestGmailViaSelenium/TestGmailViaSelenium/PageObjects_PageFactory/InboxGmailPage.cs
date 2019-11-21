using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestGmailViaSelenium.PageObjects_PageFactory.PopUpObjects;
using System.Collections.Generic;
using System.Linq;
using System;
using OpenQA.Selenium.Support.UI;

namespace TestGmailViaSelenium.PageObjects_PageFactory
{
    class InboxGmailPage
    {
        private readonly IWebDriver driver;
        public InboxGmailPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #region Elements of the inbox gmail page
        /// <summary>Entity for manage my google account</summary>
        [FindsBy(How = How.XPath, Using = "//a[@class='gb_D gb_Fa gb_i']")]
        public IWebElement GoogleAccount { get; set; }

        /// <summary>Message search field</summary>
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search mail']")]
        public IWebElement SearchField { get; set; }

        /// <summary>Search mail button</summary>
        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Search Mail']")]
        public IWebElement SearchMailButton { get; set; }

        /// <summary>Entity for get add-ons</summary>
        [FindsBy(How = How.XPath, Using = "//div[@id='p2DdMb']//div[@class='aT5-aOt-I-JX-Jw']")]
        public IWebElement AddOns { get; set; }

        /// <summary>Entity for message</summary>
        [FindsBy(How =How.XPath, Using = "//div[@class='T-I J-J5-Ji T-I-KE L3']")]
        public IWebElement NewMessagePopUp { get; set; }

        /// <summary>All checkboxes of incoming messages</summary>
        [FindsBy(How = How.XPath, Using = "//div[@class='oZ-jc T-Jo J-J5-Ji ']")]
        public IList<IWebElement> Checkboxes { get; set; }

        /// <summary>All messages inbox</summary>
        [FindsBy(How = How.XPath, Using = "//div[2]/span[@class='bA4']/span")]
        public IList<IWebElement> AllMessages { get; set; }

        /// <summary>Button to delete all selected messages</summary>
        [FindsBy(How = How.XPath, Using= "//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']")]
        public IWebElement DeleteSelectedMessagesButton { get; set; }
        #endregion

        //-------------------------------------------------------------------

        #region Methods for manipulation the inbox gmail page
        /// <summary>Quit from current account</summary>
        public void QuitFromAccount()
        {
            GoogleAccount.Click();

            GoogleAccountPopUp accountPopUp = new GoogleAccountPopUp(this.driver);

            accountPopUp.SignOutFromAccount();
        }

        /// <summary>Search for message by theme</summary>
        public void SearchMessageByTheme(string themeOfMessage)
        {
            SearchField.SendKeys(themeOfMessage);

            SearchMailButton.Click();
        }

        /// <summary>Open new add-ons popup</summary>
        public void OpenAddOnsPopUp()
        {
            AddOns.Click();
        }

        /// <summary>Open new message popup</summary>
        public void OpenNewMessagePopUp()
        {
            NewMessagePopUp.Click();
        }

        /// <summary>Get all messages from entering mail</summary>
        public IList<IWebElement> GetMessagesFrom(string email)
        {
            List<IWebElement> listOfFoundMessages = new List<IWebElement>();

            try
            {
                foreach(IWebElement message in AllMessages)
                {
                    if(message.GetAttribute("email") == email)
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

        /// <summary>Method for selecting a specific number of checkboxes </summary>
        public void SelectCheckboxes(int countOfMessages)
        {
            for (int i = 0; i < countOfMessages; i++)
            {
                Checkboxes.ElementAt(i).Click();
            }
        }

        /// <summary>Delete all messages from entering mail</summary>
        public void DeleteSentMessagesFrom(string mail)
        {
            IWebElement windowsValidationAppearance;

            DefaultWait<IWebDriver> fluentWait = FluentWait.GetFluentWait(this.driver);

            int countOfMessages = GetMessagesFrom(mail).Count;

            SelectCheckboxes(countOfMessages);

            try
            {
                DeleteSelectedMessagesButton.Click();

                windowsValidationAppearance = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='vh']/span[@class='aT']/span[@class='bAq'][contains (text(),' moved to Bin.')]")));
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException e)
            {
                Console.WriteLine(e.Message + $"\nMessages from {mail} to delete not found");
            }
        }
        #endregion
    }
}
