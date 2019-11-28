using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace PageFactoryProject.Pages.PopUpsObjects
{
    public class MessagePopUp : Page
    {
        [FindsBy(How = How.Name, Using = "to")]
        private readonly IWebElement RecipientField;

        [FindsBy(How = How.Name, Using = "subjectbox")]
        private readonly IWebElement ThemeField;

        [FindsBy(How = How.XPath, Using = "//td[@class='Ap']/div[2]/div[1]")]
        private readonly IWebElement BodyField;

        [FindsBy(How = How.XPath, Using = "//input[@name='Filedata']")]
        private readonly IWebElement AttachFile;

        [FindsBy(How = How.XPath, Using = "//div[@class='dC']/div[1]")]
        private readonly IWebElement SendMessageButton;
        
        public MessagePopUp(IWebDriver driver) : base(driver) { }

        public void SetRecipientOfMessage(string mail)
        {
            RecipientField.SendKeys(mail);
        }

        public void SetThemeOfMessage(string themeOfMessage)
        {
            ThemeField.SendKeys(themeOfMessage);
        }

        public void SetMessageBody(string messageText)
        {
            BodyField.SendKeys(messageText);
        }

        public void SetAttachedFile(string pathFile)
        {
            AttachFile.SendKeys(pathFile);
        }

        public void SetFullMessage(string email, string themeOfMessage, string messageText)
        {
            SetRecipientOfMessage(email);
            SetThemeOfMessage(themeOfMessage);
            SetMessageBody(messageText);
        }

        public ErrorMessagePopUp SendMessage()
        {
            SendMessageButton.Click();

            return new ErrorMessagePopUp(driver);
        }

        public void SendFullMessage(string email, string themeOfMessage, string messageText)
        {
            SetFullMessage(email, themeOfMessage, messageText);

            SendMessage();
        }

        public void SendMessageWithAttachedFile(string email, string themeOfMessage, string messageText, string pathFile)
        {
            SetFullMessage(email, themeOfMessage, messageText);

            SetAttachedFile(pathFile);

            SendMessage();
        }
        public void ConfirmAlert()
        {
            try
            {
                IAlert alert = webDriverWait.Until(ExpectedConditions.AlertIsPresent());
                alert.Accept();
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("Alert is not present" + ex.Message);
            }
        }
    }
}
