namespace FitFusionDesktop.CRUD
{
    partial class UserCreate
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
            label1 = new Label();
            cbxRole = new ComboBox();
            label2 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtPassword = new TextBox();
            label5 = new Label();
            txtAddress = new TextBox();
            label6 = new Label();
            txtPhone = new TextBox();
            label7 = new Label();
            btnSubmit = new ReaLTaiizor.Controls.CyberButton();
            groupBxPhone = new GroupBox();
            groupBxPhone.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(43, 37);
            label1.Name = "label1";
            label1.Size = new Size(50, 23);
            label1.TabIndex = 0;
            label1.Text = "Role";
            // 
            // cbxRole
            // 
            cbxRole.FormattingEnabled = true;
            cbxRole.Items.AddRange(new object[] { "Owner", "Staff", "Customer" });
            cbxRole.Location = new Point(43, 63);
            cbxRole.Name = "cbxRole";
            cbxRole.Size = new Size(151, 31);
            cbxRole.TabIndex = 1;
            cbxRole.SelectedIndexChanged += cbxRole_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(43, 117);
            label2.Name = "label2";
            label2.Size = new Size(103, 23);
            label2.TabIndex = 3;
            label2.Text = "First name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(43, 143);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 30);
            txtFirstName.TabIndex = 4;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(43, 227);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 30);
            txtLastName.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(43, 201);
            label3.Name = "label3";
            label3.Size = new Size(102, 23);
            label3.TabIndex = 5;
            label3.Text = "Last name";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(307, 63);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 30);
            txtEmail.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(307, 37);
            label4.Name = "label4";
            label4.Size = new Size(58, 23);
            label4.TabIndex = 7;
            label4.Text = "Email";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(307, 143);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 30);
            txtPassword.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(307, 117);
            label5.Name = "label5";
            label5.Size = new Size(98, 23);
            label5.TabIndex = 9;
            label5.Text = "Password";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(307, 227);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 30);
            txtAddress.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(307, 201);
            label6.Name = "label6";
            label6.Size = new Size(83, 23);
            label6.TabIndex = 11;
            label6.Text = "Address";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(6, 62);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 30);
            txtPhone.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(6, 36);
            label7.Name = "label7";
            label7.Size = new Size(65, 23);
            label7.TabIndex = 13;
            label7.Text = "Phone";
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
            btnSubmit.Location = new Point(173, 471);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.PenWidth = 15;
            btnSubmit.Rounding = true;
            btnSubmit.RoundingInt = 70;
            btnSubmit.Size = new Size(162, 62);
            btnSubmit.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnSubmit.TabIndex = 15;
            btnSubmit.Tag = "Cyber";
            btnSubmit.TextButton = "Submit";
            btnSubmit.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnSubmit.Timer_Effect_1 = 5;
            btnSubmit.Timer_RGB = 300;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // groupBxPhone
            // 
            groupBxPhone.Controls.Add(label7);
            groupBxPhone.Controls.Add(txtPhone);
            groupBxPhone.ForeColor = SystemColors.Control;
            groupBxPhone.Location = new Point(43, 325);
            groupBxPhone.Name = "groupBxPhone";
            groupBxPhone.Size = new Size(244, 106);
            groupBxPhone.TabIndex = 16;
            groupBxPhone.TabStop = false;
            groupBxPhone.Text = "Owner and Staff";
            // 
            // UserCreate
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            Controls.Add(groupBxPhone);
            Controls.Add(btnSubmit);
            Controls.Add(txtAddress);
            Controls.Add(label6);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtLastName);
            Controls.Add(label3);
            Controls.Add(txtFirstName);
            Controls.Add(label2);
            Controls.Add(cbxRole);
            Controls.Add(label1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UserCreate";
            Size = new Size(568, 565);
            groupBxPhone.ResumeLayout(false);
            groupBxPhone.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbxRole;
        private Label label2;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtPassword;
        private Label label5;
        private TextBox txtAddress;
        private Label label6;
        private TextBox txtPhone;
        private Label label7;
        private ReaLTaiizor.Controls.CyberButton btnSubmit;
        private GroupBox groupBxPhone;
    }
}
