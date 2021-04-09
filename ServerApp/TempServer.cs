using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    public class TempServer
    {
        Random rand = new Random();
        string[] jokes;
        string[] conspiracies;
        const string JOKE_FILE = "jokes.txt";
        const string CONSP_FILE = "conspiracies.txt";
        public TempServer()
        {
            
        }
        /// <summary>
        /// loads the joke and conspiracy files from the bin folder
        /// </summary>
        public void LoadFiles()
        {
            try
            {
                jokes = File.ReadAllLines(JOKE_FILE);
                conspiracies = File.ReadAllLines(CONSP_FILE);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// uses the random class to get a random joke
        /// </summary>
        /// <returns></returns>
        public string GetRandomJoke()
        {
            return jokes[rand.Next(jokes.Length)];
        }
        /// <summary>
        /// uses the random class to get a random conspiracy
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetRandomConspiracy()
        {
            return conspiracies[rand.Next(conspiracies.Length)];
        }
    }
}
