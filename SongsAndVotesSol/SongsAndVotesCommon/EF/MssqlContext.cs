using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SongsAndVotesCommon.BusinessObjects;
using SongsAndVotesCommon.Repos;

namespace SongsAndVotesCommon.EF
{
    public class MssqlContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        public MssqlContext() :  base("name=SongsAndVotesCommon.Properties.Settings.SongsAndVotesUsersConnectionString")
        {
            Database.SetInitializer<MssqlContext>(null);
        }
    }
}
