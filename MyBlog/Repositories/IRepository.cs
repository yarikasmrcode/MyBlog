using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repositories
{
    public interface IRepository
    {
        public Post GetPost(int id);
        public List<Post> GetPosts();
        public void AddPost(Post post);
        public void UpdatePost(Post post);
        public void RemoverPost(int id);
        public List<Comment> GetComments();
        public Task<bool> SaveChanges();
        public void AddComment(Comment comment);
    }
}
