using Microsoft.AspNetCore.Mvc;
using MyBlog.Contexts;
using MyBlog.Models;
using MyBlog.Models.ViewModels;
using MyBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class PanelController : Controller
    {
        private readonly IRepository _repository;
        public PanelController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SeePosts()
        {
            return View(_repository.GetPosts());
        }

        [HttpGet]
        public IActionResult Read(int id)
        {
            var post = _repository.GetPost(id);

            return View(new PostCommentViewModel()
            {
                Post = post,
                Comments = _repository.GetComments().Where(p => p.PostId == id).ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            _repository.AddComment(comment);
            await _repository.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
