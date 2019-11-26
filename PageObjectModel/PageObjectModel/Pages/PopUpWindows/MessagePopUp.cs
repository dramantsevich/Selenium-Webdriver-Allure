using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectModel.Pages.PopUpWindows
{
    public class MessagePopUp : Page
    {
        readonly By recipientFieldLocator = By.Name("to");
        readonly By themeFieldLocator = By.Name("subjectbox");
        readonly By bodyFieldLocator = By.XPath("//td[@class='Ap']/div[2]/div[1]");
        readonly By attachFileLocator = By.XPath("//input[@name='Filedata']");
        readonly By sendMessageButtonLocator = By.XPath("//div[@class='dC']/div[1]");

        public MessagePopUp(IWebDriver driver) : base(driver) { }

        public void SetRecipientOfMessage(string mail)
        {
            IWebElement recipientField = webDriverWait.Until(ExpectedConditions.ElementIsVisible(this.recipientFieldLocator));
            recipientField.SendKeys(mail);
        }

        public void SetThemeOfMessage(string themeOfMessage)
        {
            IWebElement themeField = webDriverWait.Until(ExpectedConditions.ElementIsVisible(this.themeFieldLocator));
            themeField.SendKeys(themeOfMessage);
        }

        public void SetMessageBody(string messageText)
        {
            IWebElement bodyField = webDriverWait.Until(x => x.FindElement(this.bodyFieldLocator));
            bodyField.SendKeys(messageText);
        }

        public void SetAttachedFile(string fileName)
        {
            GmailController controller = new GmailController(driver);

            string path = controller.GetFilePath(fileName);

            IWebElement attachFile = webDriverWait.Until(x => x.FindElement(this.attachFileLocator));
            attachFile.SendKeys(path);
        }

        public void SetFullMessage(string email, string themeOfMessage, string messageText)
        {
            SetRecipientOfMessage(email);
            SetThemeOfMessage(themeOfMessage);
            SetMessageBody(messageText);
        }

        public void SendMessage()
        {
            IWebElement sendMessageButton = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(this.sendMessageButtonLocator));
            sendMessageButton.Click();
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
            try {
                IAlert alert = webDriverWait.Until(ExpectedConditions.AlertIsPresent());
                alert.Accept();
            }
            catch(WebDriverTimeoutException ex)
            {
                Console.WriteLine("Alert is not present" + ex.Message);
            }
        }
    }
}
