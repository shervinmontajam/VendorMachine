using System;
using NUnit.Framework;
using VendorMachine.Entity;
using VendorMachine.Repository;

namespace VendorMachine.Service.Tests.MachineServiceTests
{
    public class PurchaseTests
    {
        private MachineService _machineService;

        [SetUp]
        public void Setup()
        {
            _machineService = new MachineService(new ProductRepository());
        }

        [Test]
        public void ShouldUpdateMachineMoneyAndReturnMoney()
        {
            var product = new ProductRepository().GetProduct(1);

            _machineService.AddCredit(new Money(0, 0, 0, 2));
            var returnMoney = _machineService.Purchase(product);

            Assert.AreEqual(_machineService.Machine.MachineMoney.Total, new Money(100,99,99,102).Total);
            Assert.AreEqual(returnMoney.Total, new Money(0,1,1,0).Total);
        }




    }
}