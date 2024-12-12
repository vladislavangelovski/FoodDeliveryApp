using System.Text;
using FoodDeliveryAdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodDeliveryAdminApp.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:5070/api/Admin/GetAllRestaurants";

            HttpResponseMessage response = client.GetAsync(url).Result;

            var data = response.Content.ReadAsAsync<List<Restaurant>>().Result;

            return View(data);
        }

        public IActionResult Details(Guid id)
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5070/api/Admin/GetRestaurantDetails";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var data = response.Content.ReadAsAsync<Restaurant>().Result;


            return View(data);

        }
    }
}
