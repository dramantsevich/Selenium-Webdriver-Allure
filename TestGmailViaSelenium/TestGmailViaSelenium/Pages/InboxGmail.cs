using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TestGmailViaSelenium.Pages.PopUpWindows;

namespace TestGmailViaSelenium.Pages
{
    public class InboxGmail
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        By googleAccount = By.XPath("//a[@class='gb_D gb_Fa gb_i'");
        By searchField = By.XPath("//input[@placeholder='Search mail']");
        By searchMailButton = By.XPath("//button[@aria-label='Search Mail']");
        By addOns = By.XPath("//div[@id='p2DdMb']//div[@class='aT5-aOt-I-JX-Jw']");
        By newMessagePopUp = By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']");
        By allCheckboxes = By.XPath("//div[@class='oZ-jc T-Jo J-J5-Ji ']");
        By allMessages = By.XPath("//div[2]/span[@class='bA4']/span");
        By deleteSelectedMessagesButton = By.XPath("//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']");

        public InboxGmail(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenAccountManager()
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement account = fluentWait.Until(x => x.FindElement(googleAccount));

            account.Click();
        }

        public void QuitFromAccount()
        {
            OpenAccountManager();

            AccountPopUp accountPopUp = new AccountPopUp(this.driver);

            accountPopUp.SignOutFromAccount();
        }

        public void SetSearchMailField(string searchMail)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement searchField = fluentWait.Until(x => x.FindElement(this.searchField));

            searchField.SendKeys(searchMail);
        }

        //public IWebElement GetSearchMailButton()
        //{
        //    fluentWait = FluentWait.GetFluentWait(this.driver);
        //    IWebElement searchMailButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(this.searchMailButton));

        //    return searchMailButton;
        //}

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

                foreach(IWebElement message in tempFoundMessages)
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

        public void DeleteSentMessageFrom(string mail)
        {
            IWebElement windowValidationAppearance;
            IWebElement deleteSelectedMessagesButton;

            DefaultWait<IWebDriver> fluentWait = FluentWait.GetFluentWait(this.driver);

            int countOfMessages = GetMessagesFrom(mail).Count;

            try
            {
                deleteSelectedMessagesButton = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.deleteSelectedMessagesButton));
                deleteSelectedMessagesButton.Click();

                windowValidationAppearance = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='vh']/span[@class='aT']/span[@class='bAq'][contains (text(),' moved to Bin.')]")));
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException e)
            {
                Console.WriteLine(e.Message + $"\nMessages from {mail} to delete not found");
            }
        }
    }
}
