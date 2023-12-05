using Documents_Graf.Interfaces;
using Documents_Graf.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents_Graf.Classes
{
    public class UserContext : User, IUser
    {
        public List<UserContext> AllUsers()
        {
            List<UserContext> allUsers = new List<UserContext>();

            OleDbConnection connection = Common.DBConnect.Connection();
            OleDbDataReader userDataDocuments = Common.DBConnect.Query("SELECT * FROM [Ответственные]", connection);
            while (userDataDocuments.Read())
            {
                UserContext newUser = new UserContext();
                newUser.id = userDataDocuments.GetInt32(0);
                newUser.name = userDataDocuments.GetString(1);

                allUsers.Add(newUser);
            }
            Common.DBConnect.CloseConnection(connection);

            return allUsers;
        }

        public void Save(bool Update = false)
        {
            if (Update)
            {
                OleDbConnection connection = Common.DBConnect.Connection();
                Common.DBConnect.Query("UPDATE [Ответственные] " +
                    "SET " +
                    $"[Ответственный] = '{this.name}' " +
                    $"WHERE [Код] = {this.id}", connection);
                Common.DBConnect.CloseConnection(connection);
            }
            else
            {
                OleDbConnection connection = Common.DBConnect.Connection();
                Common.DBConnect.Query("INSERT INTO " +
                    "[Ответственные]" +
                    "([Ответственный]) " +
                    "VALUES (" +
                    $"'{this.name}')", connection);
                Common.DBConnect.CloseConnection(connection);
            }
        }

        public void Delete()
        {
            OleDbConnection connection = Common.DBConnect.Connection();
            Common.DBConnect.Query($"DELETE FROM [Ответственные] WHERE [Код] = {this.id}", connection);
            Common.DBConnect.CloseConnection(connection);
        }
    }
}
