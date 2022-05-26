using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MyBlog.Models;
using MimeKit.Text;
using MyBlog.Services;

namespace MyBlog.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailSender email;
        public EmailController(IEmailSender email)
        {
            this.email = email;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(string subject, string content)
        {
            email.SendEmail(subject, content);

            return View();
        }
    }
}
