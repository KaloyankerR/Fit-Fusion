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
            groupBox1 = new GroupBox();
            lblAddress = new Label();
            lblEmail = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.profileImg;
            pictureBox1.Location = new Point(49, 27);
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
            lblRole.Location = new Point(212, 27);
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
            lblName.Location = new Point(9, 66);
            lblName.Name = "lblName";
            lblName.Size = new Size(89, 35);
            lblName.TabIndex = 3;
            lblName.Text = "name";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblAddress);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(lblName);
            groupBox1.Location = new Point(49, 193);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(369, 351);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Personal details";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblAddress.ForeColor = Color.FromArgb(255, 163, 26);
            lblAddress.Location = new Point(9, 239);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(121, 35);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "address";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.ForeColor = Color.FromArgb(255, 163, 26);
            lblEmail.Location = new Point(9, 150);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(86, 35);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "email";
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(groupBox1);
            Controls.Add(lblRole);
            Controls.Add(pictureBox1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Profile";
            Size = new Size(932, 703);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblRole;
        private Label lblName;
        private GroupBox groupBox1;
        private Label lblEmail;
        private Label lblAddress;
    }
}
