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
        private readonly 

        public AdminController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("[action]")]
        public List<Restaurant> GetAllRestaurants() { 
            return _restaurantService.GetRestaurants();
        }
        //[HttpGet("[action]")]
        //public List<Order> GetAllOrders()
        //{
        //    return this._orderService.GetAllOrders();
        //}
        //[HttpPost("[action]")]
        //public Order GetDetails(BaseEntity id)
        //{
        //    return this._orderService.GetDetailsForOrder(id);
        //}
    }
}
