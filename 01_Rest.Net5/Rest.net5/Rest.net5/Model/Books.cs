using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.net5.Controllers.Model
{
    [Table("books")]
    public class Books
    {
        [Column("id")]
        public long Id { get; set; }
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
