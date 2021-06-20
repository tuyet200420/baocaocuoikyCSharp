using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class DetailProductDao
    {
        private HoThiTuyetContext db;
        public DetailProductDao()
        {
            db = new HoThiTuyetContext();
        }
        public List<Product> ListWhereAll(System.Int32 id)
        {
            return db.Product.Where(x => x.ID == id).ToList();
        }
    }
}
