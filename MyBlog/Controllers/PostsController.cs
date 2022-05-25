using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IRepository _repository;
        public PostsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repository.GetPosts());
        }

        [HttpGet]
        public IActionResult Read(int id)
        {
            var post = _repository.GetPost(id);

            if (post == null){
                return NotFound();
            }

            return View(post);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post model)
        {
            if (ModelState.IsValid) {
                _repository.AddPost(model);
                await _repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _repository.GetPost(id);

            if (post == null) {
                return NotFound();
            }

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post model)
        {
            if (ModelState.IsValid) {
                _repository.UpdatePost(model);
                await _repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _repository.RemoverPost(id);
            await _repository.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
