﻿using Order_RestaurantWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Order_RestaurantWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMenuSV" in both code and config file together.
    [ServiceContract]
    public interface IMenuSV
    {
        [OperationContract]
        List<Main_Menu> ListMenu();//Lấy danh sách menu chính

        [OperationContract]
        Footer ListFooter();//Footer
    }
}
