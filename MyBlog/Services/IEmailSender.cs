using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public interface IEmailSender
    {
        void SendEmail(string subject, string content);
    }
}
