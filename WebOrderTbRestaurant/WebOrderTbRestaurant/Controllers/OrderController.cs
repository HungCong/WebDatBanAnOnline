using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOrderTbRestaurant.Models;
using WebOrderTbRestaurant.OrderTB;

namespace WebOrderTbRestaurant.Controllers
{
    public class OrderController : Controller
    {
        private const string OrderSesstion = "ordersesstion";
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageOrder()
        {
            //lấy giá trị ngày đặt bàn, giờ đặt bàn, số lượng khách
            var ord = Session[OrderSesstion];
            var list = new BookCustomer();
            if (ord != null)
            {
                list = (BookCustomer)ord;
            }
            ViewBag.order = list;
            return View();
        }

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
                return Redirect("/");
            }catch(Exception e)
            {
                return Redirect("dat-ban");
            }
        }
        
    }
}