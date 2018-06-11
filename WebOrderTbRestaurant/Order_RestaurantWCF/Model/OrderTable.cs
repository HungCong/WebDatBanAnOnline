namespace Order_RestaurantWCF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderTable")]
    public partial class OrderTable
    {
        public long ID { get; set; }

        [StringLength(150)]
        [Display(Name ="Họ và tên")]
        public string Full_Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [Display(Name = "Nội dung")]
        public string Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Ngày đặt")]
        public string DateBook { get; set; }

        [StringLength(50)]
        [Display(Name = "Thời gian đặt")]
        public string TimeBook { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Số lượng khách")]
        public int? Count_people { get; set; }

        public bool? Status { get; set; }
    }
}
