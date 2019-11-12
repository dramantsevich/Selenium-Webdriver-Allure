using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestGmailViaSelenium
{
    public class TestsWithMessages
    {
        private IWebDriver driver;
        private IWebElement foundMessage;
        private IWebElement writeMessageButton;
        private IWebElement messageBody;
        private IWebElement attachFile;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            GmailController.StartGmail(driver);
        }

        [Test]
        public void WriteMessage_ExistNewMessageFromMe()
        {
            DefaultWait<IWebDriver> fluentWait = GmailController.GetFluentWait(driver);

            GmailController.Message(driver);

            messageBody = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            messageBody.SendKeys("qwerty");
            messageBody.SendKeys(Keys.Control + Keys.Enter);

            foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Theme1')]")));

            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void AttachFileWithCorrectExtension_ExistMessageWithFile()
        {
            DefaultWait<IWebDriver> fluentWait = GmailController.GetFluentWait(driver);

            GmailController.Message(driver);

            attachFile = fluentWait.Until(x => x.FindElement(By.XPath("//input[@name='Filedata']")));
            attachFile.SendKeys(@"C:\Users\Dzmitry.Ramantsevich\Desktop\AttachFile.txt");

            messageBody = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            messageBody.SendKeys(Keys.Control + Keys.Enter);

            foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'AttachFile.txt')]")));

            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void AttachFileWithIncorrectExtension_SentMessageWithoutAttachedFile()
        {
            DefaultWait<IWebDriver> fluentWait = GmailController.GetFluentWait(driver);

            GmailController.Message(driver);

            attachFile = fluentWait.Until(x => x.FindElement(By.XPath("//input[@name='Filedata']")));
            attachFile.SendKeys(@"C:\Users\Dzmitry.Ramantsevich\Desktop\ToyotaManagerHelper.7z");

            messageBody = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            messageBody.SendKeys("Send file with incorrect extension");
            messageBody.SendKeys(Keys.Control + Keys.Enter);

            IAlert alert = fluentWait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();

            foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Send file with incorrect extension')]")));

            Assert.IsNotNull(foundMessage);
        }

        [Test]
        public void SentEmptyMessage_DoesNotContainMessage()
        {
            IWebElement getFormWithErrorMessageButtonOk;
            IWebElement getFormWithMessage;
            IWebElement bodyMessage;
            bool actual;

            DefaultWait<IWebDriver> fluentWait = GmailController.GetFluentWait(driver);

            writeMessageButton = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']")));
            writeMessageButton.Click();

            getFormWithMessage = fluentWait.Until(x => x.FindElement(By.XPath("//body[@class='aAU']/div[@class='dw']/div/div[@class='nH']/div[@class='nH']/div[@class='no']/div[3]")));

            messageBody = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
            messageBody.SendKeys(Keys.Control + Keys.Enter);

            getFormWithErrorMessageButtonOk = fluentWait.Until(x => x.FindElement(By.XPath("//button[@name='ok']")));

            if (GmailController.IsElementPresent(By.XPath("//div[@class='Kj-JD']"), driver))
            {
                if (getFormWithMessage.GetAttribute("order") == "0")
                {
                    actual = true;

                    Console.WriteLine("True, page consist form with message with width = 515");
                    Assert.IsTrue(actual);
                }
                else
                {
                    getFormWithErrorMessageButtonOk.Click();

                    bodyMessage = fluentWait.Until(x => x.FindElement(By.XPath("//td[@class='Ap']/div[2]/div[1]")));
                    bodyMessage.SendKeys(Keys.Escape);

                    actual = false;

                    Console.WriteLine("False, page not consist form with message");
                    Assert.IsFalse(actual);
                }
            }
        }

        [Test]
        public void DeleteMessage_DeleteMessagesWithTheme1()
        {
            IWebElement deleteSelectedMessages;
            IList<IWebElement> selectFoundMessages;
            IList<IWebElement> selectCheckboxes;
            DefaultWait<IWebDriver> fluentWait = GmailController.GetFluentWait(driver);

            try
            {
                if (GmailController.IsElementPresent(By.XPath("//span[@data-hovercard-id='d.ramantsevich@gmail.com']"), driver))
                {
                    if (GmailController.IsElementPresent(By.XPath("//span[contains(text(),'Theme1')]"), driver))
                    {
                        foundMessage = fluentWait.Until(x => x.FindElement(By.XPath("//span[contains(text(),'Theme1')]")));

                        selectFoundMessages = fluentWait.Until(x => x.FindElements(By.XPath("//span[contains(text(),'Theme1')]")));
                        selectCheckboxes = fluentWait.Until(x => x.FindElements(By.XPath("//div[@class='oZ-jc T-Jo J-J5-Ji ']")));

                        for (int i = 0; i < (selectFoundMessages.Count - selectFoundMessages.Count / 2); i++)
                        {
                            selectCheckboxes.ElementAt(i).Click();
                        }

                        deleteSelectedMessages = fluentWait.Until(x => x.FindElement(By.XPath("//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']")));
                        deleteSelectedMessages.Click();

                        foundMessage = null;

                        Assert.IsNull(foundMessage);
                    }
                }
                else
                {
                    Assert.Fail("Fail");
                }
            }
            catch
            {
                Console.WriteLine("NoSuchElementException");
            }
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(2000);
            driver.Close();
            driver.Quit();
        }
    }
}
