using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebOrderTbRestaurant.Slide;

namespace WebOrderTbRestaurant.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        // GET: Admin/Slide
        public ActionResult Index(int page = 1, int pagesize = 2)
        {
            var model = new SlideSVClient().PageListSlide().ToPagedList(page, pagesize);
            return View(model);
        }
        
        // GET: Admin/Slide/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slide/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Slide.Banner banner)
        {
            if (IsNum(banner.Price.ToString()))
            {
                var res = new SlideSVClient().addSlide(banner);
                if (res)
                {
                    SetAlert("Thêm slide món ăn thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    SetAlert("Thêm món KHÔNG thành công", "error");
                    return RedirectToAction("Create", "Slide");
                }
            }
            else
            {
                SetAlert("Thêm slide món ăn KHÔNG thành công, Giá của món ăn KHÔNG HỢP LỆ", "error");
                return RedirectToAction("Create", "Slide");
            }
        }

        // GET: Admin/Slide/Edit/5
        public ActionResult Edit(long id)
        {
            var model = new SlideSVClient().FindID(id);
            return View(model);
        }

        // POST: Admin/Slide/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Slide.Banner banner)
        {
            if (IsNum(banner.Price.ToString()))
            {
                var res = new SlideSVClient().EditSlide(banner);
                if (res)
                {
                    SetAlert("Sửa món ăn thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    SetAlert("Sửa món ăn KHÔNG thành công", "error");
                    return RedirectToAction("Edit", "Slide");
                }
            }
            else
            {
                SetAlert("Sửa món ăn KHÔNG thành công, Giá của món ăn KHÔNG HỢP LỆ", "error");
                return RedirectToAction("Edit", "Slide");
            }
        }


        [HttpPost]
        public JsonResult Delete(long id)
        {
            var res = new SlideSVClient().DeleteSlide(id);
            if (res)
            {
                SetAlert("Xóa slide món ăn thành công", "success");
                return Json(new { status = true });
            }
            else
            {
                SetAlert("Xóa slide KHÔNG thành công", "error");
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
