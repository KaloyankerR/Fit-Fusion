namespace FitFusionDesktop.EntityControls
{
    partial class CreateUser
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
            spaceLabel1 = new ReaLTaiizor.Controls.SpaceLabel();
            btnCancel = new ReaLTaiizor.Controls.Button();
            btnSubmit = new ReaLTaiizor.Controls.Button();
            SuspendLayout();
            // 
            // spaceLabel1
            // 
            spaceLabel1.Customization = "/v7+/yoqKv8=";
            spaceLabel1.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
            spaceLabel1.Image = null;
            spaceLabel1.Location = new Point(395, 191);
            spaceLabel1.Name = "spaceLabel1";
            spaceLabel1.NoRounding = false;
            spaceLabel1.Size = new Size(94, 50);
            spaceLabel1.TabIndex = 0;
            spaceLabel1.Text = "Create user";
            spaceLabel1.TextAlignment = HorizontalAlignment.Center;
            spaceLabel1.Transparent = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.BorderColor = Color.FromArgb(41, 41, 41);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnCancel.EnteredColor = Color.FromArgb(41, 41, 41);
            btnCancel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Image = null;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.InactiveColor = Color.FromArgb(41, 41, 41);
            btnCancel.Location = new Point(3, 650);
            btnCancel.Name = "btnCancel";
            btnCancel.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnCancel.PressedColor = Color.FromArgb(255, 163, 26);
            btnCancel.Size = new Size(150, 50);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.TextAlignment = StringAlignment.Center;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.Gray;
            btnSubmit.BorderColor = Color.FromArgb(41, 41, 41);
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnSubmit.EnteredColor = Color.FromArgb(41, 41, 41);
            btnSubmit.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSubmit.Image = null;
            btnSubmit.ImageAlign = ContentAlignment.MiddleLeft;
            btnSubmit.InactiveColor = Color.FromArgb(41, 41, 41);
            btnSubmit.Location = new Point(159, 650);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnSubmit.PressedColor = Color.FromArgb(255, 163, 26);
            btnSubmit.Size = new Size(150, 50);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.TextAlignment = StringAlignment.Center;
            // 
            // CreateUser
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
            Controls.Add(spaceLabel1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CreateUser";
            Size = new Size(932, 703);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.SpaceLabel spaceLabel1;
        private ReaLTaiizor.Controls.Button btnCancel;
        private ReaLTaiizor.Controls.Button btnSubmit;
    }
}
