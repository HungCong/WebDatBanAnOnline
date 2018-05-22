namespace Order_RestaurantWCF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Main_Menu
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Content { get; set; }

        [StringLength(50)]
        public string Link { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }
    }
}
