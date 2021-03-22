using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SongsAndVotesCommon.BusinessObjects
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("JOINED_IN")]
        public int? JoinedIn { get; set; }

        public IList<Playlist> Playlists { get; set; }
    }

    [Table("Playlist")]
    public class Playlist
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("PLAY_COUNT")]
        public int? PlayCount { get; set; }

        [Column("USER_PROFILE_ID")]
        public UserProfile UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
