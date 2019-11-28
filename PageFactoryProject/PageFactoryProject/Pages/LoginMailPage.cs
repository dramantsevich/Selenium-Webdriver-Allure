using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageFactoryProject.Pages
{
    public class LoginMailPage : Page
    {
        [FindsBy(How = How.Name, Using = "identifier")]
        private readonly IWebElement EmailField;

        [FindsBy(How = How.Id, Using = ("identifierNext"))]
        private readonly IWebElement NextButton;

        public LoginMailPage(IWebDriver driver) : base(driver) { }

        public void SetMail(string mail)
        {
            EmailField.SendKeys(mail);
        }

        public LoginPasswordPage GoToPasswordPage()
        {
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(NextButton));
            NextButton.Click();

            return new LoginPasswordPage(driver);
        }
    }
}
