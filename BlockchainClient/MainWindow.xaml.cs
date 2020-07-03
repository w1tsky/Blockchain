using BlockchainClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlockchainClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UserRole UserRole;
        public string Login;
        

        public MainWindow(string login,  UserRole role)
        {
            InitializeComponent();
            CurrentUser.Text = login;
            CurrentUserRole.Text = role.ToString();
            UserRole = role;
            Login = login;

        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Home());
        }

        private void ManageChains_Click(object sender, RoutedEventArgs e)
        {
            if (UserRole == UserRole.Admin ) {
                mainFrame.Navigate(new ManageChains(Login,UserRole));
            }
            else if (UserRole == UserRole.Writer)
                mainFrame.Navigate(new ManageChains(Login,UserRole));
            else
            {
                MessageBox.Show("Вы не администратор");
            }
            
        }

        private void ManageUsers_Click(object sender, RoutedEventArgs e)
        {
            if (UserRole == UserRole.Admin)
            {
                mainFrame.Navigate(new ManageUsers());
            }
            else
            {
                MessageBox.Show("Вы не администратор");
            }
        }

        private void LogoutUsers_Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Close();
        }

        private void closeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void minimizeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
