using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebOrderTbRestaurant.Food;

namespace WebOrderTbRestaurant.Areas.Admin.Controllers
{
    public class FooderController : Controller
    {
        // GET: Admin/Fooder
        public ActionResult Index(int page = 1, int pagesize = 4)
        {
            var model = new FoodSVClient().PageListFood().ToPagedList(page, pagesize);
            return View(model);
        }

        

        // GET: Admin/Fooder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Fooder/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Food.Food food)
        {
            if (IsNum(food.Price.ToString()))
            {
                var res = new FoodSVClient().AddFood(food);
                if (res)
                {
                    SetAlert("Thêm món ăn thành công", "success");
                    return RedirectToAction("Index", "Fooder");
                }
                else
                {
                    SetAlert("Thêm món KHÔNG thành công", "error");
                    return RedirectToAction("Create", "Fooder");
                }
            }
            else
            {
                SetAlert("Thêm món ăn KHÔNG thành công, Giá của món ăn KHÔNG HỢP LỆ", "error");
                return RedirectToAction("Create", "Fooder");
            }

        }

        // GET: Admin/Fooder/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new FoodSVClient().FindID(id);
            return View(model);
        }

        // POST: Admin/Fooder/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Food.Food food)
        {            
            if(IsNum(food.Price.ToString()))
            {
                var res = new FoodSVClient().EditFood(food);
                if (res)
                {
                    SetAlert("Sửa món ăn thành công", "success");
                    return RedirectToAction("Index", "Fooder");
                }
                else
                {
                    SetAlert("Sửa món ăn KHÔNG thành công", "error");
                    return RedirectToAction("Edit", "Fooder");
                }
            }else
            {
                SetAlert("Sửa món ăn KHÔNG thành công, Giá của món ăn KHÔNG HỢP LỆ", "error");
                return RedirectToAction("Edit", "Fooder");
            }
           
        }

       

        // POST: Admin/Fooder/Delete/5
        [HttpPost]
        public JsonResult Delete(long id)
        {
            var res = new FoodSVClient().DeleteFood(id);
            if (res)
            {
                SetAlert("Xóa món ăn thành công", "success");
                return Json(new { status = true });
            }
            else
            {
                SetAlert("Xóa món ăn KHÔNG thành công", "error");
                return Json(new { status = false });
            }
               
        }

        public bool IsNum(string value)
        {
            Regex rex = new Regex(@"\b(\d+(?:\.(?:[^0]\d|\d[^0]))?)\b");
            return rex.IsMatch(value);
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
