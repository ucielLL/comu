using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace Comu.Models
{
    [Table("CardData")]
    public class CardData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String pahtImage { get; set; }
        public String Description { get; set; }
       [ForeignKey (typeof(Collections))]
        public String Collection { get; set; }  

    }

}
