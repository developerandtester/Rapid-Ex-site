using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Citrine()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public JsonResult SendMail(string Name, string Email, string Mobile, string Subject, string Company, string Message) {
            string senderID = "developer@darshinfotech.in";
            string senderPassword = "gingerdomain";
            string smtphost = "smtp.dreamhost.com";
            string emailsubject = Subject;
            emailsubject += " " + DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy");
            string result = "Message sent successfully";
            string Body = "Client Name: " + Name + "\n Client Email: " + Email + "\n Client Mobile Number: " + Mobile + "\n Client Company: " + Company + "\n Message : " + Message;
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = smtphost,
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };

                MailMessage message = new MailMessage(senderID, senderID, emailsubject, Body);
                
                // message.To.Add(new MailAddress("developer@darshinfotech.in"));
                message.CC.Add(new MailAddress("shreyansh@darshgroup.com"));
            



                //message.CC.Add(new MailAddress("vyasprathmesh@gmail.com"));
                // message.CC.Add(new MailAddress("jyotsna.gupta@bagzone.in"));

                smtp.Send(message);
                //MessageBox.Show(Message);

                message = null;


                //19/06/2016 shailesh
                //*****************************************************
                //check if store email id is not blank
                //if store email id is not blank, then send email to store also
                //if (StoreEmail != "")
                //{
                //    message = new MailMessage(senderID, StoreEmail, emailsubject, Message);
                //    smtp.Send(message);
                //}
                //19/06/2016 shailesh
                //*****************************************************
            }

            catch (Exception ex)
            {
                result = ex.Message;
            }
            //   Mes
            return Json(1);
        }
    }
}