using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ColegioLibrarySystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=;database=library_db;";

            // ✅ Input validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter username and password");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT UserID, role FROM users WHERE username=@user AND password=@pass";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                    MySqlDataReader reader = cmd.ExecuteReader(); // ✅ CORRECT

                    if (reader.Read())
                    {

                        int id = Convert.ToInt32(reader["UserID"]);   // ✅ SAFE
                        string role = reader["role"].ToString();

                        

                        this.Hide();

                        if (role == "Admin")
                        {
                            AdminDashboard admin = new AdminDashboard();
                            admin.Show();
                        }
                        else if (role == "Student")
                        {
                            
                            StudentDashboard student = new StudentDashboard(id);
                            student.Show();
                        }
                        else if (role == "Instructor")
                        {
                           

                            InstructorDashboard instructor = new InstructorDashboard();
                            instructor.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");

                        txtPassword.Clear();
                        txtUsername.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}