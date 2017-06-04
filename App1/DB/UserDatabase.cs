using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using System.Collections.ObjectModel;

namespace App1
{
    
    public class UserDatabase
    {
        public SQLiteConnection con;
        public UserDatabase(string dbname)
        {
            this.con = new SQLiteConnection(dbname);
        }
        public void CreateTable()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS
                                Users (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
                                        login VARCHAR(20),
                                        pass VARCHAR(20),
                                        role VARCHAR(5));";
            using (var statement = con.Prepare(sql))
            {
                statement.Step();
            }
        }

        public void Insert(User user)
        {
            using (var statement = con.Prepare("INSERT INTO Users(login, pass, role) VALUES (?,?,?)"))
            {
                statement.Bind(1, user.Login);
                statement.Bind(2, user.Pass);
                statement.Bind(3, user.Role);
                statement.Step();
            }
        }

        public ObservableCollection<User> GetUsers()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();

            using (var statement = con.Prepare("SELECT Id, Name, Author, Year FROM Users"))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    User user = new User();
                    user.Id = (long)statement[0];
                    user.Login = (string)statement[1];
                    user.Pass = (string)statement[2];
                    user.Role = (string)statement[3];
                    users.Add(user);
                }
            }
            return users;
        }

        public User GetUser(long id)
        {
            User user = null;

            using (var statement = con.Prepare("SELECT Id, Login, Pass, Role FROM Users WHERE Login=?"))
            {
                statement.Bind(1, id);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    user = new User();
                    user.Id = (long)statement[0];
                    user.Login = (string)statement[1];
                    user.Pass = (string)statement[2];
                    user.Role = (string)statement[3];
                }
            }

            return user;
        }

        public void Update(User user)
        {
            using (var statement = con.Prepare("UPDATE Users SET Name=?, Author=?, Year=? WHERE Id=?"))
            {
                statement.Bind(1, user.Login);
                statement.Bind(2, user.Pass);
                statement.Bind(3, user.Role);
                statement.Bind(4, user.Id);
                statement.Step();
            }
        }

        public void Delete(long id)
        {
            using (var statement = con.Prepare("DELETE FROM Users WHERE Id=?"))
            {
                statement.Bind(1, id);
                statement.Step();
            }
        }
    }
}
