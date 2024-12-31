using System.Windows;

namespace WpfApp6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Example Validation (Replace with actual authentication logic)
            if (username == "owner" && password == "1234")
            {
                // Open the dashboard window and close the login window
                DashboardWindow dashboard = new DashboardWindow();
                dashboard.Show();
                this.Close();
            }
            else
            {
                ErrorMessage.Text = "Invalid username or password!";
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}

