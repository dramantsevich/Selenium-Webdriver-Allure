using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PageObjectModel
{
    public class GmailController
    {
        private readonly IWebDriver driver;

        public GmailController(IWebDriver driver)
        {
            this.driver = driver;
        }

        private Dictionary<string, string> GetDictionaryAccounts()
        {
            string path = "../../../Account.txt";

            Dictionary<string, string> accounts = Account.GetAccounts(path);

            return accounts;
        }

        public string GetFirstMail()
        {
            string firstMail;

            Dictionary<string, string> accounts = GetDictionaryAccounts();

            firstMail = accounts.Keys.ElementAt(0);

            return firstMail;
        }

        public string GetFirstPassword()
        {
            string firstPassword;

            Dictionary<string, string> accounts = GetDictionaryAccounts();

            firstPassword = accounts[accounts.Keys.ElementAt(0)];

            return firstPassword;
        }

        public void StartGmail()
        {
            string webSiteUrl = "https://gmail.com/";

            this.driver.Navigate().GoToUrl(webSiteUrl);
        }

        public void CloseGmail()
        {
            this.driver.Close();
        }

        public string GetFilePath(string fileName)
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string fileCurrentPath = $@"..\..\..\{fileName}";
            string path = Path.GetFullPath(Path.Combine(currentPath, fileCurrentPath));

            return path;
        }
    }
}
