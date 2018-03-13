using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Home_Stay
    {
        public int Id { get; set; }
        public int IdLocation { get; set; }
        public int IdImage { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
    }
}