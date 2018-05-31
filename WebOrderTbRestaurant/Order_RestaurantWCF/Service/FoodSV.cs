using Order_RestaurantWCF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Order_RestaurantWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FoodSV" in both code and config file together.
    public class FoodSV : IFoodSV
    {
        Order_Restaurant_Db db = null;
        public FoodSV()
        {
            db = new Order_Restaurant_Db();
        }

        public Food FindID(long id)
        {
            return db.Food.Find(id);
        }

        public List<Food> ListAll()
        {
            return db.Food.Where(x => x.Status == true).OrderBy(x => x.ID).Take(12).ToList();
        }

        public List<Banner> ListSlideFood()
        {
            return db.Banner.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(6).ToList();
        }

        public IEnumerable<Food> PageListFood()
        {
            IQueryable<Food> food = db.Food;
            return food.OrderByDescending(x => x.CreatedDate < DateTime.Now).ToList();
        }
    }
}
