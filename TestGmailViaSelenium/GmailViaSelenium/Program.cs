using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace GmailViaSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            GmailSelenium gmailSelenium = new GmailSelenium();

            gmailSelenium.StartWebBrowser();
            gmailSelenium.LogInAccount();

            gmailSelenium.ButtonSearch();
            Console.ReadKey();
        }

    }
}
