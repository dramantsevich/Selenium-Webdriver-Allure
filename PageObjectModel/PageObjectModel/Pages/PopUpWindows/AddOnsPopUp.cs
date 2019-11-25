using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.Pages.PopUpWindows
{
    public class AddOnsPopUp
    {
        private readonly IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        readonly By title = By.XPath("//span[@class='yQsxXc']");
        readonly By addOnsFrame = By.XPath("//div[@id='glass-content']/iframe");

        public IWebElement GetAddOnsTitle()
        {
            fluentWait = FluentWait.GetFluentWait(this.driver);
            IWebElement title = fluentWait.Until(x => x.FindElement(this.title));

            return title;
        }

        public AddOnsPopUp(IWebDriver driver)
        {
            this.driver = driver;
            SwitchToAddOnsFrame();
        }

        public void SwitchToAddOnsFrame()
        {
            IWebElement addOnsFrame;
            fluentWait = FluentWait.GetFluentWait(this.driver);

            addOnsFrame = fluentWait.Until(x => x.FindElement(this.addOnsFrame));

            this.driver.SwitchTo().Frame(addOnsFrame);
        }
    }
}
