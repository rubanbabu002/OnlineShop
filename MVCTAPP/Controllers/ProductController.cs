using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTAPP.Repository;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
;

namespace MVCTAPP.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult GetAllProducts()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Product/getallproducts");
                response.EnsureSuccessStatusCode();
                List<Models.Product> products = response.Content.ReadAsAsync<List<Models.Product>>().Result;
                ViewBag.Title = "All Products";
                return View(products);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditProduct(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Product/GetProduct?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Product products = response.Content.ReadAsAsync<Models.Product>().Result;
            ViewBag.Title = "All Products";
            return View(products);
        }
        //[HttpPost]  
        public ActionResult Update(Models.Product product)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Product/UpdateProduct", product);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllProducts");
        }
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/showroom/GetProduct?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Product products = response.Content.ReadAsAsync<Models.Product>().Result;
            ViewBag.Title = "All Products";
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Product product)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Product/InsertProduct", product);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllProducts");
        }
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Product/DeleteProduct?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllProducts");
        }  
    }
}
