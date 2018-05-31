using Order_RestaurantWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Order_RestaurantWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookMenuSV" in both code and config file together.
    public class BookMenuSV : IBookMenuSV
    {
        Order_Restaurant_Db db = null;
        public BookMenuSV()
        {
            db = new Order_Restaurant_Db();
        }

        //Lưu thực đơn khách hàng
        public bool InsertMenu(Book_Food bf)
        {
            try
            {
                db.Book_Food.Add(bf);
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
