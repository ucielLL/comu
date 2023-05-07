using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Comu.Models
{
    [Table ("Collections")]
      public class Collections
    {
        [PrimaryKey]
        public string NameCollection { get; set;}
        public String Color { get; set; }

       [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<CardData> List { get; set;}  
       
    }
}
