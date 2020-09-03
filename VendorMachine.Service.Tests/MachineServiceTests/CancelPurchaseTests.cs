using NUnit.Framework;
using VendorMachine.Entity;
using VendorMachine.Repository;

namespace VendorMachine.Service.Tests.MachineServiceTests
{
    public class CancelPurchaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldResetTheCreditToZero()
        {
            var machineService = new MachineService(new ProductRepository());

            machineService.AddCredit(new Money(1,0,0,0));
            machineService.CancelPurchase();


            Assert.AreEqual(machineService.Machine.CreditMoney.Total, Money.Zero.Total);
        }
    }
}