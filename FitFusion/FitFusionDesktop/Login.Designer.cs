﻿namespace FitFusionDesktop
{
    partial class Login
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
            txtEmail = new ReaLTaiizor.Controls.CyberTextBox();
            txtPassword = new ReaLTaiizor.Controls.CyberTextBox();
            btnLogin = new ReaLTaiizor.Controls.CyberButton();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Alpha = 20;
            txtEmail.BackColor = Color.Transparent;
            txtEmail.Background_WidthPen = 3F;
            txtEmail.BackgroundPen = true;
            txtEmail.ColorBackground = Color.FromArgb(41, 41, 41);
            txtEmail.ColorBackground_Pen = Color.FromArgb(255, 163, 26);
            txtEmail.ColorLighting = Color.FromArgb(29, 200, 238);
            txtEmail.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtEmail.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtEmail.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtEmail.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.ForeColor = Color.White;
            txtEmail.Lighting = false;
            txtEmail.LinearGradientPen = false;
            txtEmail.Location = new Point(272, 129);
            txtEmail.Name = "txtEmail";
            txtEmail.PenWidth = 15;
            txtEmail.RGB = false;
            txtEmail.Rounding = true;
            txtEmail.RoundingInt = 60;
            txtEmail.Size = new Size(250, 50);
            txtEmail.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtEmail.TabIndex = 2;
            txtEmail.Tag = "Cyber";
            txtEmail.TextButton = "Email";
            txtEmail.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtEmail.Timer_RGB = 300;
            // 
            // txtPassword
            // 
            txtPassword.Alpha = 20;
            txtPassword.BackColor = Color.Transparent;
            txtPassword.Background_WidthPen = 3F;
            txtPassword.BackgroundPen = true;
            txtPassword.ColorBackground = Color.FromArgb(41, 41, 41);
            txtPassword.ColorBackground_Pen = Color.FromArgb(255, 163, 26);
            txtPassword.ColorLighting = Color.FromArgb(29, 200, 238);
            txtPassword.ColorPen_1 = Color.FromArgb(29, 200, 238);
            txtPassword.ColorPen_2 = Color.FromArgb(37, 52, 68);
            txtPassword.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            txtPassword.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = Color.White;
            txtPassword.Lighting = false;
            txtPassword.LinearGradientPen = false;
            txtPassword.Location = new Point(275, 200);
            txtPassword.Name = "txtPassword";
            txtPassword.PenWidth = 15;
            txtPassword.RGB = false;
            txtPassword.Rounding = true;
            txtPassword.RoundingInt = 60;
            txtPassword.Size = new Size(250, 50);
            txtPassword.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            txtPassword.TabIndex = 3;
            txtPassword.Tag = "Cyber";
            txtPassword.TextButton = "Password";
            txtPassword.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            txtPassword.Timer_RGB = 300;
            // 
            // btnLogin
            // 
            btnLogin.Alpha = 20;
            btnLogin.BackColor = Color.Transparent;
            btnLogin.Background = true;
            btnLogin.Background_WidthPen = 4F;
            btnLogin.BackgroundPen = true;
            btnLogin.ColorBackground = Color.FromArgb(41, 41, 41);
            btnLogin.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnLogin.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnLogin.ColorBackground_Pen = Color.FromArgb(255, 163, 26);
            btnLogin.ColorLighting = Color.FromArgb(29, 200, 238);
            btnLogin.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnLogin.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnLogin.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnLogin.Effect_1 = true;
            btnLogin.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnLogin.Effect_1_Transparency = 25;
            btnLogin.Effect_2 = true;
            btnLogin.Effect_2_ColorBackground = Color.White;
            btnLogin.Effect_2_Transparency = 20;
            btnLogin.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Lighting = false;
            btnLogin.LinearGradient_Background = false;
            btnLogin.LinearGradientPen = false;
            btnLogin.Location = new Point(319, 318);
            btnLogin.Name = "btnLogin";
            btnLogin.PenWidth = 15;
            btnLogin.Rounding = true;
            btnLogin.RoundingInt = 70;
            btnLogin.Size = new Size(162, 62);
            btnLogin.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnLogin.TabIndex = 5;
            btnLogin.Tag = "Cyber";
            btnLogin.TextButton = "Login";
            btnLogin.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnLogin.Timer_Effect_1 = 5;
            btnLogin.Timer_RGB = 300;
            btnLogin.Click += btnLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.CyberTextBox txtEmail;
        private ReaLTaiizor.Controls.CyberTextBox txtPassword;
        private ReaLTaiizor.Controls.CyberButton btnLogin;
    }
}