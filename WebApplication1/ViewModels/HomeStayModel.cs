using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class HomeStayModel
    {
        public int ID_HomeStay { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public Nullable<int> IDLocation { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Adress { get; set; }
        public Nullable<int> Sale { get; set; }
        public string Description { get; set; }
        public string TypeHourse { get; set; }
        public Nullable<int> Baths { get; set; }
        public Nullable<int> Beds { get; set; }
        public Nullable<int> Garages { get; set; }
    }
}