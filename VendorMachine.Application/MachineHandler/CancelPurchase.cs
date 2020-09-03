using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VendorMachine.Service;

namespace VendorMachine.Application.MachineHandler
{
    public class CancelPurchase
    {
        public class Command : IRequest<Unit>
        {
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IMachineService _machineService;

            public Handler(IMachineService machineService)
            {
                _machineService = machineService;
            }

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                _machineService.CancelPurchase();

                return await Task.FromResult(Unit.Value);
            }
        }
    }
}
