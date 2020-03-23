using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.Controllers
{
    public class EmailController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendMail(Models.ContactUs item)
        {

            var x = item;



            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("Admin",
            "shaikhnazih@gmail.com");
            message.From.Add(from);
            MailboxAddress to = new MailboxAddress("Nazih",
            "shaikhnazih@gmail.com");
            message.To.Add(to);
            message.Subject = ".net Core App";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello World!</h1>";
            bodyBuilder.TextBody = "Hello World!";
            SmtpClient client = new SmtpClient();
            
            client.Connect("smtp.gmail.com", 25,false);
            
            client.Authenticate("shaikhnazih@gmail.com", "");
            
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return RedirectToAction("Thanks", "Email");
        }

        public IActionResult Thanks()
        {
            return View();
        }
    }
}
