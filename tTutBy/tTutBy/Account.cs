using System;
using System.Collections.Generic;
using System.IO;

namespace tTutBy
{
    public static class Account
    {
        static public Dictionary<string, string> GetAccounts(string path)
        {
            Dictionary<string, string> accounts = new Dictionary<string, string>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(new char[] { ' ' });

                        accounts.Add(words[1], words[3]);
                    }
                }
                return accounts;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
