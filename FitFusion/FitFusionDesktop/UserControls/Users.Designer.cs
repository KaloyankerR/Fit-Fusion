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
            roleCmbBox = new ReaLTaiizor.Controls.DungeonComboBox();
            btnDelete = new ReaLTaiizor.Controls.Button();
            btnUpdate = new ReaLTaiizor.Controls.Button();
            btnCreate = new ReaLTaiizor.Controls.Button();
            txtSearchQuery = new ReaLTaiizor.Controls.HopeTextBox();
            btnSearch = new ReaLTaiizor.Controls.Button();
            btnRecommendations = new ReaLTaiizor.Controls.Button();
            label1 = new Label();
            label2 = new Label();
            btnRefresh = new ReaLTaiizor.Controls.Button();
            label3 = new Label();
            sortCmbBox = new ReaLTaiizor.Controls.DungeonComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)UsersDataGrid).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
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
            UsersDataGrid.Location = new Point(0, 0);
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
            UsersDataGrid.Size = new Size(932, 454);
            UsersDataGrid.TabIndex = 2;
            // 
            // roleCmbBox
            // 
            roleCmbBox.BackColor = Color.FromArgb(41, 41, 41);
            roleCmbBox.ColorA = Color.FromArgb(255, 163, 26);
            roleCmbBox.ColorB = Color.FromArgb(255, 163, 26);
            roleCmbBox.ColorC = Color.FromArgb(41, 41, 41);
            roleCmbBox.ColorD = Color.FromArgb(41, 41, 41);
            roleCmbBox.ColorE = Color.FromArgb(41, 41, 41);
            roleCmbBox.ColorF = Color.FromArgb(41, 41, 41);
            roleCmbBox.ColorG = Color.FromArgb(255, 163, 26);
            roleCmbBox.ColorH = Color.FromArgb(41, 41, 41);
            roleCmbBox.ColorI = Color.FromArgb(41, 41, 41);
            roleCmbBox.DrawMode = DrawMode.OwnerDrawFixed;
            roleCmbBox.DropDownHeight = 100;
            roleCmbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roleCmbBox.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            roleCmbBox.ForeColor = Color.FromArgb(255, 163, 26);
            roleCmbBox.FormattingEnabled = true;
            roleCmbBox.HoverSelectionColor = Color.Empty;
            roleCmbBox.IntegralHeight = false;
            roleCmbBox.ItemHeight = 20;
            roleCmbBox.Items.AddRange(new object[] { "Owners", "Staff", "Customers" });
            roleCmbBox.Location = new Point(120, 19);
            roleCmbBox.Name = "roleCmbBox";
            roleCmbBox.Size = new Size(191, 26);
            roleCmbBox.StartIndex = 0;
            roleCmbBox.TabIndex = 3;
            roleCmbBox.SelectedIndexChanged += roleCmbBox_SelectedIndexChanged;
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
            btnDelete.Location = new Point(6, 147);
            btnDelete.Name = "btnDelete";
            btnDelete.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnDelete.PressedColor = Color.FromArgb(255, 163, 26);
            btnDelete.Size = new Size(150, 50);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.TextAlignment = StringAlignment.Center;
            btnDelete.Click += btnDelete_Click;
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
            btnUpdate.Location = new Point(6, 91);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnUpdate.PressedColor = Color.FromArgb(255, 163, 26);
            btnUpdate.Size = new Size(150, 50);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.TextAlignment = StringAlignment.Center;
            btnUpdate.Click += btnUpdate_Click;
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
            btnCreate.Location = new Point(6, 35);
            btnCreate.Name = "btnCreate";
            btnCreate.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnCreate.PressedColor = Color.FromArgb(255, 163, 26);
            btnCreate.Size = new Size(150, 50);
            btnCreate.TabIndex = 7;
            btnCreate.Text = "Create";
            btnCreate.TextAlignment = StringAlignment.Center;
            btnCreate.Click += btnCreate_Click;
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
            txtSearchQuery.Location = new Point(120, 95);
            txtSearchQuery.MaxLength = 32767;
            txtSearchQuery.Multiline = false;
            txtSearchQuery.Name = "txtSearchQuery";
            txtSearchQuery.PasswordChar = '\0';
            txtSearchQuery.ScrollBars = ScrollBars.None;
            txtSearchQuery.SelectedText = "";
            txtSearchQuery.SelectionLength = 0;
            txtSearchQuery.SelectionStart = 0;
            txtSearchQuery.Size = new Size(191, 43);
            txtSearchQuery.TabIndex = 11;
            txtSearchQuery.TabStop = false;
            txtSearchQuery.UseSystemPasswordChar = false;
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
            btnSearch.Location = new Point(6, 154);
            btnSearch.Name = "btnSearch";
            btnSearch.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnSearch.PressedColor = Color.FromArgb(255, 163, 26);
            btnSearch.Size = new Size(307, 43);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Search";
            btnSearch.TextAlignment = StringAlignment.Center;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRecommendations
            // 
            btnRecommendations.BackColor = Color.Gray;
            btnRecommendations.BorderColor = Color.FromArgb(41, 41, 41);
            btnRecommendations.Cursor = Cursors.Hand;
            btnRecommendations.EnteredBorderColor = Color.FromArgb(255, 163, 26);
            btnRecommendations.EnteredColor = Color.FromArgb(41, 41, 41);
            btnRecommendations.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRecommendations.Image = null;
            btnRecommendations.ImageAlign = ContentAlignment.MiddleLeft;
            btnRecommendations.InactiveColor = Color.FromArgb(41, 41, 41);
            btnRecommendations.Location = new Point(6, 106);
            btnRecommendations.Name = "btnRecommendations";
            btnRecommendations.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnRecommendations.PressedColor = Color.FromArgb(255, 163, 26);
            btnRecommendations.Size = new Size(218, 62);
            btnRecommendations.TabIndex = 12;
            btnRecommendations.Text = "Get Recommendations";
            btnRecommendations.TextAlignment = StringAlignment.Center;
            btnRecommendations.Click += btnRecommendations_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(4, 17);
            label1.Name = "label1";
            label1.Size = new Size(56, 23);
            label1.TabIndex = 13;
            label1.Text = "Role:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(4, 106);
            label2.Name = "label2";
            label2.Size = new Size(108, 23);
            label2.TabIndex = 14;
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
            btnRefresh.Location = new Point(6, 35);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.PressedBorderColor = Color.FromArgb(255, 163, 26);
            btnRefresh.PressedColor = Color.FromArgb(255, 163, 26);
            btnRefresh.Size = new Size(218, 62);
            btnRefresh.TabIndex = 15;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextAlignment = StringAlignment.Center;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(6, 62);
            label3.Name = "label3";
            label3.Size = new Size(80, 23);
            label3.TabIndex = 17;
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
            sortCmbBox.Items.AddRange(new object[] { "Owners", "Staff", "Customers" });
            sortCmbBox.Location = new Point(120, 59);
            sortCmbBox.Name = "sortCmbBox";
            sortCmbBox.Size = new Size(191, 26);
            sortCmbBox.StartIndex = 0;
            sortCmbBox.TabIndex = 16;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(roleCmbBox);
            groupBox1.Controls.Add(sortCmbBox);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearchQuery);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(14, 460);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(326, 227);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnCreate);
            groupBox2.Controls.Add(btnUpdate);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Location = new Point(346, 460);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(167, 227);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnRefresh);
            groupBox3.Controls.Add(btnRecommendations);
            groupBox3.Location = new Point(519, 460);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(230, 185);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(559, 664);
            label4.Name = "label4";
            label4.Size = new Size(359, 23);
            label4.TabIndex = 16;
            label4.Text = "Only Customers have recommendations";
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(label4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(UsersDataGrid);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Users";
            Size = new Size(932, 703);
            ((System.ComponentModel.ISupportInitialize)UsersDataGrid).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ReaLTaiizor.Controls.PoisonDataGridView UsersDataGrid;
        private ReaLTaiizor.Controls.DungeonComboBox roleCmbBox;
        private ReaLTaiizor.Controls.Button btnDelete;
        private ReaLTaiizor.Controls.Button btnUpdate;
        private ReaLTaiizor.Controls.Button btnCreate;
        private ReaLTaiizor.Controls.HopeTextBox txtSearchQuery;
        private ReaLTaiizor.Controls.Button btnSearch;
        private ReaLTaiizor.Controls.Button btnRecommendations;
        private Label label1;
        private Label label2;
        private ReaLTaiizor.Controls.Button btnRefresh;
        private Label label3;
        private ReaLTaiizor.Controls.DungeonComboBox sortCmbBox;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label4;
    }
}
