namespace ServerForm
{
    partial class Menu
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
            this.btnStart = new System.Windows.Forms.Button();
            this.UserAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SSLCheckBox = new System.Windows.Forms.CheckBox();
            this.MailGroup = new System.Windows.Forms.GroupBox();
            this.MailPort = new System.Windows.Forms.NumericUpDown();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.SmtpTextBox = new System.Windows.Forms.TextBox();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.MailCheckBox = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ipTextBox1 = new WinFormsExtensions.IPTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UserAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port)).BeginInit();
            this.MailGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MailPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnStart.Location = new System.Drawing.Point(228, 67);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 26);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // UserAmount
            // 
            this.UserAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserAmount.Location = new System.Drawing.Point(228, 36);
            this.UserAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.UserAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UserAmount.Name = "UserAmount";
            this.UserAmount.Size = new System.Drawing.Size(75, 26);
            this.UserAmount.TabIndex = 2;
            this.UserAmount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(224, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Max Users";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Port
            // 
            this.Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Port.Location = new System.Drawing.Point(66, 50);
            this.Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Port.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(131, 26);
            this.Port.TabIndex = 7;
            this.Port.Value = new decimal(new int[] {
            9001,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(5, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "SMTP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(5, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(5, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "User Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(5, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "Password:";
            // 
            // SSLCheckBox
            // 
            this.SSLCheckBox.AutoSize = true;
            this.SSLCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SSLCheckBox.Checked = true;
            this.SSLCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SSLCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SSLCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SSLCheckBox.Location = new System.Drawing.Point(5, 101);
            this.SSLCheckBox.Name = "SSLCheckBox";
            this.SSLCheckBox.Size = new System.Drawing.Size(63, 28);
            this.SSLCheckBox.TabIndex = 9;
            this.SSLCheckBox.Text = "SSL";
            this.SSLCheckBox.UseVisualStyleBackColor = true;
            // 
            // MailGroup
            // 
            this.MailGroup.Controls.Add(this.MailPort);
            this.MailGroup.Controls.Add(this.PasswordTextBox);
            this.MailGroup.Controls.Add(this.SmtpTextBox);
            this.MailGroup.Controls.Add(this.UserNameTextBox);
            this.MailGroup.Controls.Add(this.label4);
            this.MailGroup.Controls.Add(this.SSLCheckBox);
            this.MailGroup.Controls.Add(this.label5);
            this.MailGroup.Controls.Add(this.label7);
            this.MailGroup.Controls.Add(this.label6);
            this.MailGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MailGroup.Location = new System.Drawing.Point(12, 109);
            this.MailGroup.Name = "MailGroup";
            this.MailGroup.Size = new System.Drawing.Size(321, 218);
            this.MailGroup.TabIndex = 10;
            this.MailGroup.TabStop = false;
            this.MailGroup.Text = "Email Info";
            // 
            // MailPort
            // 
            this.MailPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MailPort.Location = new System.Drawing.Point(122, 68);
            this.MailPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.MailPort.Name = "MailPort";
            this.MailPort.Size = new System.Drawing.Size(131, 29);
            this.MailPort.TabIndex = 14;
            this.MailPort.Value = new decimal(new int[] {
            587,
            0,
            0,
            0});
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PasswordTextBox.Location = new System.Drawing.Point(121, 171);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(179, 29);
            this.PasswordTextBox.TabIndex = 13;
            // 
            // SmtpTextBox
            // 
            this.SmtpTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SmtpTextBox.Location = new System.Drawing.Point(122, 35);
            this.SmtpTextBox.Name = "SmtpTextBox";
            this.SmtpTextBox.Size = new System.Drawing.Size(179, 29);
            this.SmtpTextBox.TabIndex = 12;
            this.SmtpTextBox.Text = "smtp.gmail.com";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserNameTextBox.Location = new System.Drawing.Point(121, 138);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(179, 29);
            this.UserNameTextBox.TabIndex = 11;
            // 
            // MailCheckBox
            // 
            this.MailCheckBox.AutoSize = true;
            this.MailCheckBox.Checked = true;
            this.MailCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MailCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MailCheckBox.Location = new System.Drawing.Point(12, 81);
            this.MailCheckBox.Name = "MailCheckBox";
            this.MailCheckBox.Size = new System.Drawing.Size(130, 22);
            this.MailCheckBox.TabIndex = 11;
            this.MailCheckBox.Text = "Mail Verification";
            this.MailCheckBox.UseVisualStyleBackColor = true;
            this.MailCheckBox.CheckedChanged += new System.EventHandler(this.MailCheckBox_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ipTextBox1
            // 
            this.ipTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ipTextBox1.Location = new System.Drawing.Point(66, 15);
            this.ipTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.ipTextBox1.Name = "ipTextBox1";
            this.ipTextBox1.Size = new System.Drawing.Size(145, 29);
            this.ipTextBox1.TabIndex = 16;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 321);
            this.Controls.Add(this.ipTextBox1);
            this.Controls.Add(this.MailCheckBox);
            this.Controls.Add(this.MailGroup);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserAmount);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.UserAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port)).EndInit();
            this.MailGroup.ResumeLayout(false);
            this.MailGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MailPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown UserAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox SSLCheckBox;
        private System.Windows.Forms.GroupBox MailGroup;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.CheckBox MailCheckBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox SmtpTextBox;
        private WinFormsExtensions.IPTextBox ipTextBox;
        private System.Windows.Forms.NumericUpDown MailPort;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private WinFormsExtensions.IPTextBox ipTextBox1;
    }
}