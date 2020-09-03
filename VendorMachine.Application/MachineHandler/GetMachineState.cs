using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VendorMachine.Service;
using VendorMachine.Service.Model;

namespace VendorMachine.Application.MachineHandler
{
    public class GetMachineState
    {
        public class Query : IRequest<MachineState>
        {
        }

        public class Handler : IRequestHandler<Query, MachineState>
        {
            private readonly IMachineService _machineService;

            public Handler(IMachineService machineService)
            {
                _machineService = machineService;
            }

            public async Task<MachineState> Handle(Query request, CancellationToken cancellationToken)
            {
                var machineState =  _machineService.GetMachineState();

                return await Task.FromResult(machineState);
            }
        }
    }
}
