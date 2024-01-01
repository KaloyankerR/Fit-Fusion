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
            label1 = new Label();
            label2 = new Label();
            listBxMerchantRecommendation = new ListBox();
            btnSuggest = new ReaLTaiizor.Controls.Button();
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
            listBox4.Location = new Point(12, 461);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(368, 50);
            listBox4.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Gray;
            btnClose.BorderColor = Color.FromArgb(255, 163, 26);
            btnClose.Cursor = Cursors.Hand;
            btnClose.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnClose.EnteredColor = Color.FromArgb(255, 163, 26);
            btnClose.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Image = null;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.InactiveColor = Color.FromArgb(255, 163, 26);
            btnClose.Location = new Point(12, 720);
            btnClose.Name = "btnClose";
            btnClose.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnClose.PressedColor = Color.FromArgb(255, 163, 26);
            btnClose.Size = new Size(367, 48);
            btnClose.TabIndex = 13;
            btnClose.Text = "Close";
            btnClose.TextAlignment = StringAlignment.Center;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(12, 426);
            label1.Name = "label1";
            label1.Size = new Size(259, 32);
            label1.TabIndex = 15;
            label1.Text = "System suggestion:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(12, 514);
            label2.Name = "label2";
            label2.Size = new Size(282, 32);
            label2.TabIndex = 17;
            label2.Text = "Merchant suggestion:";
            // 
            // listBxMerchantRecommendation
            // 
            listBxMerchantRecommendation.BackColor = Color.Gray;
            listBxMerchantRecommendation.ForeColor = Color.White;
            listBxMerchantRecommendation.FormattingEnabled = true;
            listBxMerchantRecommendation.ItemHeight = 23;
            listBxMerchantRecommendation.Location = new Point(12, 549);
            listBxMerchantRecommendation.Name = "listBxMerchantRecommendation";
            listBxMerchantRecommendation.Size = new Size(368, 50);
            listBxMerchantRecommendation.TabIndex = 16;
            // 
            // btnSuggest
            // 
            btnSuggest.BackColor = Color.Gray;
            btnSuggest.BorderColor = Color.FromArgb(255, 163, 26);
            btnSuggest.Cursor = Cursors.Hand;
            btnSuggest.EnteredBorderColor = Color.FromArgb(41, 41, 41);
            btnSuggest.EnteredColor = Color.FromArgb(41, 41, 41);
            btnSuggest.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSuggest.Image = null;
            btnSuggest.ImageAlign = ContentAlignment.MiddleLeft;
            btnSuggest.InactiveColor = Color.FromArgb(41, 41, 41);
            btnSuggest.Location = new Point(12, 666);
            btnSuggest.Name = "btnSuggest";
            btnSuggest.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnSuggest.PressedColor = Color.FromArgb(255, 163, 26);
            btnSuggest.Size = new Size(367, 48);
            btnSuggest.TabIndex = 18;
            btnSuggest.Text = "Suggest";
            btnSuggest.TextAlignment = StringAlignment.Center;
            btnSuggest.Click += btnSuggest_Click;
            // 
            // Recommendations
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            ClientSize = new Size(391, 780);
            Controls.Add(btnSuggest);
            Controls.Add(label2);
            Controls.Add(listBxMerchantRecommendation);
            Controls.Add(label1);
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
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
        private ListBox listBox4;
        private ReaLTaiizor.Controls.Button btnClose;
        private Label label1;
        private Label label2;
        private ListBox listBxMerchantRecommendation;
        private ReaLTaiizor.Controls.Button btnSuggest;
    }
}