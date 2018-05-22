using Order_RestaurantWCF.Model;
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
    }
}
