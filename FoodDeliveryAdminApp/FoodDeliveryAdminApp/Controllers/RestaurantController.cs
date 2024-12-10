using FoodDeliveryAdminApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAdminApp.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:7231/api/Admin/GetAllRestaurants";

            HttpResponseMessage response = client.GetAsync(url).Result;

            var data = response.Content.ReadAsAsync<List<Restaurant>>().Result;

            return View(data);
        }
    }
}
