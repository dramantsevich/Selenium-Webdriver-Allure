using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageFactory.Pages
{
    public class LoginMailPage : Page
    {
        [FindsBy(How = How.Name, Using = "identifier")]
        private readonly IWebElement EmailField;

        [FindsBy(How = How.Id, Using = ("identifierNext"))]
        [CacheLookup]
        private readonly IWebElement NextButton;

        public LoginMailPage(IWebDriver driver) : base(driver) { }

        public void SetMail(string mail)
        {
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Name("identifier")));

            EmailField.SendKeys(mail);
        }

        public LoginPasswordPage GoToPasswordPage()
        {
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(NextButton)).Click();

            return new LoginPasswordPage(driver);
        }
    }
}
