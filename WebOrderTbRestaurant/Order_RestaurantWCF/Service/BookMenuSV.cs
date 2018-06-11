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

        public bool CheckID(long id)
        {
            var book_food = from book in db.Book_Food
                            where book.OrderTable_ID == id
                            select book.OrderTable_ID;
                            
            if (book_food.Count() != 0)
                return true;
            return false;
        }

        public IEnumerable<Book_Food> FindID_OrderTB(long orderTB_ID)
        {
            var book = from bok in db.Book_Food
                       where bok.OrderTable_ID == orderTB_ID
                       select bok;
            return book;
        }

        public IEnumerable<Book_Food> ListAll()
        {
            return db.Book_Food.OrderByDescending(x => x.ID).ToList();
        }

        public bool EditCount(long id, int count)
        {
            try
            {
                var bf = db.Book_Food.Find(id);
                bf.Count = count;

                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool deleteFoodinMenu(long id)
        {

            try
            {
                var bf = db.Book_Food.Find(id);
                db.Book_Food.Remove(bf);
                db.SaveChanges();
                return true;
            }catch( Exception e)
            {
                return false;
            }
        }
    }
}
