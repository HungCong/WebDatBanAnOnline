using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebOrderTbRestaurant.Food;
using WebOrderTbRestaurant.Main_Menu;
using WebOrderTbRestaurant.Models;

namespace WebOrderTbRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private const string OrderSesstion = "ordersesstion";
        // GET: Home
        public ActionResult Index()
        {     
            var sv = new FoodSVClient();
            ViewBag.Food_content = sv.ListAll();
            ViewBag.Food_Slide = sv.ListSlideFood();
            return View();
        }

        public JsonResult BookCustomer(string Cus_book)
        {
            //lấy giá trị ngày đặt bàn, giờ đặt bàn, số lượng khách
            
            var JsonCus = new JavaScriptSerializer().Deserialize<BookCustomer[]>(Cus_book);
            var ord = new BookCustomer();
            var list = new List<BookCustomer>();
            foreach(var item in JsonCus)
            {
                ord.BookDate = item.BookDate;
                ord.Quantity = item.Quantity;
                ord.Time = item.Time;
                list.Add(ord);
            }
            
            Session[OrderSesstion] = ord;            

            return Json(new
            {
                status = true
            });
        }

        [ChildActionOnly]
        public PartialViewResult MainMenu()
        {
            var sv = new MenuSVClient();
            ViewBag.menu = sv.ListMenu();
            return PartialView();
        }

        public PartialViewResult Footer()
        {
            var sv = new MenuSVClient();
            ViewBag.footer = sv.ListFooter();
            return PartialView();
        }
    }
}