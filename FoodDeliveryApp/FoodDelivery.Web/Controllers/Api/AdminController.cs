using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IOrderService _orderService;
       

        public AdminController(IRestaurantService restaurantService, IOrderService orderService)
        {
            _restaurantService = restaurantService;
            _orderService = orderService;
        }

        [HttpGet("[action]")]
        public List<Restaurant> GetAllRestaurants() { 
            return _restaurantService.GetRestaurants();
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
    }
}
