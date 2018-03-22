using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Areas.AdminControl.Models
{
    public class FormViewModel
    {
        public List<Account> AcountForm { get; set; }
        public List<WebApplication1.Models.HomeStay>  HomestayForm { get; set; }
        public List<ImageHomeStay>  ImageForm { get; set; }
        public List<Event>  EventForm { get; set; }
        public List<Adress>  AdressForm { get; set; }
        public List<About_Us_Admin>  AboutForm { get; set; }
    }
}