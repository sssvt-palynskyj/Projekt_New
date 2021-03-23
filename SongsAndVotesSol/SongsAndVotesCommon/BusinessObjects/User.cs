using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SongsAndVotesCommon.BusinessObjects
{
    [Table("UserData")]
    /// <summary>
    /// Represents a user in the SongsAndVotes app.
    /// </summary>
    public class User
    {
        [Column("Username")]
        public string Username { get; set; }

        [Column("UserPassword")]
        public string Password { internal get; set; }

        [Key]
        [Column("ID")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column("CisloRole")]
        public string CisloRole { get; set; }

        public User(string username, string password, int ID, string cisloRole)
        {
            this.Username = username;
            this.Password = password;
            this.ID = ID;
            this.CisloRole = cisloRole;
        }
        public User()
        {

        }

        [NotMapped]
        public UserProfile UserProfile { get; set; }




        public override string ToString()
        {
            return $"Username: {Username}";
        }

        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                User objUser = (User)obj;
                return objUser.Username == Username;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }

        public static bool operator == (User user1, User user2)
        {
            if ((user1 == null) && (user2 == null))
            {
                return true;
            }
            if ((user1 == null) || (user2 == null))
            {
                return false;
            }
            return user1.Equals(user2);
        }

        public static bool operator != (User user1, User user2)
        {
            return !(user1 == user2);
        }
    }
}
