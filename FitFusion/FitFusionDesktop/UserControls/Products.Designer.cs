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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            label3 = new Label();
            sortCmbBox = new ReaLTaiizor.Controls.DungeonComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)ProductsDataGrid).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            ProductsDataGrid.Location = new Point(3, 3);
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
            btnCreate.Location = new Point(11, 19);
            btnCreate.Name = "btnCreate";
            btnCreate.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnCreate.PressedColor = Color.FromArgb(255, 163, 26);
            btnCreate.Size = new Size(150, 71);
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
            btnUpdate.Location = new Point(167, 19);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnUpdate.PressedColor = Color.FromArgb(255, 163, 26);
            btnUpdate.Size = new Size(150, 71);
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
            btnDelete.Location = new Point(11, 96);
            btnDelete.Name = "btnDelete";
            btnDelete.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnDelete.PressedColor = Color.FromArgb(255, 163, 26);
            btnDelete.Size = new Size(150, 71);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.TextAlignment = StringAlignment.Center;
            btnDelete.Click += btnDelete_Click;
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
            btnSearch.Location = new Point(6, 135);
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
            txtSearchQuery.Location = new Point(166, 83);
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
            categoryCmbBox.Location = new Point(166, 19);
            categoryCmbBox.Name = "categoryCmbBox";
            categoryCmbBox.Size = new Size(191, 26);
            categoryCmbBox.StartIndex = 0;
            categoryCmbBox.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(97, 23);
            label1.TabIndex = 14;
            label1.Text = "Category:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(6, 87);
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
            btnRefresh.Location = new Point(167, 96);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnRefresh.PressedColor = Color.FromArgb(255, 163, 26);
            btnRefresh.Size = new Size(150, 71);
            btnRefresh.TabIndex = 16;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextAlignment = StringAlignment.Center;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(6, 51);
            label3.Name = "label3";
            label3.Size = new Size(80, 23);
            label3.TabIndex = 18;
            label3.Text = "Sort by:";
            // 
            // sortCmbBox
            // 
            sortCmbBox.BackColor = Color.FromArgb(41, 41, 41);
            sortCmbBox.ColorA = Color.FromArgb(255, 163, 26);
            sortCmbBox.ColorB = Color.FromArgb(255, 163, 26);
            sortCmbBox.ColorC = Color.FromArgb(41, 41, 41);
            sortCmbBox.ColorD = Color.FromArgb(41, 41, 41);
            sortCmbBox.ColorE = Color.FromArgb(41, 41, 41);
            sortCmbBox.ColorF = Color.FromArgb(41, 41, 41);
            sortCmbBox.ColorG = Color.FromArgb(255, 163, 26);
            sortCmbBox.ColorH = Color.FromArgb(41, 41, 41);
            sortCmbBox.ColorI = Color.FromArgb(41, 41, 41);
            sortCmbBox.DrawMode = DrawMode.OwnerDrawFixed;
            sortCmbBox.DropDownHeight = 100;
            sortCmbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sortCmbBox.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            sortCmbBox.ForeColor = Color.FromArgb(255, 163, 26);
            sortCmbBox.FormattingEnabled = true;
            sortCmbBox.HoverSelectionColor = Color.Empty;
            sortCmbBox.IntegralHeight = false;
            sortCmbBox.ItemHeight = 20;
            sortCmbBox.Location = new Point(166, 51);
            sortCmbBox.Name = "sortCmbBox";
            sortCmbBox.Size = new Size(191, 26);
            sortCmbBox.StartIndex = 0;
            sortCmbBox.TabIndex = 17;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Location = new Point(587, 512);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(326, 178);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btnSearch);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtSearchQuery);
            groupBox2.Controls.Add(sortCmbBox);
            groupBox2.Controls.Add(categoryCmbBox);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(15, 505);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(365, 185);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(ProductsDataGrid);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Products";
            Size = new Size(932, 703);
            ((System.ComponentModel.ISupportInitialize)ProductsDataGrid).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
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
        private Label label3;
        private ReaLTaiizor.Controls.DungeonComboBox sortCmbBox;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
