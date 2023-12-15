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
            btnSearch = new ReaLTaiizor.Controls.Button();
            txtSearchQuery = new ReaLTaiizor.Controls.HopeTextBox();
            categoryCmbBox = new ReaLTaiizor.Controls.DungeonComboBox();
            label1 = new Label();
            label2 = new Label();
            btnRefresh = new ReaLTaiizor.Controls.Button();
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
            btnCreate.Cursor = Cursors.Hand;
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
            btnUpdate.Cursor = Cursors.Hand;
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
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Gray;
            btnDelete.BorderColor = Color.FromArgb(41, 41, 41);
            btnDelete.Cursor = Cursors.Hand;
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
            // btnSearch
            // 
            btnSearch.BackColor = Color.Gray;
            btnSearch.BorderColor = Color.FromArgb(41, 41, 41);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnSearch.EnteredColor = Color.FromArgb(41, 41, 41);
            btnSearch.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Image = null;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.InactiveColor = Color.FromArgb(41, 41, 41);
            btnSearch.Location = new Point(207, 640);
            btnSearch.Name = "btnSearch";
            btnSearch.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnSearch.PressedColor = Color.FromArgb(255, 163, 26);
            btnSearch.Size = new Size(351, 43);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.TextAlignment = StringAlignment.Center;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchQuery
            // 
            txtSearchQuery.BackColor = Color.FromArgb(41, 41, 41);
            txtSearchQuery.BaseColor = Color.FromArgb(41, 41, 41);
            txtSearchQuery.BorderColorA = Color.FromArgb(255, 163, 26);
            txtSearchQuery.BorderColorB = Color.FromArgb(41, 41, 41);
            txtSearchQuery.Cursor = Cursors.Hand;
            txtSearchQuery.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchQuery.ForeColor = Color.White;
            txtSearchQuery.Hint = "";
            txtSearchQuery.Location = new Point(367, 577);
            txtSearchQuery.MaxLength = 32767;
            txtSearchQuery.Multiline = false;
            txtSearchQuery.Name = "txtSearchQuery";
            txtSearchQuery.PasswordChar = '\0';
            txtSearchQuery.ScrollBars = ScrollBars.None;
            txtSearchQuery.SelectedText = "";
            txtSearchQuery.SelectionLength = 0;
            txtSearchQuery.SelectionStart = 0;
            txtSearchQuery.Size = new Size(191, 43);
            txtSearchQuery.TabIndex = 9;
            txtSearchQuery.TabStop = false;
            txtSearchQuery.UseSystemPasswordChar = false;
            // 
            // categoryCmbBox
            // 
            categoryCmbBox.BackColor = Color.FromArgb(41, 41, 41);
            categoryCmbBox.ColorA = Color.FromArgb(255, 163, 26);
            categoryCmbBox.ColorB = Color.FromArgb(255, 163, 26);
            categoryCmbBox.ColorC = Color.FromArgb(41, 41, 41);
            categoryCmbBox.ColorD = Color.FromArgb(41, 41, 41);
            categoryCmbBox.ColorE = Color.FromArgb(41, 41, 41);
            categoryCmbBox.ColorF = Color.FromArgb(41, 41, 41);
            categoryCmbBox.ColorG = Color.FromArgb(255, 163, 26);
            categoryCmbBox.ColorH = Color.FromArgb(41, 41, 41);
            categoryCmbBox.ColorI = Color.FromArgb(41, 41, 41);
            categoryCmbBox.DrawMode = DrawMode.OwnerDrawFixed;
            categoryCmbBox.DropDownHeight = 100;
            categoryCmbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryCmbBox.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            categoryCmbBox.ForeColor = Color.FromArgb(255, 163, 26);
            categoryCmbBox.FormattingEnabled = true;
            categoryCmbBox.HoverSelectionColor = Color.Empty;
            categoryCmbBox.IntegralHeight = false;
            categoryCmbBox.ItemHeight = 20;
            categoryCmbBox.Location = new Point(367, 531);
            categoryCmbBox.Name = "categoryCmbBox";
            categoryCmbBox.Size = new Size(191, 26);
            categoryCmbBox.StartIndex = 0;
            categoryCmbBox.TabIndex = 11;
            categoryCmbBox.SelectedIndexChanged += categoryCmbBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(207, 531);
            label1.Name = "label1";
            label1.Size = new Size(154, 23);
            label1.TabIndex = 14;
            label1.Text = "Select category:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(253, 588);
            label2.Name = "label2";
            label2.Size = new Size(108, 23);
            label2.TabIndex = 15;
            label2.Text = "Search for:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Gray;
            btnRefresh.BorderColor = Color.FromArgb(41, 41, 41);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnRefresh.EnteredColor = Color.FromArgb(41, 41, 41);
            btnRefresh.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.Image = null;
            btnRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefresh.InactiveColor = Color.FromArgb(41, 41, 41);
            btnRefresh.Location = new Point(661, 621);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnRefresh.PressedColor = Color.FromArgb(255, 163, 26);
            btnRefresh.Size = new Size(213, 62);
            btnRefresh.TabIndex = 16;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextAlignment = StringAlignment.Center;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(btnRefresh);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(categoryCmbBox);
            Controls.Add(txtSearchQuery);
            Controls.Add(btnSearch);
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
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.PoisonDataGridView ProductsDataGrid;
        private ReaLTaiizor.Controls.Button btnCreate;
        private ReaLTaiizor.Controls.Button btnUpdate;
        private ReaLTaiizor.Controls.Button btnDelete;
        private ReaLTaiizor.Controls.Button btnSearch;
        private ReaLTaiizor.Controls.HopeTextBox txtSearchQuery;
        private ReaLTaiizor.Controls.DungeonComboBox categoryCmbBox;
        private Label label1;
        private Label label2;
        private ReaLTaiizor.Controls.Button btnRefresh;
    }
}
