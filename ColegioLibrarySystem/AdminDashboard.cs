using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ColegioLibrarySystem
{
    public partial class AdminDashboard : Form
    {
        string connStr = "server=localhost;user=root;password=;database=library_db;";

        public AdminDashboard()
        {
            InitializeComponent();
            LoadBooks();
            LoadCategories();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                    SELECT b.BookID, b.Title, b.Author, b.Year, 
                           b.TotalCopies, b.AvailableCopies, 
                           c.CategoryName
                    FROM books b
                    LEFT JOIN categories c ON b.CategoryID = c.CategoryID";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewBooks.DataSource = null;
                    dataGridViewBooks.DataSource = table;
                    dataGridViewBooks.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }

        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewBooks.Rows[e.RowIndex];

                txtTitle.Text = row.Cells["title"].Value.ToString();
                txtAuthor.Text = row.Cells["author"].Value.ToString();
                txtYear.Text = row.Cells["year"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["BookID"].Value);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "UPDATE books SET title=@title, author=@author, year=@year WHERE id=@id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text);
                    cmd.Parameters.AddWithValue("@year", txtYear.Text);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Book updated!");
                    LoadBooks();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["BookID"].Value);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "DELETE FROM books WHERE id=@id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Book deleted!");
                    LoadBooks();
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide(); // hide current dashboard

            LoginForm login = new LoginForm();
            login.Show(); // open login form
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Button clicked"); // confirm step 1

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    MessageBox.Show("DB connected"); // confirm step 2

                    string query = @"INSERT INTO books 
                                    (title, author, year, CategoryID, TotalCopies, AvailableCopies) 
                                    VALUES 
                                    (@title, @author, @year, @category, @total, @available)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text);
                    cmd.Parameters.AddWithValue("@year", txtYear.Text);
                    cmd.Parameters.AddWithValue("@category", cmbCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@total", numTotalCopies.Value);
                    cmd.Parameters.AddWithValue("@available", numTotalCopies.Value);

                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show("Rows affected: " + rows);

                    LoadBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}