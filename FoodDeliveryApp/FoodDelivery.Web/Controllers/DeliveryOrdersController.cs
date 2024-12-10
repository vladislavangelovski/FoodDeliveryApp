using FoodDelivery.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodDelivery.Web.Controllers
{
    public class DeliveryOrdersController : Controller
    {
        private readonly IDeliveryService _service;

        public DeliveryOrdersController(IDeliveryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            return View(_service.GetDeliveryDetails(customerId ?? ""));
        }
        public IActionResult DeleteFoodItemFromDelivery(Guid? foodItemId)
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var result = _service.DeleteFromDelivery(customerId, foodItemId);

            return RedirectToAction("Index", "DeliveryOrders");
        }

        public IActionResult Order()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var result = _service.OrderFoodItems(customerId);

            return RedirectToAction("Index", "DeliveryOrders");
        }

        public IActionResult SuccessPayment()
        {
            return View();
        }

        //public IActionResult PayOrder(string stripeEmail, string stripeToken)
        //{
        //    StripeConfiguration.ApiKey = "sk_test_51Io84IHBiOcGzrvu4sxX66rTHq8r5nxIxRiJPbOHB4NwVJOE1jSlxgYe741ITs024uXhtpBFtxm3RoCZc3kafocC00IhvgxkL0";
        //    var customerService = new CustomerService();
        //    var chargeService = new ChargeService();
        //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var order = this._shoppingCartService.getShoppingCartInfo(userId);

        //    var customer = customerService.Create(new CustomerCreateOptions
        //    {
        //        Email = stripeEmail,
        //        Source = stripeToken
        //    });

        //    var charge = chargeService.Create(new ChargeCreateOptions
        //    {
        //        Amount = (Convert.ToInt32(order.TotalPrice) * 100),
        //        Description = "EShop Application Payment",
        //        Currency = "usd",
        //        Customer = customer.Id
        //    });

        //    if (charge.Status == "succeeded")
        //    {
        //        this.Order();
        //        return RedirectToAction("SuccessPayment");

        //    }
        //    else
        //    {
        //        return RedirectToAction("NotsuccessPayment");
        //    }
        //}
    }
}
