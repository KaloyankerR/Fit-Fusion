namespace FitFusionDesktop.UserControls
{
    partial class Products
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
            ProductsDataGrid = new ReaLTaiizor.Controls.PoisonDataGridView();
            btnCreate = new ReaLTaiizor.Controls.Button();
            btnUpdate = new ReaLTaiizor.Controls.Button();
            btnDelete = new ReaLTaiizor.Controls.Button();
            aloneTextBox1 = new ReaLTaiizor.Controls.AloneTextBox();
            ((System.ComponentModel.ISupportInitialize)ProductsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // ProductsDataGrid
            // 
            ProductsDataGrid.AllowUserToResizeRows = false;
            ProductsDataGrid.BackgroundColor = Color.FromArgb(41, 41, 41);
            ProductsDataGrid.BorderStyle = BorderStyle.None;
            ProductsDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            ProductsDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(41, 41, 41);
            dataGridViewCellStyle1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 163, 26);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ProductsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ProductsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 163, 26);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ProductsDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            ProductsDataGrid.EnableHeadersVisualStyles = false;
            ProductsDataGrid.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            ProductsDataGrid.GridColor = Color.FromArgb(255, 255, 255);
            ProductsDataGrid.Location = new Point(3, 3);
            ProductsDataGrid.Name = "ProductsDataGrid";
            ProductsDataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(41, 41, 41);
            dataGridViewCellStyle3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 163, 26);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            ProductsDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            ProductsDataGrid.RowHeadersWidth = 51;
            ProductsDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ProductsDataGrid.RowTemplate.Height = 29;
            ProductsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductsDataGrid.Size = new Size(926, 496);
            ProductsDataGrid.TabIndex = 3;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Gray;
            btnCreate.BorderColor = Color.FromArgb(41, 41, 41);
            btnCreate.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnCreate.EnteredColor = Color.FromArgb(41, 41, 41);
            btnCreate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreate.Image = null;
            btnCreate.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreate.InactiveColor = Color.FromArgb(41, 41, 41);
            btnCreate.Location = new Point(31, 521);
            btnCreate.Name = "btnCreate";
            btnCreate.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnCreate.PressedColor = Color.FromArgb(255, 163, 26);
            btnCreate.Size = new Size(150, 50);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Create";
            btnCreate.TextAlignment = StringAlignment.Center;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Gray;
            btnUpdate.BorderColor = Color.FromArgb(41, 41, 41);
            btnUpdate.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnUpdate.EnteredColor = Color.FromArgb(41, 41, 41);
            btnUpdate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.Image = null;
            btnUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpdate.InactiveColor = Color.FromArgb(41, 41, 41);
            btnUpdate.Location = new Point(31, 577);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnUpdate.PressedColor = Color.FromArgb(255, 163, 26);
            btnUpdate.Size = new Size(150, 50);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.TextAlignment = StringAlignment.Center;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Gray;
            btnDelete.BorderColor = Color.FromArgb(41, 41, 41);
            btnDelete.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnDelete.EnteredColor = Color.FromArgb(41, 41, 41);
            btnDelete.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Image = null;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.InactiveColor = Color.FromArgb(41, 41, 41);
            btnDelete.Location = new Point(31, 633);
            btnDelete.Name = "btnDelete";
            btnDelete.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnDelete.PressedColor = Color.FromArgb(255, 163, 26);
            btnDelete.Size = new Size(150, 50);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.TextAlignment = StringAlignment.Center;
            // 
            // aloneTextBox1
            // 
            aloneTextBox1.BackColor = Color.White;
            aloneTextBox1.EnabledCalc = true;
            aloneTextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            aloneTextBox1.ForeColor = Color.FromArgb(124, 133, 142);
            aloneTextBox1.Location = new Point(410, 543);
            aloneTextBox1.MaxLength = 32767;
            aloneTextBox1.MultiLine = false;
            aloneTextBox1.Name = "aloneTextBox1";
            aloneTextBox1.ReadOnly = false;
            aloneTextBox1.Size = new Size(121, 36);
            aloneTextBox1.TabIndex = 7;
            aloneTextBox1.Text = "aloneTextBox1";
            aloneTextBox1.TextAlign = HorizontalAlignment.Left;
            aloneTextBox1.UseSystemPasswordChar = false;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(aloneTextBox1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(ProductsDataGrid);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Products";
            Size = new Size(932, 703);
            ((System.ComponentModel.ISupportInitialize)ProductsDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.PoisonDataGridView ProductsDataGrid;
        private ReaLTaiizor.Controls.Button btnCreate;
        private ReaLTaiizor.Controls.Button btnUpdate;
        private ReaLTaiizor.Controls.Button btnDelete;
        private ReaLTaiizor.Controls.AloneTextBox aloneTextBox1;
    }
}
