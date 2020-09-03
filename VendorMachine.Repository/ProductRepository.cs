using System;
using System.Collections.Generic;
using System.Linq;
using VendorMachine.Entity;

namespace VendorMachine.Repository
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>
            {
                new Product{Id = 1,Name = "Tea", Price = 1.30m, AvailablePortion = 10},
                new Product{Id = 2,Name = "Espresso", Price = 1.80m, AvailablePortion = 20},
                new Product{Id = 3,Name = "Juice", Price = 1.30m, AvailablePortion = 20},
                new Product{Id = 4,Name = "Chicken Soup", Price = 1.30m, AvailablePortion = 15}
            };
        }

        public void DecreasePortion(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new Exception($"Could not find the product with the Id:{productId}");

            product.AvailablePortion -= 1;
        }

        public Product GetProduct(int productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        public IReadOnlyList<Product> GetProducts()
        {
            return _products;
        }
    }
}
