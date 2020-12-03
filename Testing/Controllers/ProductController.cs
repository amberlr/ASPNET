using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index() //this is looking at the Index.cshtml file
        {
            var products = repo.GetAllProducts();

            return View(products);
        }

        //create a ViewProduct() method here and in the scope call out to GetProduct method which will view a single product with return
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);

            return View(product);
        }

        //create UpdateProduct() controller method here
        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);

            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        //add UpdateProductToDatabase here - not the same as UpdateProduct() above
        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        //part 4 of exercise to add below 2 controller methods
        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();

            return View(prod);
        }
        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }

    }
}
