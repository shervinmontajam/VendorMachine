using System;
using NUnit.Framework;
using VendorMachine.Entity;
using VendorMachine.Repository;

namespace VendorMachine.Service.Tests.MachineServiceTests
{
    public class ValidatePurchaseTests
    {
        private MachineService _machineService;

        [SetUp]
        public void Setup()
        {
            _machineService = new MachineService(new ProductRepository());
        }

        [Test]
        public void ShouldChangeTheCreditInsideMachine()
        {
            var product = new ProductRepository().GetProduct(1);

            _machineService.AddCredit(new Money(0, 0, 0, 2));

            Assert.DoesNotThrow(() => _machineService.ValidatePurchase(product));
        }

        [Test]
        public void ShouldThrowArgumentNullException()
        {
            _machineService.AddCredit(new Money(0, 0, 0, 2));

            Assert.Throws<ArgumentNullException>(() => _machineService.ValidatePurchase(null) );
        }


        [Test]
        public void ShouldThrowExceptionIfPortionIsZero()
        {
            var product = new ProductRepository().GetProduct(1);
            product.AvailablePortion = 0;

            _machineService.AddCredit(new Money(0, 0, 0, 2));

            Assert.Throws<Exception>(() => _machineService.ValidatePurchase(product), "Product is not available");
        }

        [Test]
        public void ShouldThrowExceptionIfCreditIsNotEnough()
        {
            var product = new ProductRepository().GetProduct(1);

            _machineService.AddCredit(new Money(1, 0, 0, 0));

            Assert.Throws<Exception>(() => _machineService.ValidatePurchase(product), "Insufficient amount");
        }


    }
}