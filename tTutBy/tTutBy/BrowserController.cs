using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace tTutBy
{
    public class BrowserController
    {
        private readonly IWebDriver driver;

        public BrowserController(IWebDriver driver)
        {
            this.driver = driver;
        }

        private Dictionary<string, string> GetDictionaryAccount()
        {
            string path = GetFilePath("Account.txt");

            Dictionary<string, string> account = Account.GetAccounts(path);

            return account;
        }

        public string GetFilePath(string fileName)
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string fileCurrentPath = $@"..\..\{fileName}";
            string path = Path.GetFullPath(Path.Combine(currentPath, fileCurrentPath));

            return path;
        }

        public string GetMail()
        {
            string mail;

            Dictionary<string, string> account = GetDictionaryAccount();

            mail = account.Keys.ElementAt(0);

            return mail;
        }

        public string GetPassword()
        {
            string password;

            Dictionary<string, string> account = GetDictionaryAccount();

            password = account[account.Keys.ElementAt(0)];

            return password;
        }

        public void StartWebSite(string webSiteUrl)
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(webSiteUrl);
        }

        public void CloseCurrentWindow()
        {
            this.driver.Close();
        }
    }
}
