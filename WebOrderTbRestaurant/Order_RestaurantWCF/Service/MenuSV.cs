using Order_RestaurantWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Order_RestaurantWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MenuSV" in both code and config file together.
    public class MenuSV : IMenuSV
    {
        Order_Restaurant_Db db = null;
        public MenuSV()
        {
            db = new Order_Restaurant_Db();
        }

        public Footer ListFooter()
        {
            return db.Footer.SingleOrDefault(x => x.Status == true);
        }

        public List<Main_Menu> ListMenu()
        {
            return db.Main_Menu.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
