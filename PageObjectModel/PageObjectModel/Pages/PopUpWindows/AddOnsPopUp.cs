using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.Pages.PopUpWindows
{
    public class AddOnsPopUp : Page
    {
        readonly By titleLocator = By.XPath("//span[@class='yQsxXc']");
        readonly By addOnsFrameLocator = By.XPath("//div[@id='glass-content']/iframe");

        public AddOnsPopUp(IWebDriver driver) : base(driver)
        {
            SwitchToAddOnsFrame();
        }

        public IWebElement GetAddOnsTitle()
        {
            IWebElement title = webDriverWait.Until(x => x.FindElement(this.titleLocator));
            return title;
        }

        public void SwitchToAddOnsFrame()
        {
            IWebElement addOnsFrame = webDriverWait.Until(x => x.FindElement(this.addOnsFrameLocator));
            this.driver.SwitchTo().Frame(addOnsFrame);
        }
    }
}
