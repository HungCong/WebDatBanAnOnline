using Order_RestaurantWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Order_RestaurantWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderSV" in both code and config file together.
    [ServiceContract]
    public interface IOrderSV
    {
        [OperationContract]
        bool Insert(OrderTable or);

        [OperationContract]
        long FindIDNew();

        [OperationContract]
        IEnumerable<OrderTable> ListAll();

        [OperationContract]
        OrderTable FindID(long id);

        [OperationContract]
        bool EditOrder(OrderTable or);

        [OperationContract]
        bool DeleteOrder(long id);

        //Give full name in order_TB
        [OperationContract]
        OrderTable Find_FullName(long order_id);

    }
}
