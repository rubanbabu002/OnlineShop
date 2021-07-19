using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAL
    {
        static TestDBEntities DbContext;
        static DAL()
        {
            DbContext = new TestDBEntities();
        }
        public static List<ProductTbl> GetAllProducts()
        {
            return DbContext.ProductTbls.ToList();
        }
        public static ProductTbl GetProduct(int productId)
        {
            return DbContext.ProductTbls.Where(p => p.ProductId == productId).FirstOrDefault();
        }
        public static bool InsertProduct(ProductTbl productItem)
        {
            bool status;
            try
            {
                DbContext.ProductTbls.Add(productItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateProduct(ProductTbl productItem)
        {
            bool status;
            try
            {
                ProductTbl prodItem = DbContext.ProductTbls.Where(p => p.ProductId == productItem.ProductId).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.ProductName = productItem.ProductName;
                    prodItem.Quantity = productItem.Quantity;
                    prodItem.Price = productItem.Price;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteProduct(int id)
        {
            bool status;
            try
            {
                ProductTbl prodItem = DbContext.ProductTbls.Where(p => p.ProductId == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContext.ProductTbls.Remove(prodItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}