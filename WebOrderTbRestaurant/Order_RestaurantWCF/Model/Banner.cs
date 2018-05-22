namespace Order_RestaurantWCF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(100)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Ingredient { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public long? Food_CategoryID { get; set; }

        public bool? Status { get; set; }
    }
}
