using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColumnAttribute = SQLite.ColumnAttribute;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace TakeNote.Models
{
    [Table("Notes")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string Description { get; set; }
        public string Title { get; set; }


        [ForeignKey(typeof(Board))]
        public int boardID { get; set; }

        [ManyToOne]
        public virtual Board board { get; set; }

    }
}
