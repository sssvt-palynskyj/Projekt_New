using System;
using System.Collections.Generic;
using System.IO;

using SongsAndVotesCommon.BusinessObjects;
using SongsAndVotesCommon.Factories;
using SongsAndVotesCommon.Interfaces;

using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace SongsAndVotesCommon.Repos
{



    /// <summary>
    /// Provides database access to user-related data.
    /// </summary>
    public class UserRepo : IUserRepo
    {
        /// <summary>Database table with user info.</summary>
        private const string RepoFile = @"..\..\..\Resources\Database\User.csv";

        /// <summary>Use this delimiter in the the repo.</summary>
        private const char Delimiter = ';';

        /// <summary>Header line in the repo.</summary>
        private const string HeaderLine = "Username;Password";


        //-------------------------------------------------------------------------------------------
        public const string connectionString = "Server=localhost; Database=SongsAndVotesUsers; Integrated Security=true";
        public SqlConnection ConnectToDatabase()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public void TestDatabase()
        {
            SqlConnection sqlConnection = ConnectToDatabase();
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("Select * from UserData", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }

            SqlCommand sqlCommand = new SqlCommand("Insert ...", sqlConnection);
            ///sql
        }
        //-------------------------------------------------------------------------------------------

        public IList<User> GetList()
        {
            string SelectAllUsernames = "Select Username from UserData";
            using (SqlCommand sqlCommand = new SqlCommand(SelectAllUsernames, ConnectToDatabase()))
            {
                IList<User> MatchingUserName = new List<User> { };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int i = 0;
                while (sqlDataReader.Read())
                {
                    i++;
                    User MatchingUser = new User(sqlDataReader.GetString(i), null, 0, null);
                    User user = new User(null);
                    MatchingUserName.Add(MatchingUser);
                }
                return MatchingUserName;
            }
        }

        public IList<User> FindList(User user)
        {
            string SelectMatchingUser = "Select Username from UserData where Username = " + Convert.ToString(user.Username);
            using (SqlCommand sqlCommand = new SqlCommand(SelectMatchingUser, ConnectToDatabase()))
            {
                IList<User> MatchingUsers = new List<User> { };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int i = 0;
                while (sqlDataReader.Read())
                {
                    i++;
                    User MatchingUser = new User(sqlDataReader.GetString(i), null);
                    MatchingUsers.Add(MatchingUser);
                }
                return MatchingUsers;
            }
        }

        public bool Exists(User user)
        {
            string UserExists = "Select COUNT(Username) from UserData where Username ='" + user.Username +
                "' and Password ='" + user.Password + "'";
            using (SqlCommand sqlCommand = new SqlCommand(UserExists, ConnectToDatabase()))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(UserExists, ConnectToDatabase());
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows[0][0].ToString() == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public User Load(User user)
        {
            if (Exists(user) == true)
            {
                return (User)FindList(user);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void Store(User user)
        {

        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks with the database whether there is a given user with a given password.
        /// </summary>
        /// <param name="user">User to check for.</param>
        /// <returns>Returns true :-: the given combination of username/password is valid, false :-: the username and/or password are wrong.</returns>
        public bool CheckUsernameAndPassword(User user)
        {
            throw new NotImplementedException();
        }
    }



}
