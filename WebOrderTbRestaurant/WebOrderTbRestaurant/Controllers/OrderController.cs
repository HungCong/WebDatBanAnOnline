using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebOrderTbRestaurant.Food;
using WebOrderTbRestaurant.Models;
using WebOrderTbRestaurant.OrderTB;

namespace WebOrderTbRestaurant.Controllers
{
    public class OrderController : Controller
    {
        private const string OrderSesstion = "ordersesstion";
        private const string BookFoodSesstion = "BookFood";
        // GET: Order
        public ActionResult Index()
        {
            var or = Session[BookFoodSesstion];
            var list = new List<OrderFood>();
            if (or != null)
            {
                list = (List<OrderFood>)or;
            }             
            return View(list);
        }

        //Thêm món ăn vào thực đơn
        public ActionResult AddMenu(long foodId, int quantity)
        {
            var food = new FoodSVClient().FindID(foodId);
            var or = Session[BookFoodSesstion];
            if (or != null)
            {
                var list = (List<OrderFood>)or;
                if(list.Exists(x => x.food.ID == foodId))
                {
                    foreach (var item in list)
                    {
                        if(item.food.ID == foodId)
                        {
                           item.quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new OrderFood();
                    item.food = food;
                    item.quantity = quantity;
                    list.Add(item);
                }
            }
            else
            {
                var item = new OrderFood();
                var list = new List<OrderFood>();
                item.food = food;
                item.quantity = quantity;
                list.Add(item);
                Session[BookFoodSesstion] = list;
            }          
            return RedirectToAction("Index");
        }

        //Xoá một món ăn trong thực đơn
        public JsonResult Delete(long id)
        {           
            var sec = (List<OrderFood>)Session[BookFoodSesstion];
            sec.RemoveAll(x => x.food.ID == id);
            Session[BookFoodSesstion] = sec;
            SetAlert("Xóa món ăn thành công", "success");
            return Json(new
            {
                status = true
            });
        }

        //Xóa thực đơn
        public JsonResult DeleteAll()
        {
            Session[BookFoodSesstion] = null;
            return Json(new
            {
                status = true
            });
        }

       

        //Sửa số lượng món ăn trong thực đơn
        public JsonResult Edit(string EditFood)
        {
            var ed = new JavaScriptSerializer().Deserialize<List<OrderFood>>(EditFood);
            var orSec = (List<OrderFood>)Session[BookFoodSesstion];    
             
            if(ed.Exists(x => x.quantity <= 0))
            {
                //foreach(var item in orSec)
                //{
                //    var err = ed.SingleOrDefault(x => x.food.ID == item.food.ID);
                //    orSec.RemoveAll(x => x.food.ID == err.food.ID);
                //}
                SetAlert("Số lượng món ăn không thể bằng 0 hoặc nhỏ hơn 0", "error");
                return Json(new
                {
                    status = true
                });
            }
            foreach(var item in orSec)
            {
                var foodid = ed.SingleOrDefault(x => x.food.ID == item.food.ID);
                if (foodid != null)
                {                    
                    item.quantity = foodid.quantity;                    
                }
                
            }
            
            Session[BookFoodSesstion] = orSec;
            return Json(new {
                status = true
            });
        }


        //lấy giá trị ngày đặt bàn, giờ đặt bàn, số lượng khách
        public ActionResult PageOrder()
        {           
            var ord = Session[OrderSesstion];
            var list = new BookCustomer();
            if (ord != null)
            {
                list = (BookCustomer)ord;
            }
            ViewBag.order = list;
            return View();
        }


        //Đặt bàn không chọn thực đơn
        [HttpPost]
        public ActionResult BookTable(string name, string date, string sodt, string timeBook, string email, int quantity, string noidung)
        {
            var order = new OrderTB.OrderTable();
            order.Full_Name = name;
            order.DateBook = date;
            order.Phone = sodt;
            order.TimeBook = timeBook;
            order.Email = email;
            order.Count_people = quantity;
            if (noidung != null)
            {
                 order.Description = noidung;
            }           
            order.CreatedDate = DateTime.Now;
            try
            {
                var ins = new OrderSVClient();
                ins.Insert(order);
                SetAlert("Đặt bàn thành công", "success");
                return Redirect("/");
            }catch(Exception e)
            {
                SetAlert("Đặt bàn không thành công", "error");
                return Redirect("dat-ban");
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
            else if (type == "Warning")
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