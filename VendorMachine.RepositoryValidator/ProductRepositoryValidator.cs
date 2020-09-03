using System;
using VendorMachine.Repository;

namespace VendorMachine.RepositoryValidator
{

    public sealed class ProductRepositoryValidator: IProductRepositoryValidator
    {
        private readonly IProductRepository _productRepository;

        public ProductRepositoryValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void ValidateProductExists(int productId)
        {
            var product = _productRepository.GetProduct(productId);

            if (product == null)
                throw new Exception($"Could not find the product with the Id:{productId}");
        }

        public void ValidateDecreasePortion(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
