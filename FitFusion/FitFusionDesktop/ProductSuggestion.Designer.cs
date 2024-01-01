namespace FitFusionDesktop
{
    partial class ProductSuggestion
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            ProductsDataGrid = new ReaLTaiizor.Controls.PoisonDataGridView();
            btnSuggest = new ReaLTaiizor.Controls.Button();
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(41, 41, 41);
            dataGridViewCellStyle4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 163, 26);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            ProductsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            ProductsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Gray;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 163, 26);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            ProductsDataGrid.DefaultCellStyle = dataGridViewCellStyle5;
            ProductsDataGrid.EnableHeadersVisualStyles = false;
            ProductsDataGrid.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            ProductsDataGrid.GridColor = Color.FromArgb(255, 255, 255);
            ProductsDataGrid.Location = new Point(1, 2);
            ProductsDataGrid.Name = "ProductsDataGrid";
            ProductsDataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(41, 41, 41);
            dataGridViewCellStyle6.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(255, 163, 26);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            ProductsDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            ProductsDataGrid.RowHeadersWidth = 51;
            ProductsDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ProductsDataGrid.RowTemplate.Height = 29;
            ProductsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductsDataGrid.Size = new Size(926, 496);
            ProductsDataGrid.TabIndex = 4;
            // 
            // btnSuggest
            // 
            btnSuggest.BackColor = Color.Gray;
            btnSuggest.BorderColor = Color.FromArgb(41, 41, 41);
            btnSuggest.Cursor = Cursors.Hand;
            btnSuggest.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnSuggest.EnteredColor = Color.FromArgb(41, 41, 41);
            btnSuggest.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSuggest.Image = null;
            btnSuggest.ImageAlign = ContentAlignment.MiddleLeft;
            btnSuggest.InactiveColor = Color.FromArgb(41, 41, 41);
            btnSuggest.Location = new Point(273, 536);
            btnSuggest.Name = "btnSuggest";
            btnSuggest.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnSuggest.PressedColor = Color.FromArgb(255, 163, 26);
            btnSuggest.Size = new Size(351, 43);
            btnSuggest.TabIndex = 9;
            btnSuggest.Text = "Suggest";
            btnSuggest.TextAlignment = StringAlignment.Center;
            btnSuggest.Click += btnSuggest_Click;
            // 
            // ProductSuggestion
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(932, 591);
            Controls.Add(btnSuggest);
            Controls.Add(ProductsDataGrid);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProductSuggestion";
            Text = "ProductSuggestion";
            ((System.ComponentModel.ISupportInitialize)ProductsDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.PoisonDataGridView ProductsDataGrid;
        private ReaLTaiizor.Controls.Button btnSuggest;
    }
}