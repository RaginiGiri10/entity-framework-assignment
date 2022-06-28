using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Product_EF
{
    class ProductRepository
    {
        public List<Product> GetAllProducts()
        {
            List<Product> productList = null;
            using (ProductDBEntities productDBEntities = new ProductDBEntities())
            {
                productList = new List<Product>();
                productList = productDBEntities.Products.ToList();
            }

            return productList;
        }
       

       
        public void AddProduct(Product product)
        {
            using (ProductDBEntities productDBEntities = new ProductDBEntities())
            {
                productDBEntities.Products.Add(product);
                productDBEntities.SaveChanges();
            }
        }
        public void DeleteProduct()
        {
           
            using (ProductDBEntities productDBEntities = new ProductDBEntities())
            {
                var allProducts = from m in productDBEntities.Products
                                  select m;
                foreach (var allproduct in allProducts)
                {
                    productDBEntities.Products.Remove(allproduct);
                }
                    productDBEntities.SaveChanges();
                    Console.WriteLine("All Product deleted");

                
              
            }

        }


    }
}
