namespace Order_RestaurantWCF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book_Food
    {
        public long ID { get; set; }
       
        public long Food_ID { get; set; }

        public int Count { get; set; }

        public Decimal? Price { get; set; }

        public long OrderTable_ID { get; set; }

        public bool? Status { get; set; }
    }
}
