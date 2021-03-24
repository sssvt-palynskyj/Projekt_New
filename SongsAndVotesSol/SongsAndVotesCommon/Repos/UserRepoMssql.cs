using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SongsAndVotesCommon.BusinessObjects;
using SongsAndVotesCommon.EF;
using SongsAndVotesCommon.Interfaces;
using System.Data.SqlClient;

namespace SongsAndVotesCommon.Repos
{
    public class UserRepoMssql : IUserRepo
    {
        MssqlContext mssqlContext = new MssqlContext();

        public SqlConnection ConnectToDatabase()
        {
            SqlConnection connection = new SqlConnection(UserRepo.connectionString);
            return connection;
        }

        public IList<User> GetList()
        {
            using (var context = new MssqlContext())
            {
                var querry = from f in context.Users
                             select f;
                var users = querry.ToList<User>();

                return users;
            }
        }

        public void Add(User user)
        {
            mssqlContext.Users.Add(user); //prida do "underlying context"
            mssqlContext.Users.Attach(user); //nic nezapíše do databáze ale prida do "underlying context"
            mssqlContext.Entry(user).State = EntityState.Added; // umozni za/pre pisovat ???
            mssqlContext.SaveChanges(); // z "underlying context" ulozi do databaze
        }

        public void Remove(User user)
        {
            mssqlContext.Users.Remove(user); //oznaci jako deleted, musi se attachnout pred .savechanges
            //mssqlContext.Users.Attach(user); 
            mssqlContext.Entry(user).State = EntityState.Deleted;
            mssqlContext.SaveChanges();
        }

        public bool Exists(User user)
        {
            if(mssqlContext.Users.Find(user) == null)
//System.InvalidOperationException: No connection string named 'SongsAndVotesCommon.Properties.Settings.SongsAndVotesUsersConnectionString' could be found in the application config file.
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IList<User> FindList(User user)
        {
            using (var context = new MssqlContext())
            {
                var querry = from f in context.Users
                             where Exists(user) == true
                             select f;
                var users = querry.ToList<User>();

                return users;
            }
        }

        public User Load(User user)
        {
            //mssqlContext.Users.Load();
            throw new NotImplementedException();
        }

        public void Store(User user)
        {
            throw new NotImplementedException();
        }
    }
}
