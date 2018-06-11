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

        //Chuyển tên món ăn thành metatitle
        public string Str_Metatitle(string str)
        {
            string[] VietNamChar = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ:"
            };
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            string str1 = str.ToLower();
            string[] name = str1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string meta = null;
            //Thêm dấu '-'
            foreach (var item in name)
            {
                meta = meta + item + "-";
            }
            return meta;
        }

        public bool AddFood(Food entity)
        {
            try
            {
                var fod = new Food();
                fod.Name = entity.Name;
                fod.Image = entity.Image;
                fod.Ingredient = entity.Ingredient;
                fod.CreatedDate = DateTime.Now;
                fod.MetaTitle = Str_Metatitle(entity.Name);
                fod.Description = entity.Description;
                fod.Price = entity.Price;
                fod.Status = true;

                db.Food.Add(fod);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
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
            return food.OrderBy(x => x.CreatedDate < DateTime.Now).ToList();
        }

        public bool EditFood(Food entity)
        {
            try
            {
                var food = db.Food.Find(entity.ID);
                food.Name = entity.Name;
                food.Ingredient = entity.Ingredient;
                food.Image = entity.Image;
                food.MetaTitle = Str_Metatitle(entity.Name);
                food.Description = entity.Description;
                food.Price = entity.Price;

                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool DeleteFood(long id)
        {
            try
            {
                var food = db.Food.Find(id);
                db.Food.Remove(food);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public Food Find_FoodName(long food_id)
        {
            return db.Food.SingleOrDefault(x => x.ID == food_id);
        }
    }
}
