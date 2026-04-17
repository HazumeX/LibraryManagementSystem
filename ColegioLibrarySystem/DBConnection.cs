using MySql.Data.MySqlClient;

public class DBConnection
{
    public static MySqlConnection GetConnection()
    {
        string connString = "server=localhost;user id=root;password=;database=library_db;";
        return new MySqlConnection(connString);
    }
}