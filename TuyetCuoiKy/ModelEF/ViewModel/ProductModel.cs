using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ViewModel
{

    public class ProductModel
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal UnitCost { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string category_name { get; set; }
    }
}
