using MyBlog.Contexts;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public void AddPost(Post post)
        {
            _context.Add(post);
        }

        public Post GetPost(int id) => _context.Posts.FirstOrDefault(p => p.Id == id);
        public List<Post> GetPosts() => _context.Posts.ToList();

        public void RemoverPost(int id)
        {
            var post = GetPost(id);
            _context.Posts.Remove(post);
        }

        public async Task<bool> SaveChanges()
        {
            if (await _context.SaveChangesAsync() > 0) {
                return true;
            }
            return false;
        }

        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
        }
    }
}
