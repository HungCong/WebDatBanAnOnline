using PagedList;
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
        private const string BookFoodSesstion = "BookFood";
        // GET: Home
        public ActionResult Index(int page = 1, int pagesize = 6)
        {
            var fo = new Food.Food();
            var sv = new FoodSVClient();
            ViewBag.Food_Slide = sv.ListSlideFood();

            var or = Session[BookFoodSesstion];
            var FoodOr = new List<OrderFood>();
            if (or != null)
            {
                FoodOr = (List<OrderFood>)or;
            }
            ViewBag.MenuList = FoodOr;
            var model = sv.PageListFood().ToPagedList(page, pagesize);
            return View(model);
        }

        //Tìm kiếm món ăn
        public ActionResult Search(string keyword)
        {           
            string[] key = keyword.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var food = new List<Food.Food>();
            foreach(var item in key)
            {
                var list = new FoodSVClient().Search(item);
                foreach(var li in list)
                {
                    food.Add(li);
                }
            }
            ViewBag.KeyWord = keyword;
            ViewBag.ListFood = food;
            return View();
        }

        //Thuộc tính autocomplete
        public JsonResult ListName(string q)
        {
            var data = new FoodSVClient().searchFood(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        //lấy giá trị ngày đặt bàn, giờ đặt bàn, số lượng khách
        public JsonResult BookCustomer(string Cus_book)
        {         
            
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