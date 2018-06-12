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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFoodSV" in both code and config file together.
    [ServiceContract]
    public interface IFoodSV
    {
        [OperationContract]
        List<Food> ListAll();//Food

        //Food on slide
        [OperationContract]
        List<Banner> ListSlideFood();

        //Detail of Food
        [OperationContract]
        Food FindID(long id);

        //PageList of Food
        [OperationContract]
        IEnumerable<Food> PageListFood();

        //Add new food
        [OperationContract]
        bool AddFood(Food entity);

        //convert food name to metatitle
        [OperationContract]
        string Str_Metatitle(string str);

        //Edit food
        [OperationContract]
        bool EditFood(Food entity);

        //Delete food
        [OperationContract]
        bool DeleteFood(long id);

        //give food name in food table
        [OperationContract]
        Food Find_FoodName(long food_id);

        //search food (for jquery)
        [OperationContract]
        List<string> searchFood(string nameFood);

        //search food
        [OperationContract]
        List<Food> Search(string namefood);
    }
}
