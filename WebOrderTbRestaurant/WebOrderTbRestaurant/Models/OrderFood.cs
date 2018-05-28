using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebOrderTbRestaurant.Models
{
    public class OrderFood
    {
        public Food.Food food { get; set; }
        public int quantity { get; set; }
    }
}