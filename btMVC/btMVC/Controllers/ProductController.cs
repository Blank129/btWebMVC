using btMVC.Models;
using DataAccess.ProductNetFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult listPartialProduct(GetListProduct requestData)
        {
            var list = new List<Product>();
            try
            {
                list = new DataAccess.ProductNetFramework.DAOImpl.ProductDAOImpl().GetProduct(requestData.ProductName);
            }
            catch (Exception ex)
            {

                throw;
            }
            return PartialView(list);
        }
        [HttpPost]
        public JsonResult ProductDelete(int id)
        {
            var returnData = new ReturnData();
            try
            {
                var rs = new DataAccess.ProductNetFramework.DAOImpl.ProductDAOImpl().ProductDelete(Convert.ToInt32(id));
                return Json(rs, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                returnData.returnCode = -999;
                returnData.returnMessage = "Hệ thống đang bận";
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetProductById(int id)
        {
            var model = new Product();
            try
            {
                if(model != null)
                {
                    model = new DataAccess.ProductNetFramework.DAOImpl.ProductDAOImpl().GetProductbyId(Convert.ToInt32(id));
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(model);
        }

        public JsonResult ProductUpdate(Product product)
        {
            var returnData = new ReturnData();
            try
            {
                // ok ròi đấy
                var rs = new DataAccess.ProductNetFramework.DAOImpl.ProductDAOImpl().ProductUpdate(product);
                return Json(rs, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                returnData.returnCode = -999;
                returnData.returnMessage = "Hệ thống đang bận";
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Add(Product product)
        {
            var returnData = new ReturnData();
            try
            {
                var rs = new DataAccess.ProductNetFramework.DAOImpl.ProductDAOImpl().ProductAdd(product);
                return Json(rs, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                returnData.returnCode = -999;
                returnData.returnMessage = "Hệ thống đang bận";
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}