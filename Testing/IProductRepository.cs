﻿using System;
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
    }
}
