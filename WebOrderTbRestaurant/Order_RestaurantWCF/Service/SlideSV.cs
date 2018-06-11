using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Order_RestaurantWCF.Model;

namespace Order_RestaurantWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SlideSV" in both code and config file together.
    public class SlideSV : ISlideSV
    {
        Order_Restaurant_Db db = null;
        public SlideSV()
        {
            db = new Order_Restaurant_Db();
        }

        public bool addSlide(Banner entity)
        {
           try
            {
                var banner = new Banner();
                banner.Name = entity.Name;
                banner.MetaTitle = Str_Metatitle(entity.Name);
                banner.Ingredient = entity.Ingredient;
                banner.Image = entity.Image;
                banner.CreatedDate = DateTime.Now;
                banner.Description = entity.Description;
                banner.Price = entity.Price;
                banner.Status = true;

                db.Banner.Add(banner);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

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

        public bool DeleteSlide(long id)
        {
            try
            {
                var banner = db.Banner.Find(id);
                db.Banner.Remove(banner);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool EditSlide(Banner entity)
        {
            try
            {
                var banner = db.Banner.Find(entity.ID);
                banner.Name = entity.Name;
                banner.MetaTitle = Str_Metatitle(entity.Name);
                banner.Ingredient = entity.Ingredient;
                banner.Image = entity.Image;
                banner.Description = entity.Description;
                banner.Price = entity.Price;

                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Banner> PageListSlide()
        {
            return db.Banner.OrderBy(x => x.CreatedDate < DateTime.Now).ToList();
        }

        public Banner FindID(long id)
        {
            return db.Banner.Find(id);
        }
    }
}
