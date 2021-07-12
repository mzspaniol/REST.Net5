using System;

namespace Rest.net5.Data.VO
{
    public class BooksVO
    {
        public long Id { get; set; }
        public string Author { get; set; }

        public string Title { get; set; }

        public DateTime Launch_date { get; set; }

        public decimal Price { get; set; }

    }
}

