using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using VendorMachine.Application.MachineHandler;
using VendorMachine.Application.MachineHandler.Events;
using VendorMachine.Entity;
using VendorMachine.UI.Models;

namespace VendorMachine.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return await RedirectToHome();
        }

        [HttpPost]
        public async Task<IActionResult> Purchase(int id)
        {
            var output = await _mediator.Send(new Purchase.Command { ProductId = id });

            if (!string.IsNullOrEmpty(output.Message))
                return await RedirectToHome($"Error: {output.Message}");


            await _mediator.Publish(new PurchaseCompleted {ProductId = id});

            return await RedirectToHome($"Info: Thank You! - Return ({output.ReturnMoney.Total}) - Coins [1 Euro {output.ReturnMoney.OneEuroCount}] [0.50 Cent {output.ReturnMoney.FiftyCentCount}] [0.20 Cent {output.ReturnMoney.TwentyCentCount}] [0.10 Cent {output.ReturnMoney.TenCentCount}]");
        }

        [HttpPost]
        public async Task<IActionResult> AddCredit(decimal amount)
        {
            await _mediator.Send(new AddCredit.Command { Money = GetMoneyByAmount(amount) });

            return await RedirectToHome("Info: Added Coin " + amount);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel()
        {
            await _mediator.Send(new CancelPurchase.Command());

            return await RedirectToHome("Error: You Canceled");
        }

        private async Task<IActionResult> RedirectToHome(string message = null)
        {
            var machineState = await _mediator.Send(new GetMachineState.Query());

            var model = new HomeViewModel
            {
                Message = message,
                Products = machineState.Products,
                Credit = machineState.CreditMoney
            };

            return View("Index", model);
        }

        private Money GetMoneyByAmount(decimal amount)
        {
            switch (amount)
            {
                case 1:
                    return Money.OneEuro;
                case 0.50m:
                    return Money.FiftyCent;
                case 0.20m:
                    return Money.TwentyCent;
                case 0.10m:
                    return Money.TenCent;
                default:
                    return Money.Zero;
            }
        }
































        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
