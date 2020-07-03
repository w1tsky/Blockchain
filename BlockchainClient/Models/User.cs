using System;
using System.Collections.Generic;
using System.Text;

namespace BlockchainClient.Models
{

    public class User
    {


        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public string UserData { get; set; }
        public string Hash { get; set; }
        




        public User(string login, string password, UserRole role, string userData)
        {
            Login = login;
            Password = password;
            Role = role;
            UserData = userData;
            Hash = Hash;
        }




        public override string ToString()
        {
            return Login;
        }

        /// <summary>
        /// Получить текущего пользователя системы.
        /// </summary>
        /// <returns> Текущий пользователь системы. </returns>
        public static User GetCurrentUser()
        {
            return new User("admin", "admin", UserRole.Admin,"Admin User");
        }

        /// <summary>
        /// Получить данные из объекта, на основе которых будет строиться хеш.
        /// </summary>
        /// <returns> Хешируемые данные. </returns>
        public string GetStringForHash()
        {
            var text = Login;
            text += (int)Role;

            return text;
        }


        public Data GetData()
        {
            var data = new Data(UserData, DataType.User);
            return data;
        }


    }
}