using System.Collections.Generic;
using VendorMachine.Entity;

namespace VendorMachine.Repository
{
    public interface IProductRepository
    {
        void DecreasePortion(int productId);

        Product GetProduct(int productId);

        IReadOnlyList<Product> GetProducts();
        
    }
}