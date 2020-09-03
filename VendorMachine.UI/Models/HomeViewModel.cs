using System.Collections.Generic;
using VendorMachine.Entity;

namespace VendorMachine.UI.Models
{
    public class HomeViewModel
    {
        public string Message { get; set; }

        public IReadOnlyList<Product> Products { get; set; }

        public Money Credit { get; set; }
    }
}
