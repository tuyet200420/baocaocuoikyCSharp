namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Sản Phẩm")]
        public string Name { get; set; }

        [Display(Name = "Giá")]
        public decimal? UnitCost { get; set; }

        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }

        [StringLength(200)]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô Tả")]
        public string Description { get; set; }

        [Display(Name = "Trạng Thái")]
        public int? Status { get; set; }

        [Display(Name = "Danh Mục")]
        public int? IDCategory { get; set; }

        public virtual Category Category { get; set; }
        
    }
}
