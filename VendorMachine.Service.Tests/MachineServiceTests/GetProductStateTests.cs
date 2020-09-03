using NUnit.Framework;
using VendorMachine.Entity;
using VendorMachine.Repository;

namespace VendorMachine.Service.Tests.MachineServiceTests
{
    public class GetProductStateTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldReturnCorrectMachineStateObject()
        {
            var machineService = new MachineService(new ProductRepository());

            var machineState = machineService.GetMachineState();

            Assert.AreEqual(machineState.CreditMoney.Total, Money.Zero.Total);
            Assert.AreEqual(machineState.Products.Count, 4);
        }
    }
}