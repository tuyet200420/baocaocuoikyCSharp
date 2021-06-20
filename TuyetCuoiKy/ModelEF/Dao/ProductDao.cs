using ModelEF.EF;
using ModelEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class ProductDao
    {
        private HoThiTuyetContext db;
        public ProductDao()
        {
            db = new HoThiTuyetContext();
        }
        public List<ProductModel> ListWhereAll(string keysearch)
        {
            var list_product = from s in db.Product
                               join c in db.Category
                               on s.IDCategory equals c.ID
                               orderby s.Quantity, s.UnitCost descending
                               select new ProductModel
                               {
                                   ID = s.ID,
                                   Name = s.Name,
                                   UnitCost = (decimal)s.UnitCost,
                                   Quantity = s.Quantity,
                                   Image = s.Image,
                                   Description = s.Description,
                                   category_name=c.Name
                               };
            var list_product_1 = from s in db.Product
                                 join c in db.Category
                                 on s.IDCategory equals c.ID
                                 where s.Name.Contains(keysearch)
                                 orderby s.Quantity, s.UnitCost descending
                                 select new ProductModel 
                                 {
                                     ID = s.ID,
                                     Name = s.Name,
                                     UnitCost = (decimal)s.UnitCost,
                                     Quantity = s.Quantity,
                                     Image = s.Image,
                                     Description = s.Description,
                                     category_name = c.Name
                                 };
            if (!string.IsNullOrEmpty(keysearch))
                return list_product_1.ToList();
            return list_product.ToList();
        }
        public List<Product> ListAll()
        {
            return db.Product.Where(x => x.Status == 1).ToList();
        }
        public Product FindId(System.Int32 id)
        {
            return db.Product.Find(id);
        }
        public bool Delete(System.Int32 id)
        {
            try
            {
                var product = db.Product.Find(id);
                db.Product.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
