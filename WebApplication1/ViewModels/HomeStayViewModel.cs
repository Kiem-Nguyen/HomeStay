using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class HomeStayViewModel
    {
        public int IDHomeStay { get; set; }
        public string City { get; set; }
        public WebApplication1.Models.HomeStay HomeStayModel { get; set; }
        public List<ImageItem> ImageList { get; set; }
    }

    public class ImageItem
    {
        public int IDImage { get; set; }
        public string Image { get; set; }
    }
}