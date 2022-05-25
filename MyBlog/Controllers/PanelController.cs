using Microsoft.AspNetCore.Mvc;
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
            return View(_repository.GetPost(id));
        }
    }
}
