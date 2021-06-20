using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private PhamNgocAnhContext db = new PhamNgocAnhContext();

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
    }
}
