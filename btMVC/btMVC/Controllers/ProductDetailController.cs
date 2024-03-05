using DataAccess.ProductNetFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btMVC.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var list = new List<ProductDetail>();
            try
            {
                list = new DataAccess.ProductNetFramework.DAOImpl.ProductDetailDAOImpl().GetProductDetailById(id);
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(list);
        }
    }
}