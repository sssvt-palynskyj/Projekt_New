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
    class UserRepoMssql : IUserRepo
    {


        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public SqlConnection ConnectToDatabase()
        {
            throw new NotImplementedException();
        }

        public bool Exists(User user)
        {
            throw new NotImplementedException();
        }

        public IList<User> FindList(User user)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetList()
        {
            using ( var context = new MssqlContext())
            {
                var querry = from f in context.Users
                             select f;
                var users = querry.ToList<User>();

                return users;
            }
        }

        public User Load(User user)
        {
            throw new NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new NotImplementedException();
        }

        public void Store(User user)
        {
            throw new NotImplementedException();
        }
    }
}
