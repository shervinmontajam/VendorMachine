using VendorMachine.Entity;

namespace VendorMachine.Application.MachineHandler.Models
{
    public class PurchaseOutput
    {
        public string Message { get; set; }

        public Money ReturnMoney { get; set; }
    }
}
