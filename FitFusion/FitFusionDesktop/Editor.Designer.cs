namespace FitFusionDesktop
{
    partial class Editor
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
            BodyPanel = new Panel();
            SuspendLayout();
            // 
            // BodyPanel
            // 
            BodyPanel.Location = new Point(12, 12);
            BodyPanel.Name = "BodyPanel";
            BodyPanel.Size = new Size(568, 565);
            BodyPanel.TabIndex = 0;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            ClientSize = new Size(592, 589);
            Controls.Add(BodyPanel);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Editor";
            Text = "Editor";
            ResumeLayout(false);
        }

        #endregion

        private Panel BodyPanel;
    }
}