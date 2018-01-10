namespace ClientForm
{
    partial class GroupChatForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.UsersList = new System.Windows.Forms.ListBox();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.InviteBtn = new System.Windows.Forms.Button();
            this.KickBtn = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ChatBox.Location = new System.Drawing.Point(109, 3);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(341, 423);
            this.ChatBox.TabIndex = 0;
            this.ChatBox.Text = "";
            // 
            // UsersList
            // 
            this.UsersList.FormattingEnabled = true;
            this.UsersList.Location = new System.Drawing.Point(3, 29);
            this.UsersList.Name = "UsersList";
            this.UsersList.Size = new System.Drawing.Size(87, 368);
            this.UsersList.TabIndex = 1;
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(3, 3);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(87, 23);
            this.QuitBtn.TabIndex = 2;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // InviteBtn
            // 
            this.InviteBtn.Location = new System.Drawing.Point(3, 403);
            this.InviteBtn.Name = "InviteBtn";
            this.InviteBtn.Size = new System.Drawing.Size(87, 23);
            this.InviteBtn.TabIndex = 3;
            this.InviteBtn.Text = "Invite";
            this.InviteBtn.UseVisualStyleBackColor = true;
            this.InviteBtn.Click += new System.EventHandler(this.InviteBtn_Click);
            // 
            // KickBtn
            // 
            this.KickBtn.Location = new System.Drawing.Point(3, 432);
            this.KickBtn.Name = "KickBtn";
            this.KickBtn.Size = new System.Drawing.Size(87, 23);
            this.KickBtn.TabIndex = 3;
            this.KickBtn.Text = "Kick";
            this.KickBtn.UseVisualStyleBackColor = true;
            this.KickBtn.Click += new System.EventHandler(this.KickBtn_Click);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(109, 435);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(292, 20);
            this.TextBox.TabIndex = 4;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(407, 432);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(43, 23);
            this.SendBtn.TabIndex = 5;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // GroupChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.KickBtn);
            this.Controls.Add(this.InviteBtn);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.UsersList);
            this.Controls.Add(this.ChatBox);
            this.Name = "GroupChat";
            this.Size = new System.Drawing.Size(470, 470);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.ListBox UsersList;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.Button InviteBtn;
        private System.Windows.Forms.Button KickBtn;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Button SendBtn;
    }
}
