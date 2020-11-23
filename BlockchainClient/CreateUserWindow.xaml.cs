using BlockchainClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {

        public UserRole Roles;

    
        


        public CreateUserWindow()
        {
         
           
            InitializeComponent();
        }

        public string Login
        {
            get { return LoginBox.Text; }
        }

        public string Password
        {
            get { return PasswordBox.Text; }
        }


        public string UserData
        {

            get { return UserDataBox.Text; }
        }

        public UserRole Role
        {
            get 
            {
                var u = (UserRole)usersRoleList.SelectedItem;
                return u;
      
              }
        }



  

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
