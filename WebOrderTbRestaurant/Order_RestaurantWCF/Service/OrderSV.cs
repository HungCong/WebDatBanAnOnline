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



    }
}
