using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

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


    }
}
