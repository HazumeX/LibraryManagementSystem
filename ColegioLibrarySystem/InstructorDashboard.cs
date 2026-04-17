using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ColegioLibrarySystem
{
    public partial class InstructorDashboard : Form
    {
        string connStr = "server=localhost;user=root;password=;database=library_db;";

        public InstructorDashboard()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void InstructorDashboard_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Form loaded");
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                MySqlConnection conn =
                    new MySqlConnection(connStr);

                conn.Open();

                string query = "SELECT * FROM books WHERE title LIKE @search OR author LIKE @search";

                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(query, conn);

                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridViewBooks.DataSource = table;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide(); // hide current dashboard

            LoginForm login = new LoginForm();
            login.Show(); // open login form
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadBooks();
                e.SuppressKeyPress = true;
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                MessageBox.Show("Please select a book");
                return;
            }

            int quantity = (int)numQuantity.Value;

            int bookId = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells[0].Value);
            string title = dataGridViewBooks.CurrentRow.Cells["title"].Value.ToString();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 1. Insert borrow record
                    string query = "INSERT INTO borrow_records (book_id, title, quantity) VALUES (@book_id, @title, @quantity)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@book_id", bookId);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@quantity", quantity);

                    cmd.ExecuteNonQuery();

                    // 2. Update available copies
                    string updateQuery = "UPDATE books SET AvailableCopies = AvailableCopies - @qty WHERE BookID = @id AND AvailableCopies >= @qty";

                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@qty", quantity);
                    updateCmd.Parameters.AddWithValue("@id", bookId);

                    int rows = updateCmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        MessageBox.Show("Not enough available copies!");
                    }
                    else
                    {
                        MessageBox.Show("Book borrowed successfully!");
                        LoadBooks();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}