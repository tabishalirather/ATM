using System.Data.SqlClient;
using System.Windows;

namespace ATMApp
{
    public partial class DatabaseForm : Window
    {
        public DatabaseForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionString = "Your Connection String Here";
            string query = "SELECT * FROM Customers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    txtCardNumber.Text = reader["CardNumber"].ToString();
                    txtPIN.Password = reader["PIN"].ToString();
                }

                reader.Close();
            }
        }
    }
}