using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOrderTbRestaurant.Food;

namespace WebOrderTbRestaurant.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(long id)
        {
            FoodSVClient sv = new FoodSVClient();
            var foodDetail = sv.FindID(id);
            ViewBag.foodDetail = foodDetail;
            return View();
        }
    }
}