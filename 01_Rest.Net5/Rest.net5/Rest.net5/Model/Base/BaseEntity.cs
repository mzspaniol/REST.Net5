﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Rest.net5.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
