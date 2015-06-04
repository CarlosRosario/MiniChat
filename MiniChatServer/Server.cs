using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace MiniChatServer
{
    class Server
    {
        private const int BUFFERSIZE = 4096; // 4 Kilobytes
        private TcpListener serverSocket;
        private Thread listenerThread;

        public Server()
        {
            this.serverSocket = new TcpListener(IPAddress.Parse("127.0.0.1"), 1337); // ELITE PORT BRO!!
            this.listenerThread = new Thread(new ThreadStart(beginListening));
        }

        public void StartServer()
        {
            this.listenerThread.Start(); 
        }

        private void beginListening()
        {
            this.serverSocket.Start();
            Console.WriteLine("Server Started BRO");

            while (true)
            {
                // AcceptTcpClient() will block until a client has connected to the server
                TcpClient clientSocket = serverSocket.AcceptTcpClient(); 
                Console.WriteLine("YO SOMEBODY JUST CONNECTED TO ME BRO");

                // Use ParameterizedThreadStart so that i can close the client socket from the client thread.
                Thread clientThread = new Thread(new ParameterizedThreadStart(connectToClient));
                clientThread.Start(clientSocket);
            }
        }

        private void connectToClient(object client)
        {
            TcpClient myClient = (TcpClient)client; 

            while (true)
            {
                byte[] bytesFrom = new byte[BUFFERSIZE];

                try
                {
                    if (myClient.Connected)
                    {
                        myClient.GetStream().Read(bytesFrom, 0, BUFFERSIZE);
                    }
                    else
                    {
                        myClient.Close();
                        Console.WriteLine("CLOSING THE CLIENT BRO");
                        break;
                    }
                }
                catch (IOException io)
                {
                    // TODO: Log exception, recover gracefully
                }
                string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Replace("\0", "");
                Console.WriteLine(dataFromClient);
                
                // under construction
                NetworkStream clientStream = myClient.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes("Hello Client I am the SERVER BRO!");

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
                // under construction 
            }
            //serverSocket.Stop();
            //Console.WriteLine("Listener has stopped");
        }
    }
}
