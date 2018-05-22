namespace Order_RestaurantWCF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Content { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public string Description { get; set; }

        public bool? Status { get; set; }
    }
}
