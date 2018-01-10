namespace ClientForm
{
    partial class ChatForm
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
            this.components = new System.ComponentModel.Container();
            this.mainChat = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.UsersListBox = new System.Windows.Forms.ListBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.StartGroupBtn = new System.Windows.Forms.Button();
            this.mainChat.SuspendLayout();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainChat
            // 
            this.mainChat.BackColor = System.Drawing.Color.White;
            this.mainChat.Controls.Add(this.button1);
            this.mainChat.Controls.Add(this.TextBox);
            this.mainChat.Controls.Add(this.ChatBox);
            this.mainChat.Controls.Add(this.btnSend);
            this.mainChat.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainChat.Location = new System.Drawing.Point(4, 22);
            this.mainChat.Margin = new System.Windows.Forms.Padding(0);
            this.mainChat.Name = "mainChat";
            this.mainChat.Size = new System.Drawing.Size(659, 589);
            this.mainChat.TabIndex = 0;
            this.mainChat.Text = "Chat";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, -22);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(16, 535);
            this.TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(429, 22);
            this.TextBox.TabIndex = 2;
            this.TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ChatBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChatBox.Location = new System.Drawing.Point(16, 9);
            this.ChatBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(528, 515);
            this.ChatBox.TabIndex = 1;
            this.ChatBox.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.Location = new System.Drawing.Point(460, 535);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(85, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // UsersListBox
            // 
            this.UsersListBox.FormattingEnabled = true;
            this.UsersListBox.ItemHeight = 16;
            this.UsersListBox.Location = new System.Drawing.Point(15, 18);
            this.UsersListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UsersListBox.Name = "UsersListBox";
            this.UsersListBox.Size = new System.Drawing.Size(159, 580);
            this.UsersListBox.TabIndex = 0;
            this.UsersListBox.DoubleClick += new System.EventHandler(this.StartPrivateChat);
            this.UsersListBox.MouseHover += new System.EventHandler(this.Users_MouseHover);
            // 
            // tabs
            // 
            this.tabs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabs.Controls.Add(this.mainChat);
            this.tabs.ItemSize = new System.Drawing.Size(40, 18);
            this.tabs.Location = new System.Drawing.Point(201, 18);
            this.tabs.Margin = new System.Windows.Forms.Padding(0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(667, 615);
            this.tabs.TabIndex = 5;
            // 
            // StartGroupBtn
            // 
            this.StartGroupBtn.Location = new System.Drawing.Point(16, 606);
            this.StartGroupBtn.Margin = new System.Windows.Forms.Padding(4);
            this.StartGroupBtn.Name = "StartGroupBtn";
            this.StartGroupBtn.Size = new System.Drawing.Size(159, 28);
            this.StartGroupBtn.TabIndex = 6;
            this.StartGroupBtn.Text = "Start New Group";
            this.StartGroupBtn.UseVisualStyleBackColor = true;
            this.StartGroupBtn.Click += new System.EventHandler(this.StartGroupBtn_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(880, 655);
            this.Controls.Add(this.StartGroupBtn);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.UsersListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChatForm";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
            this.mainChat.ResumeLayout(false);
            this.mainChat.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage mainChat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox UsersListBox;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button StartGroupBtn;
    }
}

