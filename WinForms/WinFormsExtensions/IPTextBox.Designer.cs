namespace WinFormsExtensions
{
    partial class IPTextBox
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
            this.box1 = new System.Windows.Forms.MaskedTextBox();
            this.box2 = new System.Windows.Forms.MaskedTextBox();
            this.box3 = new System.Windows.Forms.MaskedTextBox();
            this.box4 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // box1
            // 
            this.box1.Location = new System.Drawing.Point(0, 0);
            this.box1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.box1.Mask = "###";
            this.box1.Name = "box1";
            this.box1.PromptChar = ' ';
            this.box1.Size = new System.Drawing.Size(40, 29);
            this.box1.TabIndex = 0;
            this.box1.Text = "127";
            this.box1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.box_MouseClick);
            this.box1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.box_KeyPress);
            // 
            // box2
            // 
            this.box2.Location = new System.Drawing.Point(40, 0);
            this.box2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.box2.Mask = "###";
            this.box2.Name = "box2";
            this.box2.PromptChar = ' ';
            this.box2.Size = new System.Drawing.Size(40, 29);
            this.box2.TabIndex = 1;
            this.box2.Text = "0";
            this.box2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.box_MouseClick);
            this.box2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.box_KeyPress);
            // 
            // box3
            // 
            this.box3.Location = new System.Drawing.Point(80, 0);
            this.box3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.box3.Mask = "###";
            this.box3.Name = "box3";
            this.box3.PromptChar = ' ';
            this.box3.Size = new System.Drawing.Size(40, 29);
            this.box3.TabIndex = 2;
            this.box3.Text = "0";
            this.box3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.box_MouseClick);
            this.box3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.box_KeyPress);
            // 
            // box4
            // 
            this.box4.Location = new System.Drawing.Point(120, 0);
            this.box4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.box4.Mask = "###";
            this.box4.Name = "box4";
            this.box4.PromptChar = ' ';
            this.box4.Size = new System.Drawing.Size(40, 29);
            this.box4.TabIndex = 3;
            this.box4.Text = "1";
            this.box4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.box_MouseClick);
            this.box4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.box_KeyPress);
            // 
            // IPTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.box4);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "IPTextBox";
            this.Size = new System.Drawing.Size(160, 29);
            this.FontChanged += new System.EventHandler(this.IPTextBox_FontChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox box1;
        private System.Windows.Forms.MaskedTextBox box2;
        private System.Windows.Forms.MaskedTextBox box3;
        private System.Windows.Forms.MaskedTextBox box4;
    }
}
