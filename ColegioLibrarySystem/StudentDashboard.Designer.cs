namespace ColegioLibrarySystem
{
    partial class StudentDashboard
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
            dataGridViewBooks = new DataGridView();
            btnBorrow = new Button();
            numQuantity = new NumericUpDown();
            btnReturn = new Button();
            btnLogout = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            cmbCategory = new ComboBox();
            dataGridViewBorrowedBooks = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBorrowedBooks).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(12, 86);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.RowHeadersWidth = 51;
            dataGridViewBooks.Size = new Size(434, 284);
            dataGridViewBooks.TabIndex = 0;
            // 
            // btnBorrow
            // 
            btnBorrow.Location = new Point(173, 374);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(94, 29);
            btnBorrow.TabIndex = 1;
            btnBorrow.Text = "Borrow Book";
            btnBorrow.UseVisualStyleBackColor = true;
            btnBorrow.Click += btnBorrow_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(273, 376);
            numQuantity.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(37, 27);
            numQuantity.TabIndex = 2;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.ValueChanged += numQuantity_ValueChanged;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(611, 377);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(94, 29);
            btnReturn.TabIndex = 3;
            btnReturn.Text = "Return Book";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += button1_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(611, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout Button";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(126, 53);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(184, 27);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(316, 53);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            btnSearch.KeyDown += btnSearch_KeyDown;
            // 
            // cmbCategory
            // 
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(16, 463);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 7;
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // dataGridViewBorrowedBooks
            // 
            dataGridViewBorrowedBooks.AllowUserToAddRows = false;
            dataGridViewBorrowedBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBorrowedBooks.Location = new Point(452, 86);
            dataGridViewBorrowedBooks.Name = "dataGridViewBorrowedBooks";
            dataGridViewBorrowedBooks.ReadOnly = true;
            dataGridViewBorrowedBooks.RowHeadersWidth = 51;
            dataGridViewBorrowedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBorrowedBooks.Size = new Size(264, 284);
            dataGridViewBorrowedBooks.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 42);
            label1.Name = "label1";
            label1.Size = new Size(103, 41);
            label1.TabIndex = 9;
            label1.Text = "Books";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(452, 57);
            label2.Name = "label2";
            label2.Size = new Size(142, 23);
            label2.TabIndex = 10;
            label2.Text = "Books Borrowed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(452, 380);
            label3.Name = "label3";
            label3.Size = new Size(149, 17);
            label3.TabIndex = 11;
            label3.Text = "Select a book to return";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 381);
            label4.Name = "label4";
            label4.Size = new Size(155, 17);
            label4.TabIndex = 12;
            label4.Text = "Select a book to borrow";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 406);
            label5.Name = "label5";
            label5.Size = new Size(260, 17);
            label5.TabIndex = 13;
            label5.Text = "Student can only borrow 1 book for each title";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(16, 443);
            label6.Name = "label6";
            label6.Size = new Size(102, 17);
            label6.TabIndex = 14;
            label6.Text = "Select category";
            // 
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 509);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewBorrowedBooks);
            Controls.Add(cmbCategory);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnLogout);
            Controls.Add(btnReturn);
            Controls.Add(numQuantity);
            Controls.Add(btnBorrow);
            Controls.Add(dataGridViewBooks);
            Name = "StudentDashboard";
            Text = "StudentDashboard";
            Load += StudentDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBorrowedBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewBooks;
        private Button btnBorrow;
        private NumericUpDown numQuantity;
        private Button btnReturn;
        private Button btnLogout;
        private TextBox txtSearch;
        private Button btnSearch;
        private ComboBox cmbCategory;
        private DataGridView dataGridViewBorrowedBooks;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}