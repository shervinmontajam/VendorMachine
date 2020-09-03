using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VendorMachine.Application.MachineHandler.Events;
using VendorMachine.Service;

namespace VendorMachine.Application.MachineHandler
{
    public class ResetMachineCreditHandler : INotificationHandler<PurchaseCompleted>
    {
        private readonly IMachineService _machineService;


        public ResetMachineCreditHandler(IMachineService machineService)
        {
            _machineService = machineService;
        }

        public Task Handle(PurchaseCompleted notification, CancellationToken cancellationToken)
        {
            _machineService.ResetCredit();

            return Task.CompletedTask;
        }
    }
}
