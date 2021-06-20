namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên Đăng Nhập")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Mật Khẩu")]
        public string PassWord { get; set; }

        [StringLength(100)]
        [Display(Name = "Trạng Thái")]
        public string Status { get; set; }
    }
}
