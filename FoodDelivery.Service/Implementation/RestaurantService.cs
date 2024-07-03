using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Repository.Interface;
using FoodDelivery.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Service.Implementation
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepository;

        public RestaurantService(IRepository<Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Restaurant CreateNewRestaurant(Restaurant restaurant)
        {
            return _restaurantRepository.Insert(restaurant);
        }

        public Restaurant DeleteRestaurant(Guid id)
        {
            var restaurant = this.GetRestaurantById(id);
            return _restaurantRepository.Delete(restaurant);
        }

        public Restaurant GetRestaurantById(Guid? id)
        {
            return _restaurantRepository.Get(id);
        }

        public List<Restaurant> GetRestaurants()
        {
            return _restaurantRepository.GetAll().ToList();
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            return _restaurantRepository.Update(restaurant);
        }
    }
}
