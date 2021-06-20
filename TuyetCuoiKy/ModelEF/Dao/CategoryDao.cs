using ModelEF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class CategoryDao
    {
        private HoThiTuyetContext db;
        public CategoryDao()
        {
            db = new HoThiTuyetContext();
        }
        public IEnumerable<Category> ListWhereAll(string keySearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Category;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.Name.Contains(keySearch));
            }

            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }
        public List<Category> ListAll()
        {
            return db.Category.ToList();
        }
        public bool FindName(string name)
        {
            return db.Category.Any(x => x.Name == name);
        }
        public string Insert(Category entityCategory)
        {
            //var user = FindId(entityUser.admin_id);
            db.Category.Add(entityCategory);
            db.SaveChanges();
            return entityCategory.Name;
        }
        public Category FindId(System.Int32 id)
        {
            return db.Category.Find(id);
        }
        public string Update(Category entityCategory)
        {
            var category = FindId(entityCategory.ID);
            if (category != null)
            {
                category.Name = entityCategory.Name;
                category.Description = entityCategory.Description;
            }
            db.SaveChanges();
            return entityCategory.Name;
        }
        public bool Delete(System.Int32 id)
        {
            try
            {
                var category = db.Category.Find(id);
                db.Category.Remove(category);
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
