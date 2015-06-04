using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace MiniChatTestClient
{
    public partial class Client : Form
    {
        TcpClient clientSocket = new TcpClient();

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            msg("Client Started");
            clientSocket.Connect("127.0.0.1", 1337);

            Thread t = new Thread(new ThreadStart(waitForResponse));
            t.Start();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(sendBox.Text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            sendBox.Clear();
        }

        private void msg(string message)
        {
            responseBox.Text = responseBox.Text + Environment.NewLine + " >> " + message;
        }

        private void waitForResponse()
        {
            while (true)
            {
                byte[] b = new byte[1024];
                clientSocket.GetStream().Read(b, 0, 1024);
                string dataFromClient = System.Text.Encoding.ASCII.GetString(b);
                dataFromClient = dataFromClient.Replace("\0", "");


                this.responseBox.Invoke((Action)(() =>
                {
                    msg(dataFromClient);
                }));
            }
        }
    }
}
