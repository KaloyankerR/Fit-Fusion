namespace FitFusionDesktop.UserControls
{
    partial class Users
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            UsersDataGrid = new ReaLTaiizor.Controls.PoisonDataGridView();
            ((System.ComponentModel.ISupportInitialize)UsersDataGrid).BeginInit();
            SuspendLayout();
            // 
            // UsersDataGrid
            // 
            UsersDataGrid.AllowUserToResizeRows = false;
            UsersDataGrid.BackgroundColor = Color.FromArgb(41, 41, 41);
            UsersDataGrid.BorderStyle = BorderStyle.None;
            UsersDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            UsersDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(41, 41, 41);
            dataGridViewCellStyle1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 163, 26);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            UsersDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            UsersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 163, 26);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            UsersDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            UsersDataGrid.EnableHeadersVisualStyles = false;
            UsersDataGrid.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            UsersDataGrid.GridColor = Color.FromArgb(255, 255, 255);
            UsersDataGrid.Location = new Point(56, 165);
            UsersDataGrid.Name = "UsersDataGrid";
            UsersDataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(41, 41, 41);
            dataGridViewCellStyle3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 163, 26);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            UsersDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            UsersDataGrid.RowHeadersWidth = 51;
            UsersDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            UsersDataGrid.RowTemplate.Height = 29;
            UsersDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UsersDataGrid.Size = new Size(821, 424);
            UsersDataGrid.TabIndex = 2;
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(UsersDataGrid);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Users";
            Size = new Size(932, 703);
            ((System.ComponentModel.ISupportInitialize)UsersDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ReaLTaiizor.Controls.PoisonDataGridView UsersDataGrid;
    }
}
