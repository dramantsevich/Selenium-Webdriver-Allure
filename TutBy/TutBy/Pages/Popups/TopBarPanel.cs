using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TutBy.Pages.Popups
{
    public class TopBarPanel : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='b-topbar-more active']")]
        [CacheLookup]
        private readonly IWebElement TopbarPanel;

        [FindsBy(How = How.XPath, Using = "//li[@class='topbar__li mores']//a[@class='topbar__link']")]
        [CacheLookup]
        private readonly IWebElement AllSectionsButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='topbarmore-c']")]
        public IWebElement TopBarMore { get; set; }

        public TopBarPanel(IWebDriver driver) : base(driver) { }

        public bool IsTopBarPanelOpen()
        {
            if (TopbarPanel.Displayed)
                return true;
            else
                return false;
        }

        public ResourcePage AllSectionsButtonClick() 
        {
            AllSectionsButton.Click();

            return new ResourcePage(this.driver);
        }
    }
}
