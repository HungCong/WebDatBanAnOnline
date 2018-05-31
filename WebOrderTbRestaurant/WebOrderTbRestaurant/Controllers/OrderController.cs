using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebOrderTbRestaurant.Book_Menu;
using WebOrderTbRestaurant.Food;
using WebOrderTbRestaurant.Models;
using WebOrderTbRestaurant.OrderTB;

namespace WebOrderTbRestaurant.Controllers
{
    public class OrderController : Controller
    {
        private const string OrderSesstion = "ordersesstion";//session lấy thông tin ngày giờ số lượng khách của khách đặt bàn
        private const string BookFoodSesstion = "BookFood";//session thực đơn   
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
                if (list.Exists(x => x.food.ID == foodId))
                {
                    foreach (var item in list)
                    {
                        if (item.food.ID == foodId)
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

            if (ed.Exists(x => x.quantity <= 0))
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
            foreach (var item in orSec)
            {
                var foodid = ed.SingleOrDefault(x => x.food.ID == item.food.ID);
                if (foodid != null)
                {
                    item.quantity = foodid.quantity;
                }

            }

            Session[BookFoodSesstion] = orSec;
            return Json(new
            {
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
            }
            catch (Exception e)
            {
                SetAlert("Đặt bàn không thành công", "error");
                return Redirect("dat-ban");
            }
        }


        //đặt bàm có chọn thực đơn
        public ActionResult BookMenu()
        {
            var ord = Session[OrderSesstion];
            var list = new BookCustomer();
            if (ord != null)
            {
                list = (BookCustomer)ord;
            }
            ViewBag.order = list;

            var or = Session[BookFoodSesstion];
            var FoodOr = new List<OrderFood>();
            if (or != null)
            {
                FoodOr = (List<OrderFood>)or;
            }
            return View(FoodOr);
        }


        //Lưu thực đơn và tên khách hàng đặt thực đơn
        public JsonResult SaveMenu(string Menu, string customer)
        {

            var menuJson = new JavaScriptSerializer().Deserialize<List<BookFood>>(Menu);
            var cusJson = new JavaScriptSerializer().Deserialize<List<Feedback>>(customer);

            var feedback = new OrderTable();
            var listCus = cusJson.ToList();
            foreach (var item in listCus)
            {
                if(item.Full_Name == null && item.Phone == null)
                {
                    SetAlert("Không thể bỏ trống HỌ VÀ TÊN và SỐ ĐIỆN THOẠI, vui lòng kiểm tra lại ", "warning");
                    break;
                    return Json(new
                    {
                        status = true
                    });
                }
                feedback.Full_Name = item.Full_Name;
                feedback.Phone = item.Phone;
                feedback.Email = item.Email;
                if (item.Description != " ")
                {
                    feedback.Description = item.Description;
                }
                feedback.DateBook = item.DateBook;
                feedback.TimeBook = item.TimeBook;
                feedback.Count_people = item.Count_people;
                feedback.CreatedDate = DateTime.Now;

                var ins = new OrderSVClient();
                if (ins.Insert(feedback))
                {
                    SetAlert("Đặt bàn thành công", "success");
                }
                else
                    SetAlert("Đặt bàn không thành công", "warning");

            }


            var bookFood = new Book_Food();
            var listFood = menuJson.ToList();
            var idOrder = new OrderSVClient().FindIDNew();

            foreach (var item in listFood)
            {
                bookFood.Food_ID = item.Food_ID;
                bookFood.Count = item.Count;
                bookFood.Price = Convert.ToDecimal(item.Price);
                bookFood.OrderTable_ID = idOrder;

                var ins = new BookMenuSVClient();
                if (ins.InsertMenu(bookFood))
                    SetAlert("Bạn đã đặt trước thực đơn thành công", "success");
                else
                    SetAlert("Bạn đã đặt trước thực đơn không thành công", "warning");

            }
            return Json(new
            {
                status = true
            });
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