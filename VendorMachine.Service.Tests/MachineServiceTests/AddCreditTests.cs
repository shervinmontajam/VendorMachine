using NUnit.Framework;
using VendorMachine.Entity;
using VendorMachine.Repository;

namespace VendorMachine.Service.Tests.MachineServiceTests
{
    public class AddCreditTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldChangeTheCreditInsideMachine()
        {
            var machineService = new MachineService(new ProductRepository());

            machineService.AddCredit(new Money(1,0,0,0));

            Assert.AreEqual(machineService.Machine.CreditMoney.Total, Money.TenCent.Total);
        }
    }
}