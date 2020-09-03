using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VendorMachine.Application.MachineHandler.Models;
using VendorMachine.Entity;
using VendorMachine.Repository;
using VendorMachine.Service;

namespace VendorMachine.Application.MachineHandler
{
    public class Purchase
    {
        public class Command : IRequest<PurchaseOutput>
        {
            public int ProductId { get; set; }
        }

        public class Handler : IRequestHandler<Command, PurchaseOutput>
        {
            private readonly IMachineService _machineService;
            private readonly IProductRepository _productRepository;

            public Handler(IMachineService machineService, IProductRepository productRepository)
            {
                _machineService = machineService;
                _productRepository = productRepository;
            }

            public async Task<PurchaseOutput> Handle(Command command, CancellationToken cancellationToken)
            {
                var purchaseOutput = new PurchaseOutput{ReturnMoney = Money.Zero};
                try
                {
                    var product = _productRepository.GetProduct(command.ProductId);
                    _machineService.ValidatePurchase(product);
                    purchaseOutput.ReturnMoney = _machineService.Purchase(product);
                }
                catch (ArgumentNullException exception)
                {
                    purchaseOutput.Message = exception.Message;
                }
                catch (Exception exception)
                {
                    purchaseOutput.Message = exception.Message;
                }
                

                return await Task.FromResult(purchaseOutput);
            }
        }
    }
}
