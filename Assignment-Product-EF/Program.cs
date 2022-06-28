using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Product_EF
{
    class Program
    {
        private static int OperationSelection()
        {
            Console.WriteLine("Press 1 to add product details ");
            Console.WriteLine("Press 2 to view all product's details ");
            Console.WriteLine("Press 3 to view all product's details with price greater than 1000 ");
            Console.WriteLine("Press 4 to remove all product's details ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("***PRODUCT MANAGEMENT***"); Console.WriteLine();
                string n;
                do
                {
                    int userInput = OperationSelection();
                    ProductRepository productRepository = new ProductRepository();
                    switch (userInput)
                    {
                        case 1:
                            Product firstProduct = new Product();
                            Console.Write("Enter product name :");
                            firstProduct.Name = Console.ReadLine();
                            Console.Write("Enter product description :");
                            firstProduct.Description =Console.ReadLine();
                            Console.Write("Enter manufactured by :");
                            firstProduct.ManufacturedBy = Console.ReadLine();
                            Console.Write("Enter product price :");
                            firstProduct.Price = Convert.ToInt32(Console.ReadLine());
                            productRepository.AddProduct(firstProduct);
                            break;
                        case 2:
                            var products = productRepository.GetAllProducts();
                            foreach (var product in products)
                            {
                                Console.WriteLine($"Id-{product.Id},Name-{product.Name},Description-{product.Description},ManufacturedBy-{product.ManufacturedBy},Price-{product.Price}");
                            }
                           break;
                        case 3:
                            var productsPrice = productRepository.GetAllProducts();
                            foreach (var product in productsPrice)
                            {
                                if(product.Price>1000)
                                Console.WriteLine($"Id-{product.Id},Name-{product.Name},Description-{product.Description},ManufacturedBy-{product.ManufacturedBy},Price-{product.Price}");
                            }
                            break;
                        case 4:
                            productRepository.DeleteProduct();
                            break;

                        default:
                            Console.WriteLine("Invalid Option");
                            break;

                    }
                    Console.WriteLine();
                    Console.WriteLine("Press Y to continue");
                    n = Console.ReadLine();
                }
                while (n == "y" || n == "Y");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
