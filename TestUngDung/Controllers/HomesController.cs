using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;
using ModelEF.DAO;
using PagedList;
using TestUngDung.Common;

namespace TestUngDung.Controllers
{
    public class HomesController : Controller
    {
        private PhamNgocAnhContext db = new PhamNgocAnhContext();
        // GET: Homes
        public ActionResult Index(string searchString, int page = 1, int pageSize = 6)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);

        }
    }
}