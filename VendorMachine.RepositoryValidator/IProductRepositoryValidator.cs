namespace VendorMachine.RepositoryValidator
{
    public interface IProductRepositoryValidator
    {
        void ValidateProductExists(int productId);
        void ValidateDecreasePortion(int productId);
    }
}