using FoodDelivery.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Service.Interface
{
    public interface IRestaurantService
    {
        public List<Restaurant> GetRestaurants();
        public Restaurant GetRestaurantById(Guid? id);
        public Restaurant CreateNewRestaurant(Restaurant restaurant);
        public Restaurant UpdateRestaurant(Restaurant restaurant);
        public Restaurant DeleteRestaurant(Guid id);
    }
}
