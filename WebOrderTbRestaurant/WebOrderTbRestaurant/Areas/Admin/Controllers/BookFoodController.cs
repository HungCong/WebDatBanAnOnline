using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOrderTbRestaurant.Book_Menu;

namespace WebOrderTbRestaurant.Areas.Admin.Controllers
{
    public class BookFoodController : Controller
    {
        // GET: Admin/BookFood
        public ActionResult Index(long orderTB_id)
        {
            var model = new Book_Menu.BookMenuSVClient().FindID_OrderTB(orderTB_id);
            var list_FullName = new List<OrderTB.OrderTable>();
            var list_FoodName = new List<Food.Food>();
           
            foreach(var item in model)
            {
                var fullname = new OrderTB.OrderSVClient().Find_FullName(item.OrderTable_ID);
                
                list_FullName.Add(fullname);
                var foodname = new Food.FoodSVClient().Find_FoodName(item.Food_ID);
                list_FoodName.Add(foodname);
            }

            ViewBag.FullName = list_FullName;
            ViewBag.FoodName = list_FoodName;
            return View(model);
        }

       public ActionResult ListAll(int page = 1, int pagesize = 4)
        {
            var model = new Book_Menu.BookMenuSVClient().ListAll().ToPagedList(page, pagesize);

            var list_FullName = new List<OrderTB.OrderTable>();
            var list_FoodName = new List<Food.Food>();

            foreach (var item in model)
            {
                var fullname = new OrderTB.OrderSVClient().Find_FullName(item.OrderTable_ID);

                list_FullName.Add(fullname);
                var foodname = new Food.FoodSVClient().Find_FoodName(item.Food_ID);
                list_FoodName.Add(foodname);
            }

            ViewBag.FullName = list_FullName;
            ViewBag.FoodName = list_FoodName;

            return View(model);
        }


        //Edit count of food
        // GET: Admin/BookFood/Edit/5
        public JsonResult Edit(long id, int count)
        {
            var res = new BookMenuSVClient().EditCount(id, count);
            if (res)
            {
                SetAlert("Sửa số lượng món thành công", "success");
                return Json(new { status = true });
            }
            else
            {
                SetAlert("Sửa số lượng KHÔNG thành công", "error");
                return Json(new { status = false });
            }
        }

       
        // GET: Admin/BookFood/Delete/5
        public JsonResult DeleteInCus(long id)
        {
            var res = new BookMenuSVClient().deleteFoodinMenu(id);
            if (res)
            {
                SetAlert("Xóa món ăn trong thực đơn thành công", "success");
                return Json(new { status = true });
            }
            else
            {
                SetAlert("Xóa món ăn KHÔNG thành công", "error");
                return Json(new { status = false });
            }            
        }

        

        public void SetAlert(string message, string type)
        {
            //Giống ViewBag
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}
