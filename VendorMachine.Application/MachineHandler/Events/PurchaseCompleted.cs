using MediatR;

namespace VendorMachine.Application.MachineHandler.Events
{
    public class PurchaseCompleted : INotification
    {
        public int ProductId { get; set; }
    }
}
