namespace FitFusionDesktop.CRUD
{
    partial class ProductCreate
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
            txtPrice = new NumericUpDown();
            label9 = new Label();
            label8 = new Label();
            txtDescription = new RichTextBox();
            btnSubmit = new ReaLTaiizor.Controls.CyberButton();
            txtTitle = new TextBox();
            label4 = new Label();
            txtImageUrl = new TextBox();
            label2 = new Label();
            cbxCategory = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)txtPrice).BeginInit();
            SuspendLayout();
            // 
            // txtPrice
            // 
            txtPrice.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            txtPrice.Location = new Point(323, 59);
            txtPrice.Margin = new Padding(4, 3, 4, 3);
            txtPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(132, 30);
            txtPrice.TabIndex = 46;
            txtPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(323, 33);
            label9.Name = "label9";
            label9.Size = new Size(55, 23);
            label9.TabIndex = 45;
            label9.Text = "Price";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(34, 111);
            label8.Name = "label8";
            label8.Size = new Size(108, 23);
            label8.TabIndex = 44;
            label8.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(34, 137);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(421, 97);
            txtDescription.TabIndex = 43;
            txtDescription.Text = "";
            // 
            // btnSubmit
            // 
            btnSubmit.Alpha = 20;
            btnSubmit.BackColor = Color.Transparent;
            btnSubmit.Background = true;
            btnSubmit.Background_WidthPen = 4F;
            btnSubmit.BackgroundPen = true;
            btnSubmit.ColorBackground = Color.FromArgb(41, 41, 41);
            btnSubmit.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnSubmit.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnSubmit.ColorBackground_Pen = Color.FromArgb(255, 163, 26);
            btnSubmit.ColorLighting = Color.FromArgb(29, 200, 238);
            btnSubmit.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnSubmit.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnSubmit.Effect_1 = true;
            btnSubmit.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnSubmit.Effect_1_Transparency = 25;
            btnSubmit.Effect_2 = true;
            btnSubmit.Effect_2_ColorBackground = Color.White;
            btnSubmit.Effect_2_Transparency = 20;
            btnSubmit.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Lighting = false;
            btnSubmit.LinearGradient_Background = false;
            btnSubmit.LinearGradientPen = false;
            btnSubmit.Location = new Point(162, 438);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.PenWidth = 15;
            btnSubmit.Rounding = true;
            btnSubmit.RoundingInt = 70;
            btnSubmit.Size = new Size(162, 62);
            btnSubmit.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnSubmit.TabIndex = 42;
            btnSubmit.Tag = "Cyber";
            btnSubmit.TextButton = "Create";
            btnSubmit.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnSubmit.Timer_Effect_1 = 5;
            btnSubmit.Timer_RGB = 300;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(34, 59);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(237, 30);
            txtTitle.TabIndex = 41;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(34, 33);
            label4.Name = "label4";
            label4.Size = new Size(46, 23);
            label4.TabIndex = 40;
            label4.Text = "Title";
            // 
            // txtImageUrl
            // 
            txtImageUrl.Location = new Point(34, 370);
            txtImageUrl.Name = "txtImageUrl";
            txtImageUrl.Size = new Size(405, 30);
            txtImageUrl.TabIndex = 39;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(34, 344);
            label2.Name = "label2";
            label2.Size = new Size(109, 23);
            label2.TabIndex = 38;
            label2.Text = "Image URL";
            // 
            // cbxCategory
            // 
            cbxCategory.FormattingEnabled = true;
            cbxCategory.Location = new Point(34, 292);
            cbxCategory.Name = "cbxCategory";
            cbxCategory.Size = new Size(151, 31);
            cbxCategory.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(34, 266);
            label1.Name = "label1";
            label1.Size = new Size(91, 23);
            label1.TabIndex = 36;
            label1.Text = "Category";
            // 
            // ProductCreate
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            ClientSize = new Size(493, 537);
            Controls.Add(txtPrice);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txtDescription);
            Controls.Add(btnSubmit);
            Controls.Add(txtTitle);
            Controls.Add(label4);
            Controls.Add(txtImageUrl);
            Controls.Add(label2);
            Controls.Add(cbxCategory);
            Controls.Add(label1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProductCreate";
            Text = "ProductCreate";
            ((System.ComponentModel.ISupportInitialize)txtPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown txtPrice;
        private Label label9;
        private Label label8;
        private RichTextBox txtDescription;
        private ReaLTaiizor.Controls.CyberButton btnSubmit;
        private TextBox txtTitle;
        private Label label4;
        private TextBox txtImageUrl;
        private Label label2;
        private ComboBox cbxCategory;
        private Label label1;
    }
}