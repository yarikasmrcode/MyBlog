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

namespace MyBlog.Services
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string subject, string content)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(subject, "pomirchiy2003@gmail.com"));
            message.To.Add(new MailboxAddress(subject, "pomirchiy2003@gmail.com"));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Plain) { Text = content };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("pomirchiy2003@gmail.com", "*****");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
