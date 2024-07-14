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
    }
}
