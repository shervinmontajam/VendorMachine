using System;
using VendorMachine.Entity;
using VendorMachine.Repository;

namespace VendorMachine.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var machineMoney = new Money(10, 10, 10, 10);
            var transactionMoney = new Money(0, 0, 2, 2);

            var itemPrice = 1.20m;


            System.Console.WriteLine(machineMoney.Total);

            ShowProductList();

            //PerformTransaction(itemPrice, machineMoney, transactionMoney);
        }

        static void PerformTransaction(decimal itemPrice, Money machineMoney, Money transactionMoney)
        {
            if (itemPrice > transactionMoney.Total)
                throw new Exception("Money is not enough");

            machineMoney += transactionMoney;

            System.Console.WriteLine(machineMoney.Total);



            var returnValue = transactionMoney.Total - itemPrice;
            var returnMoney = Money.Zero;
            while (returnValue > 0.00m)
            {
                if (returnValue >= 1)
                {
                    returnMoney += Money.OneEuro;
                    machineMoney -= Money.OneEuro;
                    returnValue -= 1;
                    continue;
                }

                if (returnValue >= 0.50m)
                {
                    returnMoney += Money.FiftyCent;
                    machineMoney -= Money.FiftyCent;
                    returnValue -= 0.50m;
                    continue;
                }

                if (returnValue >= 0.20m)
                {
                    returnMoney += Money.TwentyCent;
                    machineMoney -= Money.TwentyCent;
                    returnValue -= 0.20m;
                    continue;
                }

                if (returnValue >= 0.10m)
                {
                    returnMoney += Money.TenCent;
                    machineMoney -= Money.TenCent;
                    returnValue -= 0.10m;
                }

            }



            System.Console.WriteLine($"Total Return: {returnMoney.Total} [1 Euro Coins: {returnMoney.OneEuroCount}] [50 Cent Coins: {returnMoney.FiftyCentCount}] [20 Cent Coins: {returnMoney.TwentyCentCount}] [10 Cent Coins: {returnMoney.TenCentCount}]"  );

            transactionMoney = Money.Zero;
        }

        static void ShowProductList()
        {
            IProductRepository _productRepository = new ProductRepository();

            _productRepository.DecreasePortion(1);

            foreach (var product in _productRepository.GetProducts())
            {
                System.Console.WriteLine(product.AvailablePortion);
            }
        }


    }
}
