using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VendorMachine.Entity;
using VendorMachine.Service;

namespace VendorMachine.Application.MachineHandler
{
    public class AddCredit
    {
        public class Command : IRequest<Unit>
        {
            public Money Money { get; set; }
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
                _machineService.AddCredit(command.Money);

                return await Task.FromResult(Unit.Value);
            }
        }
    }
}
