namespace VendorMachine.Entity
{
    public sealed class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AvailablePortion { get; set; }

        public decimal Price { get; set; }
    }
}
