using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestGmailViaSelenium
{
    public class GmailActionsTests
    {
        private IWebElement foundMessage;
        private IWebDriver currentDriver;
        private GmailController gmailController;
        DefaultWait<IWebDriver> fluentWait;

        [SetUp]
        public void SetUp()
        {
            this.currentDriver = new ChromeDriver();

            this.gmailController = new GmailController(this.currentDriver);

            string firstMail = gmailController.SetFirstMail();
            string firstPassword = gmailController.SetFirstPassword();

            gmailController.StartGmail(firstMail,firstPassword);
        }

        [Test]
        public void StartGmail_LogIn()
        {
            IWebElement accountButton;
            IWebElement currentAccountMailOnPage;
            string currentMail = gmailController.SetFirstMail();

            fluentWait = FluentWait.GetFluentWait(this.currentDriver);

            accountButton = fluentWait.Until(x => x.FindElement(By.XPath("//a[@class='gb_D gb_Fa gb_i']")));
            accountButton.Click();

            currentAccountMailOnPage = fluentWait.Until(x => x.FindElement(By.XPath($"//div[@class='gb_jb']")));

            Assert.IsTrue(currentAccountMailOnPage.Text == currentMail);
        }

        [Test]
        public void QuitFromAccount()
        {
            fluentWait = FluentWait.GetFluentWait(this.currentDriver);
            
            string currentURL = "https://accounts.google.com/ServiceLogin/signinchooser?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin";

            gmailController.QuitFromAccount();

            bool isUrlContainsCurrentUrl = fluentWait.Until(ExpectedConditions.UrlContains(currentURL));

            Assert.IsTrue(isUrlContainsCurrentUrl);
        }

        [Test]
        public void ButtonSearch_FoundMessage()
        {
            string themeOfMessage = "Xinuos";

            fluentWait = FluentWait.GetFluentWait(currentDriver);

            gmailController.SerachMessageByTheme(themeOfMessage);

            foundMessage = fluentWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(),'Xinuos Inc.')]")));

            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void GetAddOns_IsVisible()
        {
            IWebElement addOnsFrame;
            IWebElement addOnsFrameTitle;
            fluentWait = FluentWait.GetFluentWait(currentDriver);

            gmailController.GetAddOns();

            addOnsFrame = fluentWait.Until(x => x.FindElement(By.XPath("//div[@id='glass-content']/iframe")));
            currentDriver.SwitchTo().Frame(addOnsFrame);

            addOnsFrameTitle = fluentWait.Until(x => x.FindElement(By.XPath("//span[@class='yQsxXc']")));

            Assert.IsTrue(addOnsFrameTitle.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            gmailController.CloseGmail();
        }
    }
}
