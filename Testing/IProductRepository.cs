using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        
        //Part Two of assignment - to view one product at a time
        public Product GetProduct(int id);

        //Part Three of assignment - allowing user to make updates to a product - make void
        public void UpdateProduct(Product product);

        //We add the below three for part 4 of the exercise
        //since they need to create a new product.. we have to give them the option to add info for multiple parts of the product
        public void InsertProduct(Product productToInsert);
        public IEnumerable<Category> GetCategories();
        public Product AssignCategory();

        //part 5 new stubbed out method to use DeleteProduct
        public void DeleteProduct(Product product);
    }
}
