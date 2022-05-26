﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Content { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

    }
}
    