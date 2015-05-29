namespace MiniChat
{
    partial class MiniChatApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusBox = new System.Windows.Forms.ListBox();
            this.receiveBox = new System.Windows.Forms.ListBox();
            this.sendBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusBox
            // 
            this.statusBox.FormattingEnabled = true;
            this.statusBox.Location = new System.Drawing.Point(12, 12);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(260, 82);
            this.statusBox.TabIndex = 0;
            // 
            // receiveBox
            // 
            this.receiveBox.FormattingEnabled = true;
            this.receiveBox.Location = new System.Drawing.Point(12, 101);
            this.receiveBox.Name = "receiveBox";
            this.receiveBox.Size = new System.Drawing.Size(260, 82);
            this.receiveBox.TabIndex = 1;
            // 
            // sendBox
            // 
            this.sendBox.Location = new System.Drawing.Point(12, 189);
            this.sendBox.Multiline = true;
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(259, 42);
            this.sendBox.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(183, 237);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(101, 23);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "SEND BRO!!!";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // MiniChatApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendBox);
            this.Controls.Add(this.receiveBox);
            this.Controls.Add(this.statusBox);
            this.Name = "MiniChatApp";
            this.Text = "MiniChatBRO";
            this.Load += new System.EventHandler(this.MiniChatApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox statusBox;
        private System.Windows.Forms.ListBox receiveBox;
        private System.Windows.Forms.TextBox sendBox;
        private System.Windows.Forms.Button sendButton;
    }
}

