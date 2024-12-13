using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IOrderService _orderService;
        private readonly IFoodItemService _foodItemService;
       

        public AdminController(IRestaurantService restaurantService, IOrderService orderService, IFoodItemService foodItemService)
        {
            _restaurantService = restaurantService;
            _orderService = orderService;
            _foodItemService = foodItemService;
        }

        [HttpGet("[action]")]
        public List<Restaurant> GetAllRestaurants() { 
            return _restaurantService.GetRestaurants();
        }
        [HttpPost("[action]")]
        public Restaurant GetRestaurantDetails(BaseEntity id)
        {
            return this._restaurantService.GetRestaurantDetails(id);
        }



        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return this._orderService.GetAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetOrderDetails(BaseEntity id)
        {
            return this._orderService.GetOrderDetails(id);
        }

        [HttpPost("[action]")]
        public bool ImportRestaurants(List<Restaurant> model)
        {
            bool status = true;

            foreach (var item in model)
            {
                var restaurant = new Restaurant
                {
                    Name = item.Name,
                    Address = item.Address,
                    PhoneNumber = item.PhoneNumber,
                    Description = item.Description,
                    Image = item.Image,
                    Rating = item.Rating,
                    FoodItems = new List<FoodItem>(),
                    Ratings = item.Ratings,               
                };

                var result = _restaurantService.CreateNewRestaurant(restaurant);

                if(result != null)
                {
                    var foodItems = item.FoodItems ?? new List<FoodItem>();
                    if (item.FoodItems != null)
                    {
                        foreach (var tmp in item?.FoodItems)
                        {
                            if(tmp != null)
                            {
                                var fooditem = new FoodItem
                                {
                                    Name = tmp.Name,
                                    Price = tmp.Price,
                                    Description = tmp.Description,
                                    Image = tmp.Image,
                                    Category = tmp.Category,
                                    RestaurantId = result.Id,
                                    TimeToPrepareMinutes = tmp.TimeToPrepareMinutes,
                                    Restaurant = result,
                                    FoodItemInDeliveries = new List<FoodItemInDelivery>(),
                                    FoodItemInOrders = new List<FoodItemInOrder>(),
                                };

                                var result1 = _foodItemService.CreateNewFoodItem(fooditem);
                                if(result1 != null)
                                    restaurant.FoodItems.Add(fooditem);
                            }
                        }
                    }
                }
                status = status && (result != null); 

            }
            return status;
        }
    }
}
