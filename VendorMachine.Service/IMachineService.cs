using VendorMachine.Entity;
using VendorMachine.Service.Model;

namespace VendorMachine.Service
{
    public interface IMachineService
    {
        MachineState GetMachineState();

        void AddCredit(Money money);

        void CancelPurchase();

        void ValidatePurchase(Product product);

        Money Purchase(Product product);

        void ResetCredit();
    }
}