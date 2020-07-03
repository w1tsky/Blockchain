using BlockchainClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : UserControl
    {



        public List<User> Users;
   
        




        public ManageUsers()
        {
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())
            {
                db.BlockchainUser.Load();
                Users = db.BlockchainUser.Local.ToList();
                UserList.ItemsSource = Users;
            }
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                var u = (User)UserList.SelectedItem;
                if (u != null)
                {

                    User user = db.BlockchainUser.Find(u.UserID);
                    UserDetails.DataContext = user;
                }
            }

        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                CreateUserWindow createUserWindow = new CreateUserWindow();
                createUserWindow.DataContext = this;
                if (createUserWindow.ShowDialog() == true)
                {

                    string login = createUserWindow.Login;
                    string password = createUserWindow.Password;
                    UserRole role = createUserWindow.Role;
                    string userData = createUserWindow.UserData;



                    db.BlockchainUser.Add(new User(login,password,role,userData));
                    db.SaveChanges();
                    db.BlockchainUser.Load();
                    Users = db.BlockchainUser.Local.ToList();
                    UserList.ItemsSource = Users;

                }
            }
        }


        private void removeUserButton_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var u = (User)UserList.SelectedItem;

                if (u != null)
                {
                    db.BlockchainUser.Remove(u);
                    db.BlockchainUser.Load();
                    Users = db.BlockchainUser.Local.ToList();
                    UserList.ItemsSource = Users;
                    db.SaveChanges();

                    MessageBox.Show("Пользователь удален");
                }
                else
                {
                    MessageBox.Show("Добавьте пользователя");
                }

            }
        }
    }
}


