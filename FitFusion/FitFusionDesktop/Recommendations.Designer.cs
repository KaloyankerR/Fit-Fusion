namespace FitFusionDesktop
{
    partial class Recommendations
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
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            listBox3 = new ListBox();
            listBox4 = new ListBox();
            btnClose = new ReaLTaiizor.Controls.Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.Gray;
            listBox1.ForeColor = Color.White;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 23;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(368, 119);
            listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            listBox2.BackColor = Color.Gray;
            listBox2.ForeColor = Color.White;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 23;
            listBox2.Location = new Point(12, 137);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(368, 119);
            listBox2.TabIndex = 1;
            // 
            // listBox3
            // 
            listBox3.BackColor = Color.Gray;
            listBox3.ForeColor = Color.White;
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 23;
            listBox3.Location = new Point(12, 262);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(368, 119);
            listBox3.TabIndex = 2;
            // 
            // listBox4
            // 
            listBox4.BackColor = Color.Gray;
            listBox4.ForeColor = Color.White;
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 23;
            listBox4.Location = new Point(12, 387);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(368, 119);
            listBox4.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Gray;
            btnClose.BorderColor = Color.FromArgb(41, 41, 41);
            btnClose.Cursor = Cursors.Hand;
            btnClose.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnClose.EnteredColor = Color.FromArgb(41, 41, 41);
            btnClose.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Image = null;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.InactiveColor = Color.FromArgb(41, 41, 41);
            btnClose.Location = new Point(12, 580);
            btnClose.Name = "btnClose";
            btnClose.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnClose.PressedColor = Color.FromArgb(255, 163, 26);
            btnClose.Size = new Size(367, 48);
            btnClose.TabIndex = 13;
            btnClose.Text = "Close";
            btnClose.TextAlignment = StringAlignment.Center;
            btnClose.Click += btnClose_Click;
            // 
            // Recommendations
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            ClientSize = new Size(391, 640);
            Controls.Add(btnClose);
            Controls.Add(listBox4);
            Controls.Add(listBox3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Recommendations";
            Text = "Recommendations";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
        private ListBox listBox4;
        private ReaLTaiizor.Controls.Button btnClose;
    }
}