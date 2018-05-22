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
    }
}
