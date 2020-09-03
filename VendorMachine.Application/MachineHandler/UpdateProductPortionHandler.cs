using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VendorMachine.Application.MachineHandler.Events;
using VendorMachine.Repository;

namespace VendorMachine.Application.MachineHandler
{
    public class UpdateProductPortionHandler : INotificationHandler<PurchaseCompleted>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductPortionHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task Handle(PurchaseCompleted notification, CancellationToken cancellationToken)
        {
            _productRepository.DecreasePortion(notification.ProductId);

            return Task.CompletedTask;
        }
    }
}
