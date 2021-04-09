using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    class Program
    {
        /// <summary>
        /// creates a server and opens the client side program too. Starts listening on the server.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TempServer tempServer = new TempServer();
            tempServer.LoadFiles();

            Console.WriteLine("Welcome to Dallin's Joke/Conspiracy Server");
            Console.WriteLine("------------------------------------------");
            /* while (true)
             {
                 Console.WriteLine("Type q to quit");
                 string userInput = Console.ReadLine();
                 if (userInput == "q")
                 {
                     break;
                 }
                 Console.WriteLine($"Joke: {tempServer.GetRandomJoke()}");
                 Console.WriteLine($"Conspiracy: {tempServer.GetRandomConspiracy()}");

             } */
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Users\dalli\source\repos\ClientServerApp\ClientApp\bin\Debug\ClientApp.exe";
            process.Start();
            SynchronousSocketListener ssl = new SynchronousSocketListener();
            ssl.StartListening();
        }
    }
}
