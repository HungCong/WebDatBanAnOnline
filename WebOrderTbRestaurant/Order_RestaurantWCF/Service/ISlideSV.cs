using Order_RestaurantWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Order_RestaurantWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISlideSV" in both code and config file together.
    [ServiceContract]
    public interface ISlideSV
    {
        //Pagination
        [OperationContract]
        IEnumerable<Banner> PageListSlide();

        //add slide
        [OperationContract]
        bool addSlide(Banner entity);


        //edit slide
        [OperationContract]
        bool EditSlide(Banner entity);

        //delete slide
        [OperationContract]
        bool DeleteSlide(long id);

        //Convert name to metitle
        [OperationContract]
        string Str_Metatitle(string str);

        //find ID
        [OperationContract]
        Banner FindID(long id);
    }
}
