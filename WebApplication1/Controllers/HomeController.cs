using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace HomeStay.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeStayVNEntities dbContext;
        public HomeController()
        {
            dbContext = new HomeStayVNEntities();
        }

        // GET: Home
        public ActionResult Index()
        {
            var homeStay = dbContext.HomeStays;
            var imageHomeStay = dbContext.ImageHomeStays;
            var address = dbContext.Adresses;

            var data = (from a in homeStay
                        from b in imageHomeStay
                        from c in address
                        where a.ID_HomeStay == b.IDHomeStay && c.IDLocation == a.IDLocation && a.TypeHourse != "Note"
                        group b by new { a.ID_HomeStay, c.City } into groupClause
                        select new HomeStayViewModel
                        {
                            IDHomeStay = groupClause.Key.ID_HomeStay,
                            City = groupClause.Key.City,
                            ImageList = groupClause.Select(x => new ImageItem { IDImage = x.IDImage, Image = x.Image }).ToList(),
                        }).ToList();
            var allHomeStay = data.Join(dbContext.HomeStays, x => x.IDHomeStay, y => y.ID_HomeStay, (x, y) => y).ToList();
            var i = 0;
            foreach (var item in allHomeStay)
            {
                data[i].HomeStayModel = item;
                i++;
            }
            return View(data.OrderBy(x => x.City).Take(3).ToList());
        }

        public ActionResult HeaderHome()
        {
            var homeStay = dbContext.HomeStays;
            var imageHomeStay = dbContext.ImageHomeStays;
            var address = dbContext.Adresses;

            var data = (from a in homeStay
                        from b in imageHomeStay
                        from c in address
                        where a.ID_HomeStay == b.IDHomeStay && c.IDLocation == a.IDLocation && a.TypeHourse == "Note"
                        group b by new { a.ID_HomeStay } into groupClause
                        select new HomeStayViewModel
                        {
                            IDHomeStay = groupClause.Key.ID_HomeStay,
                            ImageList = groupClause.Select(x => new ImageItem { IDImage = x.IDImage, Image = x.Image }).ToList(),
                        }).ToList();
            var allHomeStay = data.Join(dbContext.HomeStays, x => x.IDHomeStay, y => y.ID_HomeStay, (x, y) => y).ToList();

            var i = 0;
            foreach (var item in allHomeStay)
            {
                data[i].HomeStayModel = item;
                i++;
            }

            return View(data);
        }

        public ActionResult AboutUsHome()
        {
            var aboutusadmin = dbContext.About_Us_Admins;
            var data = aboutusadmin.ToList().Take(3);

            return View(data);
        }

        public ActionResult Buys()
        {
            var homeStay = dbContext.HomeStays;
            var imageHomeStay = dbContext.ImageHomeStays;
            var address = dbContext.Adresses;

            var data = (from a in homeStay
                        from b in imageHomeStay
                        from c in address
                        where a.ID_HomeStay == b.IDHomeStay && c.IDLocation == a.IDLocation
                        group b by new { a.ID_HomeStay, c.City } into groupClause
                        select new HomeStayViewModel
                        {
                            IDHomeStay = groupClause.Key.ID_HomeStay,
                            City = groupClause.Key.City,
                            ImageList = groupClause.Select(x => new ImageItem { IDImage = x.IDImage, Image = x.Image }).ToList(),
                        }).ToList();
            var allHomeStay = data.Join(dbContext.HomeStays, x => x.IDHomeStay, y => y.ID_HomeStay, (x, y) => y).ToList();
            var i = 0;
            foreach (var item in allHomeStay)
            {
                data[i].HomeStayModel = item;
                i++;
            }
            return View(data);
        }

        public ActionResult Rent()
        {
            return View();
        }

        public ActionResult Properties()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Contact(Chat model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
                    message.From = new MailAddress("sender@outlook.com");  // replace with valid value
                    message.Subject = "Your email subject";
                    message.Body = string.Format(body, model.FullName, model.Email, model.Description);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        using (HomeStayVNEntities db = new HomeStayVNEntities())
                        {
                            Chat newChat = new Chat();
                            newChat.FullName = model.FullName;
                            newChat.Email = model.Email;
                            newChat.PhoneNum = model.PhoneNum;
                            newChat.Description = model.Description;
                            newChat.Seen = 0;
                            newChat.Date = DateTime.Now;

                            db.Chats.Add(newChat);
                            db.SaveChanges();
                        }

                        //var credential = new NetworkCredential
                        //{
                        //    UserName = Commons.EmailSetting.EMAILSETTING,
                        //    Password = Commons.EmailSetting.PASSEMAILSETTING
                        //};
                        //smtp.Credentials = credential;
                        //smtp.Host = "smtp.gmail.com";
                        //smtp.Port = 587;
                        //smtp.EnableSsl = true;
                        //await smtp.SendMailAsync(message);\
                        //smtp.Send(message);

                        return Json(new { susscess = true, message = "Thanks! We will contact you soon!" });
                    }
                }
                catch (Exception e)
                {
                    return Json(new { susscess = true, message = e.Message });
                }
            }
            return Json(new { susscess = false, message = "Can't Send" });
        }
    }
}