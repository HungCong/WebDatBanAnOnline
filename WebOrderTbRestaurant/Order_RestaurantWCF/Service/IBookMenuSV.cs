using Order_RestaurantWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Order_RestaurantWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookMenuSV" in both code and config file together.
    [ServiceContract]
    public interface IBookMenuSV
    {
        [OperationContract]
        bool InsertMenu(Book_Food bf);

        //check IdOrder_Table in Book_Food table
        [OperationContract]
        bool CheckID(long id);

        //find IdOrder_Table in Book_Food table
        [OperationContract]
        IEnumerable<Book_Food> FindID_OrderTB(long orderTB_ID);

        //give all the menu
        [OperationContract]
        IEnumerable<Book_Food> ListAll();

        [OperationContract]
        //Edit Count of food
        bool EditCount(long id, int count);

        [OperationContract]
        //Delete food
        bool deleteFoodinMenu(long id);
    }
}
