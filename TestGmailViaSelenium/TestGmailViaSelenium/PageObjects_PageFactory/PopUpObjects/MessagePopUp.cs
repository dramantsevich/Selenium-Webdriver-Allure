using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestGmailViaSelenium.PageObjects_PageFactory.PopUpObjects
{
    class MessagePopUp
    {
        private readonly IWebDriver driver;

        public MessagePopUp (IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Elemenets for Message popup
        /// <summary>Message recipient field</summary>
        [FindsBy(How = How.Name, Using ="to")]
        public IWebElement RecipientField { get; set; }

        /// <summary>Message theme field</summary>
        [FindsBy(How = How.Name, Using = "subjectbox")]
        public IWebElement ThemeField { get; set; }

        /// <summary>Message body field</summary>
        [FindsBy(How = How.XPath, Using = "//td[@class='Ap']/div[2]/div[1]")]
        public IWebElement BodyField { get; set; }

        /// <summary>Button for attaching file</summary>
        [FindsBy(How = How.XPath, Using = "//input[@name='Filedata']")]
        public IWebElement AttachFile { get; set; }

        /// <summary>Button for sent message</summary>
        [FindsBy(How = How.XPath, Using = "//div[@class='dC']/div[1]")]
        public IWebElement SendMessageButton { get; set; }
        #endregion

        //-------------------------------------------------------------------

        #region Methods for manipulating on the message popup
        /// <summary>Method for set recipient of message</summary>
        public void SetRecipientOfMessage(string mail)
        {
            RecipientField.SendKeys(mail);
        }

        /// <summary>Method for set theme of message</summary>
        public void SetThemeOfMessage(string themeOfMessage)
        {
            ThemeField.SendKeys(themeOfMessage);
        }

        /// <summary>Method for set body of message</summary>
        public void SetMessageBody(string messageText)
        {
            BodyField.SendKeys(messageText);
        }

        /// <summary>Method for set file in message, input full path to file</summary>
        public void SetAttachedFile(string pathFile)
        {
            AttachFile.SendKeys(pathFile);
        }

        /// <summary>Method for set full message with a completed email, theme and body of message</summary>
        public void SetFullMessage(string email, string themeOfMessage, string messageText)
        {
            SetRecipientOfMessage(email);
            SetThemeOfMessage(themeOfMessage);
            SetMessageBody(messageText);
        }

        /// <summary>Method for send message</summary>
        public void SendMessage()
        {
            SendMessageButton.Click();
        }

        /// <summary>Send a full message with a completed email, theme and body of message</summary>
        public void SendFullMessage(string email, string themeOfMessage, string messageText)
        {
            SetFullMessage(email, themeOfMessage, messageText);

            SendMessage();
        }

        /// <summary>Send a full completed message with attached file</summary>
        public void SendMessageWithAttachedFile(string email, string themeOfMessage, string messageText, string pathFile)
        {
            SetFullMessage(email, themeOfMessage, messageText);

            SetAttachedFile(pathFile);

            SendMessage();
        }
        #endregion
    }
}
