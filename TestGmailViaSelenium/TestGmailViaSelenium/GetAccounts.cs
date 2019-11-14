using System;
using System.Collections.Generic;
using System.IO;

namespace TestGmailViaSelenium
{
    static class GetAccounts
    {
        static public void GetAccount(List<string> emails, List<string> passwords)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            try
            {
                using (StreamReader sr = new StreamReader($@"{path}\Account.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(new char[] { ' ' });

                        string email = words[1];
                        string password = words[3];

                        emails.Add(email);
                        passwords.Add(password);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
