using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace MiniChat
{
    public partial class MiniChatApp : Form
    {
        private const int BUFFERSIZE = 128; // 8 megabytes
        TcpClient sendingSocket = new TcpClient();


        public MiniChatApp()
        {
            InitializeComponent();
        }

        private void MiniChatApp_Load(object sender, EventArgs e)
        {
            //Listen();
            //sendingSocket.Connect("127.0.0.1", 1337);
        }

        private void updateStatus(string s)
        {
            statusBox.BeginInvoke(
               (MethodInvoker)delegate
               {
                   statusBox.Items.Add(s);
               });
        }

        private void updateReceive(string s)
        {
            receiveBox.BeginInvoke(
               (MethodInvoker)delegate
               {
                   receiveBox.Items.Add(s);
               });
        }

        private void Listen(int port)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Parse("127.0.0.1"), port); // ELITE PORT BRO!!! Need to make this port configurable.
            serverSocket.Start();

            // Begin Listening 
            Thread listeningThread = new Thread(() =>
            {
                // TODO: Unfortunately this will only accept a remote client once. Figure out how to allow multiple connections. 
                TcpClient clientSocket = serverSocket.AcceptTcpClient(); // Taking this outside of the thread causes the gui to hang

                updateStatus("Server Started BRO");

                while (true)
                {
                    byte[] bytesFrom = new byte[BUFFERSIZE];

                    try
                    {
                        if (clientSocket.Connected)
                        {
                            clientSocket.GetStream().Read(bytesFrom, 0, BUFFERSIZE);
                        }
                        else
                        {
                            clientSocket.Close();
                            updateStatus("Closing client connection");
                            break;
                        }
                    }
                    catch (IOException io)
                    {
                        // TODO: Log exception, recover gracefully
                    }

                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Replace("\0", "");
                    updateReceive(dataFromClient);
                }
                serverSocket.Stop();
                updateStatus("Listener has stopped");
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            NetworkStream serverStream = sendingSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(sendBox.Text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            sendBox.Clear();
        }

        private void startListeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string port; 
            //Pop up a form asking for port number to connect to
            using (PortPop popup = new PortPop())
            {
                DialogResult dialogresult = popup.ShowDialog();
                port = popup.Port;
            }
            // Call Listen()
            int portNum;
            if (Int32.TryParse(port, out portNum))
            {
                Listen(portNum);
            }
            else
            {
                updateStatus(portNum + " is not a legitimate port number");
            }
           
        }

        private void connectToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string port;
            //Pop up a form asking for port number to connect to
            using (PortPop popup = new PortPop())
            {
                DialogResult dialogresult = popup.ShowDialog();
                port = popup.Port;
            }

            int portNum;
            if (Int32.TryParse(port, out portNum))
            {
                sendingSocket.Connect("127.0.0.1", portNum);
            }
            else
            {
                updateStatus(portNum + " is not a legitimate port number");
            }
            
        }
    }
}
