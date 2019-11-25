using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestGmailViaSelenium.Pages.PopUpWindows
{
    public class MessagePopUp
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        By recipientField = By.Name("to");
        By themeField = By.Name("subjectbox");
        By bodyField = By.XPath("//td[@class='Ap']/div[2]/div[1]");
        By attachFile = By.XPath("//input[@name='Filedata']");
        By sendMessageButton = By.XPath("//div[@class='dC']/div[1]");

        public MessagePopUp(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SetRecipientOfMessage(string mail)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement recipientField = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.recipientField));

            recipientField.SendKeys(mail);
        }

        public void SetThemeOfMessage(string themeOfMessage)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement themeField = fluentWait.Until(ExpectedConditions.ElementIsVisible(this.themeField));

            themeField.SendKeys(themeOfMessage);
        }

        public void SetMessageBody(string messageText)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement bodyField = fluentWait.Until(x => x.FindElement(this.bodyField));

            bodyField.SendKeys(messageText);
        }

        public void SetAttachedFile(string fileName)
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement attachFile = fluentWait.Until(x => x.FindElement(this.attachFile));
            GmailController controller = new GmailController(this.driver);

            string path = controller.GetFilePath(fileName);

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
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement sendMessageButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(this.sendMessageButton));

            sendMessageButton.Click();
        }

        public void SendMessageWithAttachedFile(string email, string themeOfMessage, string messageText, string pathFile)
        {
            SetFullMessage(email, themeOfMessage, messageText);

            SetAttachedFile(pathFile);

            SendMessage();
        }
    }
}
