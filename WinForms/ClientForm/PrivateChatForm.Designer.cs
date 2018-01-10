using System.Windows.Forms;

namespace ClientForm
{
    partial class PrivateChatForm
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
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatBox
            // 
            this.chatBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.chatBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chatBox.Location = new System.Drawing.Point(2, 23);
            this.chatBox.Margin = new System.Windows.Forms.Padding(2);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(385, 417);
            this.chatBox.TabIndex = 2;
            this.chatBox.Text = "";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(3, 446);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(304, 20);
            this.textBox.TabIndex = 3;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(392, 23);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(313, 447);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 20);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // PrivateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnQuit);
            this.Name = "PrivateChat";
            this.Size = new System.Drawing.Size(470, 470);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private RichTextBox chatBox;
        private TextBox textBox;
        private Button btnSend;
        private Button btnQuit;


        #endregion
    }
}
