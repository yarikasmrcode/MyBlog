using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public AppUser MyProperty { get; set; }
    }
}
