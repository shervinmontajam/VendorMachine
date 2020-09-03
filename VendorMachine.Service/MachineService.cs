using System;
using VendorMachine.Entity;
using VendorMachine.Repository;
using VendorMachine.Service.Model;

namespace VendorMachine.Service
{
    public class MachineService : IMachineService
    {
        private readonly IProductRepository _productRepository;
        public Machine Machine { get; }

        public MachineService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            Machine = new Machine
            {
                MachineMoney = new Money(100, 100, 100, 100),
                CreditMoney = Money.Zero
            };
        }

        public MachineState GetMachineState()
        {
            return new MachineState
            {
                Products = _productRepository.GetProducts(),
                CreditMoney = Machine.CreditMoney
            };
        } 

        public void AddCredit(Money money)
        {
            Machine.CreditMoney += money;
        }

        public void CancelPurchase()
        {
            Machine.CreditMoney = Money.Zero;
        }

        public void ValidatePurchase(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (product.AvailablePortion == 0)
                throw new Exception("Product is not available");

            if (product.Price > Machine.CreditMoney.Total)
                throw new Exception("Insufficient amount");
        }

        public Money Purchase(Product product)
        {
            ValidatePurchase(product);

            Machine.MachineMoney += Machine.CreditMoney;

            var returnMoney = ProcessReturnMoney(product);

            return returnMoney;
        }

        private Money ProcessReturnMoney(Product product)
        {
            var returnValue = Machine.CreditMoney.Total - product.Price;
            var returnMoney = Money.Zero;
            
            while (returnValue > 0.00m)
            {
                if (returnValue >= 1)
                {
                    returnMoney += Money.OneEuro;
                    Machine.MachineMoney -= Money.OneEuro;
                    returnValue -= 1;
                    continue;
                }

                if (returnValue >= 0.50m)
                {
                    returnMoney += Money.FiftyCent;
                    Machine.MachineMoney -= Money.FiftyCent;
                    returnValue -= 0.50m;
                    continue;
                }

                if (returnValue >= 0.20m)
                {
                    returnMoney += Money.TwentyCent;
                    Machine.MachineMoney -= Money.TwentyCent;
                    returnValue -= 0.20m;
                    continue;
                }

                if (returnValue >= 0.10m)
                {
                    returnMoney += Money.TenCent;
                    Machine.MachineMoney -= Money.TenCent;
                    returnValue -= 0.10m;
                }

            }

            return returnMoney;
        }

        public void ResetCredit()
        {
            Machine.CreditMoney = Money.Zero;
        }


    }
}
