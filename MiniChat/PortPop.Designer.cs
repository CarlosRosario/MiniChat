namespace MiniChat
{
    partial class PortPop
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
            this.PortPopLabel = new System.Windows.Forms.Label();
            this.portNumBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PortPopLabel
            // 
            this.PortPopLabel.AutoSize = true;
            this.PortPopLabel.Location = new System.Drawing.Point(13, 13);
            this.PortPopLabel.Name = "PortPopLabel";
            this.PortPopLabel.Size = new System.Drawing.Size(125, 13);
            this.PortPopLabel.TabIndex = 0;
            this.PortPopLabel.Text = "Please enter port number";
            // 
            // portNumBox
            // 
            this.portNumBox.Location = new System.Drawing.Point(13, 30);
            this.portNumBox.Name = "portNumBox";
            this.portNumBox.Size = new System.Drawing.Size(137, 20);
            this.portNumBox.TabIndex = 1;
            // 
            // PortPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 71);
            this.Controls.Add(this.portNumBox);
            this.Controls.Add(this.PortPopLabel);
            this.Name = "PortPop";
            this.Text = "PortPop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PortPopLabel;
        private System.Windows.Forms.TextBox portNumBox;
    }
}