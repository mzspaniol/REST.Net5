using Rest.net5.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rest.net5.Controllers.Model
{
    [Table("books")]
    public class Books: BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("launch_date")]
        public DateTime Launch_date { get; set; }
        [Column("price")]
        public decimal Price { get; set; }


    }
}
