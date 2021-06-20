using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        PhamNgocAnhContext db = null;
        public ProductDao()
        {
            db = new PhamNgocAnhContext();
        }

        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products.OrderByDescending   (x => x.Unitcost);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.Quantity).ToPagedList(page, pageSize);
        }
    }
}
