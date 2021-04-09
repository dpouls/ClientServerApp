using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    class SynchronousSocketListener
    {
        TempServer tempServer;
        TcpListener tcpListener;
        const int PORT = 11000;
        const string SERVER_ADDRESS = "127.0.0.1";

        public SynchronousSocketListener()
        {
            tempServer = new TempServer();
            tempServer.LoadFiles();
        }/// <summary>
        /// //starts a listener on port 11000 so it can receive client requests and call the respond method
        /// </summary>
        public void StartListening()
        {
            IPAddress iPAddress = IPAddress.Parse(SERVER_ADDRESS);
            tcpListener = new TcpListener(iPAddress,PORT);
            tcpListener.Start();

            Respond();
        }
        /// <summary>
        /// Creates a socket that can accept many different protocols. Takes client input and sees if its a joke or conspiracy
        /// Returns random joke or conspiracy if no errors
        /// </summary>
        public void Respond()
        {
            Socket socket;
            while (true)
            {
                try
                {
                    //save the tcp connection between the client and server as a socket connection
                    //a socket connection can save various protocols, making it versatile
                    socket = tcpListener.AcceptSocket();
                    //access the data stream between the client and server
                    NetworkStream ns = new NetworkStream(socket);
                    StreamWriter writer = new StreamWriter(ns);
                    StreamReader reader = new StreamReader(ns);
                    //forces immediate write to the datastream
                    writer.AutoFlush = true;
                    string clientRequest = reader.ReadLine();

                    //check the request and respond to the request
                    if (clientRequest.ToUpper() == "JOKE")
                    {
                        string joke = tempServer.GetRandomJoke();
                        //send back to client
                        writer.WriteLine($"Joke: {joke}");
                    }
                    else if (clientRequest.ToUpper() == "CONSPIRACY")
                    {
                        string conspiracy = tempServer.GetRandomConspiracy();
                        writer.WriteLine($"Conspiracy: {conspiracy}");
                    }
                    else
                    {
                        writer.WriteLine($"Could not process request: {clientRequest}");
                    }

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
            }
        }
    }
}
