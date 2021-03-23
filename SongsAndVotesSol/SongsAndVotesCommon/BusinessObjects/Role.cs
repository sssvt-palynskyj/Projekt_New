using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SongsAndVotesCommon.BusinessObjects
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("NazevRole")]
        public string NazevRole { get; set; }
    }
}