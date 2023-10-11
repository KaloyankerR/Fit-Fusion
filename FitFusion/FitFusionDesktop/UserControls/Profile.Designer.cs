namespace FitFusionDesktop.UserControls
{
    partial class Profile
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
            pictureBox1 = new PictureBox();
            lblRole = new Label();
            lblName = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.profileImg;
            pictureBox1.Location = new Point(58, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(157, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblRole.ForeColor = Color.FromArgb(255, 163, 26);
            lblRole.Location = new Point(221, 29);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(64, 35);
            lblRole.TabIndex = 2;
            lblRole.Text = "role";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.FromArgb(255, 163, 26);
            lblName.Location = new Point(221, 76);
            lblName.Name = "lblName";
            lblName.Size = new Size(89, 35);
            lblName.TabIndex = 3;
            lblName.Text = "name";
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(lblName);
            Controls.Add(lblRole);
            Controls.Add(pictureBox1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Profile";
            Size = new Size(932, 703);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblRole;
        private Label lblName;
    }
}
