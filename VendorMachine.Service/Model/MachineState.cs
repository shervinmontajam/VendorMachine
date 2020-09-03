using System.Collections.Generic;
using VendorMachine.Entity;

namespace VendorMachine.Service.Model
{
    public class MachineState
    {
        public IReadOnlyList<Product> Products { get; set; }

        public Money CreditMoney { get; set; }
    }
}
