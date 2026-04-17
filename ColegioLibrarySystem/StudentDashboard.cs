using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ColegioLibrarySystem
{
    public partial class StudentDashboard : Form
    {
        string connStr = "server=localhost;user=root;password=;database=library_db;";
        int userId;

        public StudentDashboard(int id)
        {
            InitializeComponent();
            userId = id;
            LoadBooks();
            LoadBorrowedBooks(); // ADD THIS
            this.AcceptButton = btnSearch;

        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadBooks();
            LoadBorrowedBooks();
        }

        // =========================
        // LOAD BOOKS (DEFAULT)
        // =========================
        private void LoadBooks()
        {
            LoadBooks("");
        }

        // =========================
        // LOAD BOOKS (WITH SEARCH)
        // =========================
        private void LoadBooks(string search)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    b.BookID,
                    b.Title,
                    b.Author,
                    c.CategoryName,
                    b.AvailableCopies
                FROM books b
                LEFT JOIN categories c ON b.CategoryID = c.CategoryID
                WHERE 1=1
            ";

                    // SEARCH filter
                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        query += @"
                    AND (
                        b.Title LIKE @search
                        OR b.Author LIKE @search
                        OR c.CategoryName LIKE @search
                        OR CAST(b.BookID AS CHAR) LIKE @search
                    )";
                    }

                    // CATEGORY filter
                    if (cmbCategory.SelectedValue != null &&
                        cmbCategory.SelectedValue is int &&
                        (int)cmbCategory.SelectedValue != 0)
                    {
                        query += " AND b.CategoryID = @category";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                    if (cmbCategory.SelectedValue != null &&
                        cmbCategory.SelectedValue is int &&
                        (int)cmbCategory.SelectedValue != 0)
                    {
                        cmd.Parameters.AddWithValue("@category", cmbCategory.SelectedValue);
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewBooks.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }

        }

        // =========================
        // BORROW BOOK
        // =========================
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                MessageBox.Show("Please select a book first.");
                return;
            }

            int bookId = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["BookID"].Value);
            string title = dataGridViewBooks.CurrentRow.Cells["Title"].Value.ToString();

            DateTime borrowDate = DateTime.Now;
            DateTime dueDate = CalculateDueDate(borrowDate, 7);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // check duplicate borrow
                    string checkQuery = @"SELECT COUNT(*) 
                        FROM borrow_records 
                        WHERE user_id=@user AND book_id=@book AND status='Borrowed'";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@user", userId);
                    checkCmd.Parameters.AddWithValue("@book", bookId);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("You already borrowed this book.");
                        return;
                    }

                    // check availability
                    string stockQuery = "SELECT AvailableCopies FROM books WHERE BookID=@book";

                    MySqlCommand stockCmd = new MySqlCommand(stockQuery, conn);
                    stockCmd.Parameters.AddWithValue("@book", bookId);

                    object result = stockCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Book not found.");
                        return;
                    }

                    int available = Convert.ToInt32(result);

                    if (available <= 0)
                    {
                        MessageBox.Show("No copies available.");
                        return;
                    }

                    // insert borrow
                    string insertQuery = @"INSERT INTO borrow_records 
                        (user_id, book_id, title, borrowed_date, due_date, status)
                        VALUES (@user, @book, @title, @date, @due, 'Borrowed')";

                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@user", userId);
                    cmd.Parameters.AddWithValue("@book", bookId);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@date", borrowDate);
                    cmd.Parameters.AddWithValue("@due", dueDate);

                    cmd.ExecuteNonQuery();

                    // decrease stock
                    string updateQuery = @"UPDATE books 
                        SET AvailableCopies = AvailableCopies - 1 
                        WHERE BookID=@book";

                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@book", bookId);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Book borrowed successfully!");
                    LoadBooks();
                    LoadBorrowedBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Borrow error: " + ex.Message);
            }
        }

        // =========================
        // RETURN BOOK
        // =========================
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrowedBooks.CurrentRow == null)
            {
                MessageBox.Show("Select a borrowed book first.");
                return;
            }

            int bookId = Convert.ToInt32(dataGridViewBorrowedBooks.CurrentRow.Cells["book_id"].Value);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 1. Find active borrow record for THIS user + book
                    string getQuery = @"
                SELECT id 
                FROM borrow_records 
                WHERE user_id=@user 
                AND book_id=@book 
                AND status='Borrowed'
                LIMIT 1";

                    MySqlCommand getCmd = new MySqlCommand(getQuery, conn);
                    getCmd.Parameters.AddWithValue("@user", userId);
                    getCmd.Parameters.AddWithValue("@book", bookId);

                    object result = getCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("No active borrow record found.");
                        return;
                    }

                    int borrowId = Convert.ToInt32(result);

                    // 2. Update borrow record
                    string updateBorrow = @"
                UPDATE borrow_records 
                SET status='Returned', return_date=NOW()
                WHERE id=@id";

                    MySqlCommand cmd1 = new MySqlCommand(updateBorrow, conn);
                    cmd1.Parameters.AddWithValue("@id", borrowId);
                    cmd1.ExecuteNonQuery();

                    // 3. Restore book stock
                    string updateBook = @"
                UPDATE books 
                SET AvailableCopies = AvailableCopies + 1 
                WHERE BookID=@book";

                    MySqlCommand cmd2 = new MySqlCommand(updateBook, conn);
                    cmd2.Parameters.AddWithValue("@book", bookId);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Book returned successfully!");

                    LoadBooks();
                    LoadBorrowedBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Return error: " + ex.Message);
            }
        }

        // =========================
        // SEARCH BUTTON (ADD THIS IN DESIGNER)
        // =========================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBooks(txtSearch.Text);
        }

        // =========================
        // LOGOUT
        // =========================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        // =========================
        // DUE DATE (7 WORKING DAYS)
        // =========================
        private DateTime CalculateDueDate(DateTime startDate, int workingDays)
        {
            DateTime date = startDate;
            int addedDays = 0;

            while (addedDays < workingDays)
            {
                date = date.AddDays(1);

                if (date.DayOfWeek != DayOfWeek.Saturday &&
                    date.DayOfWeek != DayOfWeek.Sunday)
                {
                    addedDays++;
                }
            }

            return date;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // stops the beep sound
                btnSearch.PerformClick();  // triggers your search button
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedValue == null) return;

            LoadBooks(txtSearch.Text);
        }
        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT CategoryID, CategoryName FROM categories";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Add "All Categories"
                    DataRow row = table.NewRow();
                    row["CategoryID"] = 0;
                    row["CategoryName"] = "All Categories";
                    table.Rows.InsertAt(row, 0);

                    cmbCategory.DataSource = table;
                    cmbCategory.DisplayMember = "CategoryName";
                    cmbCategory.ValueMember = "CategoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }
        private void FormatBookRows()
        {
            foreach (DataGridViewRow row in dataGridViewBooks.Rows)
            {
                if (row.Cells["AvailableCopies"].Value != null)
                {
                    int copies = Convert.ToInt32(row.Cells["AvailableCopies"].Value);

                    if (copies > 0)
                    {
                        // 🟢 Only the cell turns green
                        row.Cells["AvailableCopies"].Style.BackColor = System.Drawing.Color.Green;
                        row.Cells["AvailableCopies"].Style.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        // 🔴 Only the cell turns red
                        row.Cells["AvailableCopies"].Style.BackColor = System.Drawing.Color.Red;
                        row.Cells["AvailableCopies"].Style.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {

        }
        private void LoadBorrowedBooks()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    id,
                    book_id,
                    title,
                    borrowed_date,
                    due_date,
                    status,
                    return_date
                FROM borrow_records
                WHERE user_id = @user
                ORDER BY borrowed_date DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", userId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewBorrowedBooks.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrowed books: " + ex.Message);
            }
        }
    }
}