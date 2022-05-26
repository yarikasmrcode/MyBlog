using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class AppUser : IdentityUser
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}
