using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Order_RestaurantWCF.Model;

namespace Order_RestaurantWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderSV" in both code and config file together.
    public class OrderSV : IOrderSV
    {
        Order_Restaurant_Db db = null;
        public OrderSV()
        {
            db = new Order_Restaurant_Db();
        }

        

        //Lưu thông tin khách hàng đặt bàn
        public bool Insert(OrderTable or)
        {
            try
            {
                db.OrderTable.Add(or);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        //Lấy ID vừa mới thêm vào csdl
        public long FindIDNew()
        {
            var id = from or in db.OrderTable                   
                   select or.ID  ;
            return id.Max();
        }

        public IEnumerable<OrderTable> ListAll()
        {
            return db.OrderTable.Where(x => x.CreatedDate < DateTime.Now).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public OrderTable FindID(long id)
        {
            return db.OrderTable.Find(id);
        }

        public bool EditOrder(OrderTable or)
        {
            try
            {
                var order = db.OrderTable.Find(or.ID);
                order.Full_Name = or.Full_Name;
                order.Phone = or.Phone;
                order.DateBook = or.DateBook;
                order.TimeBook = or.TimeBook;
                order.Count_people = or.Count_people;
                order.Description = or.Description;
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }            
        }

        public bool DeleteOrder(long id)
        {
            try
            {
                var or = db.OrderTable.Find(id);
                db.OrderTable.Remove(or);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public OrderTable Find_FullName(long order_id)
        {
            return db.OrderTable.SingleOrDefault(x => x.ID == order_id);
        }
    }
}
