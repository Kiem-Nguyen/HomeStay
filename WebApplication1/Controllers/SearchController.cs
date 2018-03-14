using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        private readonly HomeStayVNEntities dbContext;
        public SearchController()
        {
            dbContext = new HomeStayVNEntities();
        }
        // GET: Search

        [HttpPost]
        public JsonResult SearchIndex(string key)
        {
            try
            {
                var homeStay = dbContext.HomeStays;
                var imageHomeStay = dbContext.ImageHomeStays;
                var address = dbContext.Adresses;

                var data = (from a in homeStay
                            from b in imageHomeStay
                            from c in address
                            where a.ID_HomeStay == b.IDHomeStay && c.IDLocation == a.IDLocation && (a.Name.Contains(key) || a.Description.Contains(key))
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
                //var searchResult = data.Where(x => x.HomeStayModel.Name.Contains(key) || x.HomeStayModel.Description.Contains(key));

                return Json(data);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}