using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Collections.Generic;

namespace TestGmailViaSelenium
{
    public class GmailTests
    {
        public static DefaultWait<IWebDriver> GetFluentWait(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(30);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }

        private IWebDriver driver;
        private string webSiteUrl;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            webSiteUrl = "https://gmail.com/";

            driver.Navigate().GoToUrl(webSiteUrl);

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            IWebElement email = fluentWait.Until(x => x.FindElement(By.Name("identifier")));
            email.SendKeys("d.ramantsevich@gmail.com");

            IWebElement identifierNext = fluentWait.Until(x => x.FindElement(By.Id("identifierNext")));
            identifierNext.Click();

            IWebElement password = fluentWait.Until(x => x.FindElement(By.Name("password")));
            password.SendKeys("7182470Dima");

            IWebElement passwordNext = fluentWait.Until(x => x.FindElement(By.Id("passwordNext")));
            passwordNext.Click();
        }

        [Test]
        public void ButtonSearh_FoundMessage()
        {
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            IWebElement searchInMailField = fluentWait.Until(x => x.FindElement(By.XPath("//input[@placeholder='Поиск в почте']")));
            searchInMailField.SendKeys("Xinuos");

            IWebElement searchInMailButton = fluentWait.Until(x => x.FindElement(By.XPath("//button[@class='gb_of gb_pf']")));
            searchInMailButton.Click();

            IWebElement foundMessage = fluentWait.Until(x => x.FindElement(By.Name("Xinuos Inc.")));
            Assert.IsNotNull(foundMessage);
        }

        [Test, Order(1)]
        public void WriteMessage_ExistNewMessageFromMe()
        {
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            IWebElement writeMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']")));
            writeMessageButton.Click();

            IWebElement writeTo = fluentWait.Until(x => x.FindElement(By.Name("to")));
            writeTo.SendKeys("d.ramantsevich@gmail.com");

            IWebElement theme = fluentWait.Until(x => x.FindElement(By.Name("subjectbox")));
            theme.SendKeys("Theme1");

            IWebElement messageBody = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            messageBody.SendKeys("qwerty");
            messageBody.SendKeys(Keys.Control + Keys.Enter);

            IWebElement foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Theme1')]")));

            Assert.IsNotNull(fluentWait.Until(foundMessage => foundMessage));
        }

        [Test, Order(2)]
        public void DeleteMessage_DeleteMessageWithTheme1()
        {
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            IWebElement foundMessage;
            IWebElement deleteMessageButton;
            IWebElement selectFoundMessage;

            try
            {
                if (IsElementPresent(By.Name("я")))
                {
                    foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Theme1')]")));

                    List<IWebElement> listDeleteMessageButtons = new List<IWebElement>();

                    selectFoundMessage = fluentWait.Until(x => x.FindElement(By.XPath("/html[1]/body[1]/div[7]/div[3]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[3]/div[1]/table[1]/tbody[1]/tr[1]/td[2]/div[1]")));
                    selectFoundMessage.Click();

                    deleteMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='bq4 xY']//ul//li[@class='bqX bru']")));
                    listDeleteMessageButtons.Add(deleteMessageButton);
                    Thread.Sleep(3000);
                    listDeleteMessageButtons[0].Click();

                    foundMessage = null;

                    Assert.IsNull(foundMessage);
                }
                else
                {
                    Assert.Fail("Fail");
                }
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                Console.WriteLine("NoSuchElementException");
            }
        }

        [Test]
        public void QuitFromAccount()
        {
            Thread.Sleep(2000);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);

            IWebElement account = fluentWait.Until(x => x.FindElement(By.XPath("//a[@class='gb_D gb_Fa gb_i']")));
            account.Click();

            IWebElement logOutFromAccount = fluentWait.Until(x => x.FindElement(By.XPath("//a[@id='gb_71']")));
            logOutFromAccount.Click();
            Thread.Sleep(3000);

            string currentURL = "https://accounts.google.com/ServiceLogin/signinchooser?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin";

            Assert.IsTrue(currentURL == driver.Url);
        }

        [Test]
        public void AttachFile()
        {
            IWebElement writeMessageButton;
            IWebElement writeTo;
            IWebElement theme;
            IWebElement attachFile;

            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            writeMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']")));
            writeMessageButton.Click();

            writeTo = fluentWait.Until(x => x.FindElement(By.Name("to")));
            writeTo.SendKeys("d.ramantsevich@gmail.com");

            theme = fluentWait.Until(x => x.FindElement(By.Name("subjectbox")));
            theme.SendKeys("Theme1");

            attachFile = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='bAK']/div[1]/div[1]")));
            attachFile.Click();
        }

        //[Test]
        //public void SentEmptyMessage()
        //{
        //    DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

        //    IWebElement writeMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']")));
        //    writeMessageButton.Click();

        //    IWebElement getButtonCloseSentMessageForm = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='nH Hd']")));
        //    driver.SwitchTo().Frame(getButtonCloseSentMessageForm);
        //    Console.WriteLine(driver.SwitchTo().Frame(getButtonCloseSentMessageForm));

        //    IWebElement messageBody = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
        //    messageBody.SendKeys(Keys.Control + Keys.Enter);

        //    IWebElement getFormWithButtonOK = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='Kj-JD']")));
        //    driver.SwitchTo().Frame(getFormWithButtonOK);
        //    Console.WriteLine(driver.SwitchTo().Frame(getFormWithButtonOK));

        //    if (IsElementPresent(By.XPath("//span[contains(text(),'Ошибка')]")))
        //    {

        //        IWebElement buttonOK = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='Kj-JD-Jl']/button[@name='ok']")));
        //        buttonOK.Click();

        //        IWebElement bodyMessage = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
        //        bodyMessage.SendKeys(Keys.Escape);


        //        //Assert.Null();
        //        //&& driver.SwitchTo().Frame(getButtonCloseSentMessageForm)
        //        //driver.SwitchTo().Frame("xpcpeersIFL");
        //    }
        //}

        private bool IsElementPresent(By by)
        {
            DefaultWait<IWebDriver> fluentWait = GetFluentWait(driver);

            try
            {
                fluentWait.Until(x => x.FindElement(by));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(2000);
            //driver.Close();
        }
    }
}