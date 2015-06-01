using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniChat
{
    public partial class PortPop : Form
    {
        public PortPop()
        {
            InitializeComponent();
        }

        public string Port
        {
            get { return portNumBox.Text; }
        }
    }
}
