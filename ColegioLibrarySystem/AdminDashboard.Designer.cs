namespace ColegioLibrarySystem
{
    partial class AdminDashboard
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
            label1 = new Label();
            btnLogout = new Button();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtYear = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAddBook = new Button();
            dataGridViewBooks = new DataGridView();
            btnUpdate = new Button();
            lblTitle = new Label();
            cmbCategory = new ComboBox();
            label5 = new Label();
            numTotalCopies = new NumericUpDown();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTotalCopies).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(624, 21);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 0;
            label1.Text = "Admin Dashboard";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(643, 44);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(72, 97);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(125, 27);
            txtTitle.TabIndex = 2;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(72, 169);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(125, 27);
            txtAuthor.TabIndex = 3;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(72, 244);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(125, 27);
            txtYear.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 74);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 5;
            label2.Text = "Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 146);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 6;
            label3.Text = "Author";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 221);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 7;
            label4.Text = "Year Published";
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(299, 169);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(94, 29);
            btnAddBook.TabIndex = 8;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(437, 97);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.RowHeadersWidth = 51;
            dataGridViewBooks.Size = new Size(300, 188);
            dataGridViewBooks.TabIndex = 9;
            dataGridViewBooks.CellClick += dataGridViewBooks_CellClick;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(299, 212);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update Book";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(18, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(309, 46);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Admin Dashboard";
            lblTitle.Click += label5_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(72, 311);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 12;
            cmbCategory.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 288);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 13;
            label5.Text = "Category";
            // 
            // numTotalCopies
            // 
            numTotalCopies.Location = new Point(73, 392);
            numTotalCopies.Name = "numTotalCopies";
            numTotalCopies.Size = new Size(150, 27);
            numTotalCopies.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(72, 369);
            label6.Name = "label6";
            label6.Size = new Size(91, 20);
            label6.TabIndex = 15;
            label6.Text = "Total Copies";
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(numTotalCopies);
            Controls.Add(label5);
            Controls.Add(cmbCategory);
            Controls.Add(lblTitle);
            Controls.Add(btnUpdate);
            Controls.Add(dataGridViewBooks);
            Controls.Add(btnAddBook);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtYear);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(btnLogout);
            Controls.Add(label1);
            Name = "AdminDashboard";
            Text = "AdminDashboard";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTotalCopies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnLogout;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtYear;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnAddBook;
        private DataGridView dataGridViewBooks;
        private Button btnUpdate;
        private Label lblTitle;
        private ComboBox cmbCategory;
        private Label label5;
        private NumericUpDown numTotalCopies;
        private Label label6;
    }
}