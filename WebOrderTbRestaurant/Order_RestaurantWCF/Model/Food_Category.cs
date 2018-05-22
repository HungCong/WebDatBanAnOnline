namespace Order_RestaurantWCF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Food_Category
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public bool? Status { get; set; }
    }
}
