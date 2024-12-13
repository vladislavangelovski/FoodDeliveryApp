using System.Text;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using ExcelDataReader;
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

        public IActionResult ImportIndex()
        {
            return View();
        }

        public IActionResult ImportRestaurants(IFormFile file)
        {
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            List<Restaurant> restaurants = getAllRestaurantsFromFile(file.FileName);

            HttpClient client = new HttpClient();
            string URL = "http://localhost:5070/api/Admin/ImportRestaurants";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(restaurants), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<bool>().Result;

            return RedirectToAction("Index", "Restaurant");
        }

        private List<Restaurant> getAllRestaurantsFromFile(string fileName)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        var restaurant = restaurants.FirstOrDefault(r => r.Name == reader.GetValue(0).ToString());

                        if (restaurant == null)
                        {
                            restaurant = new Models.Restaurant
                            {
                                Name = reader.GetValue(0).ToString(),
                                Address = reader.GetValue(1).ToString(),
                                PhoneNumber = reader.GetValue(2).ToString(),
                                Description = reader.GetValue(3).ToString(),
                                Image = reader.GetValue(4).ToString(),
                                Rating = Convert.ToDouble(reader.GetValue(5)),
                                FoodItems = new List<FoodItem>(),
                                Ratings = new List<Rating>(),
                            };

                            restaurants.Add(restaurant);
                        }

                        int i = 6;
                        while(i < reader.FieldCount && reader.GetValue(i) != null && reader.GetValue(i).ToString() != "")
                        {
                            if( i+5 < reader.FieldCount)
                            {
                                var fooditem = new Models.FoodItem
                                {
                                    Name = reader.GetValue(i).ToString(),
                                    Price = Convert.ToDouble(reader.GetValue(i + 1)),
                                    Description = reader.GetValue(i + 2).ToString(),
                                    Image = reader.GetValue(i + 3).ToString(),
                                    Category = reader.GetValue(i + 4).ToString(),
                                    RestaurantId = restaurant.Id,
                                    TimeToPrepareMinutes = (int)Convert.ToDouble(reader.GetValue(i + 5)),
                                    FoodItemInDeliveries = new List<FoodItemInDelivery>(),
                                    FoodItemInOrders = new List<FoodItemInOrder>()
                                };

                                restaurant.FoodItems.Add(fooditem);
                             
                            }
                            else
                            {
                                break;
                            }
                            i += 6;
                        }
                      
                    }

                }
            }
            return restaurants;

        }
    }
}
