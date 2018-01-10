namespace ServerForm
{
    partial class MainTab
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
            this.MaxUsersAmount = new System.Windows.Forms.Label();
            this.currentUsersAmount = new System.Windows.Forms.Label();
            this.UsersLabel = new System.Windows.Forms.Label();
            this.MaxUsers = new System.Windows.Forms.Label();
            this.KickBtn = new System.Windows.Forms.Button();
            this.ServerChat = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.UsersInfo = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ChatBox.Location = new System.Drawing.Point(236, 14);
            this.ChatBox.Margin = new System.Windows.Forms.Padding(4);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(436, 491);
            this.ChatBox.TabIndex = 17;
            this.ChatBox.Text = "";
            // 
            // MaxUsersAmount
            // 
            this.MaxUsersAmount.AutoSize = true;
            this.MaxUsersAmount.Location = new System.Drawing.Point(92, 30);
            this.MaxUsersAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxUsersAmount.Name = "MaxUsersAmount";
            this.MaxUsersAmount.Size = new System.Drawing.Size(16, 17);
            this.MaxUsersAmount.TabIndex = 15;
            this.MaxUsersAmount.Text = "0";
            // 
            // currentUsersAmount
            // 
            this.currentUsersAmount.AutoSize = true;
            this.currentUsersAmount.Location = new System.Drawing.Point(92, 14);
            this.currentUsersAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentUsersAmount.Name = "currentUsersAmount";
            this.currentUsersAmount.Size = new System.Drawing.Size(16, 17);
            this.currentUsersAmount.TabIndex = 16;
            this.currentUsersAmount.Text = "0";
            // 
            // UsersLabel
            // 
            this.UsersLabel.AutoSize = true;
            this.UsersLabel.Location = new System.Drawing.Point(11, 14);
            this.UsersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsersLabel.Name = "UsersLabel";
            this.UsersLabel.Size = new System.Drawing.Size(49, 17);
            this.UsersLabel.TabIndex = 14;
            this.UsersLabel.Text = "Users:";
            // 
            // MaxUsers
            // 
            this.MaxUsers.AutoSize = true;
            this.MaxUsers.Location = new System.Drawing.Point(11, 29);
            this.MaxUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxUsers.Name = "MaxUsers";
            this.MaxUsers.Size = new System.Drawing.Size(82, 17);
            this.MaxUsers.TabIndex = 13;
            this.MaxUsers.Text = "Max Users: ";
            // 
            // KickBtn
            // 
            this.KickBtn.Location = new System.Drawing.Point(180, 14);
            this.KickBtn.Margin = new System.Windows.Forms.Padding(4);
            this.KickBtn.Name = "KickBtn";
            this.KickBtn.Size = new System.Drawing.Size(48, 32);
            this.KickBtn.TabIndex = 12;
            this.KickBtn.Text = "Kick";
            this.KickBtn.UseVisualStyleBackColor = true;
            // 
            // ServerChat
            // 
            this.ServerChat.Location = new System.Drawing.Point(236, 526);
            this.ServerChat.Margin = new System.Windows.Forms.Padding(4);
            this.ServerChat.Name = "ServerChat";
            this.ServerChat.Size = new System.Drawing.Size(361, 22);
            this.ServerChat.TabIndex = 11;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(607, 524);
            this.SendBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(71, 25);
            this.SendBtn.TabIndex = 10;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            // 
            // UsersInfo
            // 
            this.UsersInfo.CheckBoxes = true;
            this.UsersInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.id});
            this.UsersInfo.Location = new System.Drawing.Point(14, 49);
            this.UsersInfo.Margin = new System.Windows.Forms.Padding(4);
            this.UsersInfo.MultiSelect = false;
            this.UsersInfo.Name = "UsersInfo";
            this.UsersInfo.Size = new System.Drawing.Size(213, 500);
            this.UsersInfo.TabIndex = 9;
            this.UsersInfo.UseCompatibleStateImageBehavior = false;
            this.UsersInfo.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 94;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 61;
            // 
            // MainTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.MaxUsersAmount);
            this.Controls.Add(this.currentUsersAmount);
            this.Controls.Add(this.UsersLabel);
            this.Controls.Add(this.MaxUsers);
            this.Controls.Add(this.KickBtn);
            this.Controls.Add(this.ServerChat);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.UsersInfo);
            this.Name = "MainTab";
            this.Size = new System.Drawing.Size(684, 556);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.Label MaxUsersAmount;
        private System.Windows.Forms.Label currentUsersAmount;
        private System.Windows.Forms.Label UsersLabel;
        private System.Windows.Forms.Label MaxUsers;
        private System.Windows.Forms.Button KickBtn;
        private System.Windows.Forms.TextBox ServerChat;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.ListView UsersInfo;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader id;
    }
}
