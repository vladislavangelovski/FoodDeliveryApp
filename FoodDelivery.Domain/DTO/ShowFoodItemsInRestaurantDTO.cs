using FoodDelivery.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DTO
{
    public class ShowFoodItemsInRestaurantDTO
    {
        public Restaurant Restaurant{ get; set; }
        public List<FoodItem> FoodItemsInRestaurant{ get; set; }
        public AddFoodItemToRestaurantDTO NewFoodItem { get; set; } = new AddFoodItemToRestaurantDTO();
    }
}
