using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniChatServer
{
    class Entry
    {
        public static void Main()
        {
            Server MiniChatServer = new Server();
            MiniChatServer.StartServer(); 
        }
    }
}
