namespace ServerForm
{
    partial class ServerForm
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
            this.Tabs = new System.Windows.Forms.TabControl();
            this.currentUserTab = new System.Windows.Forms.TabPage();
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
            this.Users = new System.Windows.Forms.TabPage();
            this.GetUsersBtn = new System.Windows.Forms.Button();
            this.GetUsersBy = new System.Windows.Forms.Label();
            this.UserDate = new System.Windows.Forms.DateTimePicker();
            this.GetUsersByComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.GroupBtn = new System.Windows.Forms.Button();
            this.PrivateBtn = new System.Windows.Forms.Button();
            this.UserText = new System.Windows.Forms.TextBox();
            this.DataBaseUsers = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GetMessagesBtn = new System.Windows.Forms.Button();
            this.GetByDatePart = new System.Windows.Forms.CheckBox();
            this.GetMessageCheckBox = new System.Windows.Forms.CheckBox();
            this.MessageByText = new System.Windows.Forms.TextBox();
            this.MessageByDate = new System.Windows.Forms.DateTimePicker();
            this.DataBaseMessages = new System.Windows.Forms.DataGridView();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.Tabs.SuspendLayout();
            this.currentUserTab.SuspendLayout();
            this.Users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseUsers)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.currentUserTab);
            this.Tabs.Controls.Add(this.Users);
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Margin = new System.Windows.Forms.Padding(4);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(697, 591);
            this.Tabs.TabIndex = 0;
            // 
            // currentUserTab
            // 
            this.currentUserTab.Controls.Add(this.ChatBox);
            this.currentUserTab.Controls.Add(this.MaxUsersAmount);
            this.currentUserTab.Controls.Add(this.currentUsersAmount);
            this.currentUserTab.Controls.Add(this.UsersLabel);
            this.currentUserTab.Controls.Add(this.MaxUsers);
            this.currentUserTab.Controls.Add(this.KickBtn);
            this.currentUserTab.Controls.Add(this.ServerChat);
            this.currentUserTab.Controls.Add(this.SendBtn);
            this.currentUserTab.Controls.Add(this.UsersInfo);
            this.currentUserTab.Location = new System.Drawing.Point(4, 25);
            this.currentUserTab.Margin = new System.Windows.Forms.Padding(4);
            this.currentUserTab.Name = "currentUserTab";
            this.currentUserTab.Padding = new System.Windows.Forms.Padding(4);
            this.currentUserTab.Size = new System.Drawing.Size(689, 562);
            this.currentUserTab.TabIndex = 0;
            this.currentUserTab.Text = "Current Users";
            this.currentUserTab.UseVisualStyleBackColor = true;
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ChatBox.Location = new System.Drawing.Point(237, 4);
            this.ChatBox.Margin = new System.Windows.Forms.Padding(4);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(436, 491);
            this.ChatBox.TabIndex = 8;
            this.ChatBox.Text = "";
            // 
            // MaxUsersAmount
            // 
            this.MaxUsersAmount.AutoSize = true;
            this.MaxUsersAmount.Location = new System.Drawing.Point(93, 20);
            this.MaxUsersAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxUsersAmount.Name = "MaxUsersAmount";
            this.MaxUsersAmount.Size = new System.Drawing.Size(16, 17);
            this.MaxUsersAmount.TabIndex = 7;
            this.MaxUsersAmount.Text = "0";
            // 
            // currentUsersAmount
            // 
            this.currentUsersAmount.AutoSize = true;
            this.currentUsersAmount.Location = new System.Drawing.Point(93, 4);
            this.currentUsersAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentUsersAmount.Name = "currentUsersAmount";
            this.currentUsersAmount.Size = new System.Drawing.Size(16, 17);
            this.currentUsersAmount.TabIndex = 7;
            this.currentUsersAmount.Text = "0";
            // 
            // UsersLabel
            // 
            this.UsersLabel.AutoSize = true;
            this.UsersLabel.Location = new System.Drawing.Point(11, 4);
            this.UsersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsersLabel.Name = "UsersLabel";
            this.UsersLabel.Size = new System.Drawing.Size(49, 17);
            this.UsersLabel.TabIndex = 6;
            this.UsersLabel.Text = "Users:";
            // 
            // MaxUsers
            // 
            this.MaxUsers.AutoSize = true;
            this.MaxUsers.Location = new System.Drawing.Point(11, 20);
            this.MaxUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxUsers.Name = "MaxUsers";
            this.MaxUsers.Size = new System.Drawing.Size(82, 17);
            this.MaxUsers.TabIndex = 5;
            this.MaxUsers.Text = "Max Users: ";
            // 
            // KickBtn
            // 
            this.KickBtn.Location = new System.Drawing.Point(181, 4);
            this.KickBtn.Margin = new System.Windows.Forms.Padding(4);
            this.KickBtn.Name = "KickBtn";
            this.KickBtn.Size = new System.Drawing.Size(48, 32);
            this.KickBtn.TabIndex = 4;
            this.KickBtn.Text = "Kick";
            this.KickBtn.UseVisualStyleBackColor = true;
            this.KickBtn.Click += new System.EventHandler(this.KickBtn_Click);
            // 
            // ServerChat
            // 
            this.ServerChat.Location = new System.Drawing.Point(237, 516);
            this.ServerChat.Margin = new System.Windows.Forms.Padding(4);
            this.ServerChat.Name = "ServerChat";
            this.ServerChat.Size = new System.Drawing.Size(361, 22);
            this.ServerChat.TabIndex = 3;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(608, 514);
            this.SendBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(71, 25);
            this.SendBtn.TabIndex = 2;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // UsersInfo
            // 
            this.UsersInfo.CheckBoxes = true;
            this.UsersInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.id});
            this.UsersInfo.Location = new System.Drawing.Point(15, 39);
            this.UsersInfo.Margin = new System.Windows.Forms.Padding(4);
            this.UsersInfo.MultiSelect = false;
            this.UsersInfo.Name = "UsersInfo";
            this.UsersInfo.Size = new System.Drawing.Size(213, 500);
            this.UsersInfo.TabIndex = 1;
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
            // Users
            // 
            this.Users.Controls.Add(this.GetUsersBtn);
            this.Users.Controls.Add(this.GetUsersBy);
            this.Users.Controls.Add(this.UserDate);
            this.Users.Controls.Add(this.GetUsersByComboBox);
            this.Users.Controls.Add(this.DeleteBtn);
            this.Users.Controls.Add(this.GroupBtn);
            this.Users.Controls.Add(this.PrivateBtn);
            this.Users.Controls.Add(this.UserText);
            this.Users.Controls.Add(this.DataBaseUsers);
            this.Users.Location = new System.Drawing.Point(4, 25);
            this.Users.Margin = new System.Windows.Forms.Padding(4);
            this.Users.Name = "Users";
            this.Users.Padding = new System.Windows.Forms.Padding(4);
            this.Users.Size = new System.Drawing.Size(689, 562);
            this.Users.TabIndex = 1;
            this.Users.Text = "Users";
            this.Users.UseVisualStyleBackColor = true;
            this.Users.Enter += new System.EventHandler(this.Users_Enter);
            // 
            // GetUsersBtn
            // 
            this.GetUsersBtn.Location = new System.Drawing.Point(17, 433);
            this.GetUsersBtn.Margin = new System.Windows.Forms.Padding(4);
            this.GetUsersBtn.Name = "GetUsersBtn";
            this.GetUsersBtn.Size = new System.Drawing.Size(109, 37);
            this.GetUsersBtn.TabIndex = 10;
            this.GetUsersBtn.Text = "Get Users";
            this.GetUsersBtn.UseVisualStyleBackColor = true;
            this.GetUsersBtn.Click += new System.EventHandler(this.GetUsersBtn_Click);
            // 
            // GetUsersBy
            // 
            this.GetUsersBy.AutoSize = true;
            this.GetUsersBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.GetUsersBy.Location = new System.Drawing.Point(12, 402);
            this.GetUsersBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GetUsersBy.Name = "GetUsersBy";
            this.GetUsersBy.Size = new System.Drawing.Size(127, 25);
            this.GetUsersBy.TabIndex = 9;
            this.GetUsersBy.Text = "Get Users By";
            // 
            // UserDate
            // 
            this.UserDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.UserDate.CustomFormat = "dd/MM/yyyy";
            this.UserDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.UserDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.UserDate.Location = new System.Drawing.Point(136, 434);
            this.UserDate.Margin = new System.Windows.Forms.Padding(4);
            this.UserDate.Name = "UserDate";
            this.UserDate.ShowUpDown = true;
            this.UserDate.Size = new System.Drawing.Size(160, 34);
            this.UserDate.TabIndex = 8;
            this.UserDate.Value = new System.DateTime(2017, 6, 1, 17, 27, 54, 0);
            // 
            // GetUsersByComboBox
            // 
            this.GetUsersByComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GetUsersByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GetUsersByComboBox.FormattingEnabled = true;
            this.GetUsersByComboBox.Items.AddRange(new object[] {
            "All",
            "Only Connected",
            "Email",
            "Nick Name",
            "Last Connected Date"});
            this.GetUsersByComboBox.Location = new System.Drawing.Point(159, 402);
            this.GetUsersByComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.GetUsersByComboBox.Name = "GetUsersByComboBox";
            this.GetUsersByComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GetUsersByComboBox.Size = new System.Drawing.Size(137, 24);
            this.GetUsersByComboBox.TabIndex = 7;
            this.GetUsersByComboBox.SelectedIndexChanged += new System.EventHandler(this.GetUsersByComboBox_SelectedIndexChanged);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(537, 402);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(145, 28);
            this.DeleteBtn.TabIndex = 4;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // GroupBtn
            // 
            this.GroupBtn.Location = new System.Drawing.Point(537, 474);
            this.GroupBtn.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBtn.Name = "GroupBtn";
            this.GroupBtn.Size = new System.Drawing.Size(145, 28);
            this.GroupBtn.TabIndex = 4;
            this.GroupBtn.Text = "Get Group Chat";
            this.GroupBtn.UseVisualStyleBackColor = true;
            this.GroupBtn.Click += new System.EventHandler(this.GroupBtn_Click);
            // 
            // PrivateBtn
            // 
            this.PrivateBtn.Location = new System.Drawing.Point(537, 438);
            this.PrivateBtn.Margin = new System.Windows.Forms.Padding(4);
            this.PrivateBtn.Name = "PrivateBtn";
            this.PrivateBtn.Size = new System.Drawing.Size(145, 28);
            this.PrivateBtn.TabIndex = 4;
            this.PrivateBtn.Text = "Get Private Chat";
            this.PrivateBtn.UseVisualStyleBackColor = true;
            this.PrivateBtn.Click += new System.EventHandler(this.PrivateBtn_Click);
            // 
            // UserText
            // 
            this.UserText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserText.Location = new System.Drawing.Point(136, 434);
            this.UserText.Margin = new System.Windows.Forms.Padding(4);
            this.UserText.Name = "UserText";
            this.UserText.Size = new System.Drawing.Size(160, 34);
            this.UserText.TabIndex = 1;
            // 
            // DataBaseUsers
            // 
            this.DataBaseUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataBaseUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBaseUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataBaseUsers.Location = new System.Drawing.Point(4, 4);
            this.DataBaseUsers.Margin = new System.Windows.Forms.Padding(4);
            this.DataBaseUsers.Name = "DataBaseUsers";
            this.DataBaseUsers.ReadOnly = true;
            this.DataBaseUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataBaseUsers.Size = new System.Drawing.Size(681, 391);
            this.DataBaseUsers.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GetMessagesBtn);
            this.tabPage1.Controls.Add(this.GetByDatePart);
            this.tabPage1.Controls.Add(this.GetMessageCheckBox);
            this.tabPage1.Controls.Add(this.MessageByText);
            this.tabPage1.Controls.Add(this.MessageByDate);
            this.tabPage1.Controls.Add(this.DataBaseMessages);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(689, 562);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Messages";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GetMessagesBtn
            // 
            this.GetMessagesBtn.Location = new System.Drawing.Point(239, 343);
            this.GetMessagesBtn.Margin = new System.Windows.Forms.Padding(4);
            this.GetMessagesBtn.Name = "GetMessagesBtn";
            this.GetMessagesBtn.Size = new System.Drawing.Size(113, 37);
            this.GetMessagesBtn.TabIndex = 7;
            this.GetMessagesBtn.Text = "Get Messages";
            this.GetMessagesBtn.UseVisualStyleBackColor = true;
            this.GetMessagesBtn.Click += new System.EventHandler(this.GetMessagesBtn_Click);
            // 
            // GetByDatePart
            // 
            this.GetByDatePart.AutoSize = true;
            this.GetByDatePart.Checked = true;
            this.GetByDatePart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GetByDatePart.Location = new System.Drawing.Point(12, 388);
            this.GetByDatePart.Margin = new System.Windows.Forms.Padding(4);
            this.GetByDatePart.Name = "GetByDatePart";
            this.GetByDatePart.Size = new System.Drawing.Size(136, 21);
            this.GetByDatePart.TabIndex = 6;
            this.GetByDatePart.Text = "Compare By Day";
            this.GetByDatePart.UseVisualStyleBackColor = true;
            this.GetByDatePart.Visible = false;
            // 
            // GetMessageCheckBox
            // 
            this.GetMessageCheckBox.AutoSize = true;
            this.GetMessageCheckBox.Checked = true;
            this.GetMessageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GetMessageCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.GetMessageCheckBox.Location = new System.Drawing.Point(11, 306);
            this.GetMessageCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.GetMessageCheckBox.Name = "GetMessageCheckBox";
            this.GetMessageCheckBox.Size = new System.Drawing.Size(276, 33);
            this.GetMessageCheckBox.TabIndex = 5;
            this.GetMessageCheckBox.Text = "Get Messages By Text";
            this.GetMessageCheckBox.UseVisualStyleBackColor = true;
            this.GetMessageCheckBox.CheckedChanged += new System.EventHandler(this.GetMessageCheckBox_CheckedChanged);
            // 
            // MessageByText
            // 
            this.MessageByText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MessageByText.Location = new System.Drawing.Point(11, 343);
            this.MessageByText.Margin = new System.Windows.Forms.Padding(4);
            this.MessageByText.Name = "MessageByText";
            this.MessageByText.Size = new System.Drawing.Size(219, 34);
            this.MessageByText.TabIndex = 4;
            // 
            // MessageByDate
            // 
            this.MessageByDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.MessageByDate.CustomFormat = "dd/MM/yy HH:mm";
            this.MessageByDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.MessageByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MessageByDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MessageByDate.Location = new System.Drawing.Point(11, 343);
            this.MessageByDate.Margin = new System.Windows.Forms.Padding(4);
            this.MessageByDate.Name = "MessageByDate";
            this.MessageByDate.ShowUpDown = true;
            this.MessageByDate.Size = new System.Drawing.Size(219, 34);
            this.MessageByDate.TabIndex = 3;
            this.MessageByDate.Value = new System.DateTime(2017, 6, 2, 20, 18, 29, 243);
            this.MessageByDate.Visible = false;
            // 
            // DataBaseMessages
            // 
            this.DataBaseMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataBaseMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBaseMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataBaseMessages.Location = new System.Drawing.Point(4, 4);
            this.DataBaseMessages.Margin = new System.Windows.Forms.Padding(4);
            this.DataBaseMessages.Name = "DataBaseMessages";
            this.DataBaseMessages.Size = new System.Drawing.Size(681, 295);
            this.DataBaseMessages.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 594);
            this.Controls.Add(this.Tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Tabs.ResumeLayout(false);
            this.currentUserTab.ResumeLayout(false);
            this.currentUserTab.PerformLayout();
            this.Users.ResumeLayout(false);
            this.Users.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseUsers)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Users;
        private System.Windows.Forms.TabPage currentUserTab;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ListView UsersInfo;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.TextBox ServerChat;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button KickBtn;
        private System.Windows.Forms.Label MaxUsers;
        private System.Windows.Forms.Label currentUsersAmount;
        private System.Windows.Forms.Label UsersLabel;
        private System.Windows.Forms.DataGridView DataBaseUsers;
        private System.Windows.Forms.TextBox UserText;
        private System.Windows.Forms.Label MaxUsersAmount;
        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.Button PrivateBtn;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DataBaseMessages;
        private System.Windows.Forms.DateTimePicker MessageByDate;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button GroupBtn;
        private System.Windows.Forms.CheckBox GetMessageCheckBox;
        private System.Windows.Forms.TextBox MessageByText;
        private System.Windows.Forms.CheckBox GetByDatePart;
        private System.Windows.Forms.Button GetMessagesBtn;
        private System.Windows.Forms.ComboBox GetUsersByComboBox;
        private System.Windows.Forms.DateTimePicker UserDate;
        private System.Windows.Forms.Label GetUsersBy;
        private System.Windows.Forms.Button GetUsersBtn;
    }
}

