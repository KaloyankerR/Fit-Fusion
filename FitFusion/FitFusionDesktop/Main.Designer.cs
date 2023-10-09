namespace FitFusionDesktop
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            NavbarPanel = new Panel();
            imgLogo = new PictureBox();
            btnHome = new ReaLTaiizor.Controls.CyberButton();
            btnProducts = new ReaLTaiizor.Controls.CyberButton();
            BodyPanel = new Panel();
            btnUsers = new ReaLTaiizor.Controls.CyberButton();
            NavbarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            SuspendLayout();
            // 
            // NavbarPanel
            // 
            NavbarPanel.BackColor = Color.FromArgb(41, 41, 41);
            NavbarPanel.Controls.Add(btnUsers);
            NavbarPanel.Controls.Add(imgLogo);
            NavbarPanel.Controls.Add(btnHome);
            NavbarPanel.Controls.Add(btnProducts);
            NavbarPanel.Dock = DockStyle.Left;
            NavbarPanel.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            NavbarPanel.ForeColor = Color.White;
            NavbarPanel.Location = new Point(0, 0);
            NavbarPanel.Name = "NavbarPanel";
            NavbarPanel.Size = new Size(250, 703);
            NavbarPanel.TabIndex = 0;
            // 
            // imgLogo
            // 
            imgLogo.Image = (Image)resources.GetObject("imgLogo.Image");
            imgLogo.Location = new Point(69, 48);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(102, 87);
            imgLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            imgLogo.TabIndex = 5;
            imgLogo.TabStop = false;
            imgLogo.Click += imgLogo_Click;
            // 
            // btnHome
            // 
            btnHome.Alpha = 20;
            btnHome.BackColor = Color.Transparent;
            btnHome.Background = true;
            btnHome.Background_WidthPen = 4F;
            btnHome.BackgroundPen = true;
            btnHome.ColorBackground = Color.FromArgb(41, 41, 41);
            btnHome.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnHome.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnHome.ColorBackground_Pen = Color.FromArgb(255, 163, 26);
            btnHome.ColorLighting = Color.FromArgb(29, 200, 238);
            btnHome.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnHome.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnHome.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnHome.Effect_1 = true;
            btnHome.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnHome.Effect_1_Transparency = 25;
            btnHome.Effect_2 = true;
            btnHome.Effect_2_ColorBackground = Color.White;
            btnHome.Effect_2_Transparency = 20;
            btnHome.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnHome.ForeColor = Color.White;
            btnHome.Lighting = false;
            btnHome.LinearGradient_Background = false;
            btnHome.LinearGradientPen = false;
            btnHome.Location = new Point(41, 246);
            btnHome.Name = "btnHome";
            btnHome.PenWidth = 15;
            btnHome.Rounding = true;
            btnHome.RoundingInt = 70;
            btnHome.Size = new Size(162, 62);
            btnHome.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnHome.TabIndex = 3;
            btnHome.Tag = "Cyber";
            btnHome.TextButton = "Home";
            btnHome.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnHome.Timer_Effect_1 = 5;
            btnHome.Timer_RGB = 300;
            btnHome.Click += btnHome_Click;
            // 
            // btnProducts
            // 
            btnProducts.Alpha = 20;
            btnProducts.BackColor = Color.Transparent;
            btnProducts.Background = true;
            btnProducts.Background_WidthPen = 4F;
            btnProducts.BackgroundPen = true;
            btnProducts.ColorBackground = Color.FromArgb(41, 41, 41);
            btnProducts.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnProducts.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnProducts.ColorBackground_Pen = Color.FromArgb(255, 163, 26);
            btnProducts.ColorLighting = Color.FromArgb(29, 200, 238);
            btnProducts.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnProducts.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnProducts.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnProducts.Effect_1 = true;
            btnProducts.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnProducts.Effect_1_Transparency = 25;
            btnProducts.Effect_2 = true;
            btnProducts.Effect_2_ColorBackground = Color.White;
            btnProducts.Effect_2_Transparency = 20;
            btnProducts.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnProducts.ForeColor = Color.White;
            btnProducts.Lighting = false;
            btnProducts.LinearGradient_Background = false;
            btnProducts.LinearGradientPen = false;
            btnProducts.Location = new Point(41, 314);
            btnProducts.Name = "btnProducts";
            btnProducts.PenWidth = 15;
            btnProducts.Rounding = true;
            btnProducts.RoundingInt = 70;
            btnProducts.Size = new Size(162, 62);
            btnProducts.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnProducts.TabIndex = 4;
            btnProducts.Tag = "Cyber";
            btnProducts.TextButton = "Products";
            btnProducts.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnProducts.Timer_Effect_1 = 5;
            btnProducts.Timer_RGB = 300;
            btnProducts.Click += btnProducts_Click;
            // 
            // BodyPanel
            // 
            BodyPanel.BackColor = Color.Gray;
            BodyPanel.Dock = DockStyle.Fill;
            BodyPanel.ForeColor = Color.White;
            BodyPanel.Location = new Point(250, 0);
            BodyPanel.Name = "BodyPanel";
            BodyPanel.Size = new Size(932, 703);
            BodyPanel.TabIndex = 1;
            // 
            // btnUsers
            // 
            btnUsers.Alpha = 20;
            btnUsers.BackColor = Color.Transparent;
            btnUsers.Background = true;
            btnUsers.Background_WidthPen = 4F;
            btnUsers.BackgroundPen = true;
            btnUsers.ColorBackground = Color.FromArgb(41, 41, 41);
            btnUsers.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnUsers.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnUsers.ColorBackground_Pen = Color.FromArgb(255, 163, 26);
            btnUsers.ColorLighting = Color.FromArgb(29, 200, 238);
            btnUsers.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnUsers.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnUsers.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnUsers.Effect_1 = true;
            btnUsers.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnUsers.Effect_1_Transparency = 25;
            btnUsers.Effect_2 = true;
            btnUsers.Effect_2_ColorBackground = Color.White;
            btnUsers.Effect_2_Transparency = 20;
            btnUsers.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnUsers.ForeColor = Color.White;
            btnUsers.Lighting = false;
            btnUsers.LinearGradient_Background = false;
            btnUsers.LinearGradientPen = false;
            btnUsers.Location = new Point(41, 382);
            btnUsers.Name = "btnUsers";
            btnUsers.PenWidth = 15;
            btnUsers.Rounding = true;
            btnUsers.RoundingInt = 70;
            btnUsers.Size = new Size(162, 62);
            btnUsers.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnUsers.TabIndex = 6;
            btnUsers.Tag = "Cyber";
            btnUsers.TextButton = "Users";
            btnUsers.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnUsers.Timer_Effect_1 = 5;
            btnUsers.Timer_RGB = 300;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 703);
            Controls.Add(BodyPanel);
            Controls.Add(NavbarPanel);
            Name = "Main";
            Text = "Main";
            NavbarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imgLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel NavbarPanel;
        private ReaLTaiizor.Controls.CyberButton btnHome;
        private Panel BodyPanel;
        private ReaLTaiizor.Controls.CyberButton btnProducts;
        private PictureBox imgLogo;
        private ReaLTaiizor.Controls.CyberButton btnUsers;
    }
}