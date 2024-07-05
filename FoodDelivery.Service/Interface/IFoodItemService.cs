﻿using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Service.Interface
{
    public interface IFoodItemService
    {
        public List<FoodItem> GetFoodItems();
        public FoodItem GetFoodItemById(Guid? id);
        public FoodItem CreateNewFoodItem(FoodItem foodItem);
        public FoodItem UpdateFoodItem(FoodItem foodItem);
        public FoodItem DeleteFoodItem(Guid id);
        public void AddFoodItemToRestaurant(AddFoodItemToRestaurantDTO addFoodItemToRestaurantDTO);
        public List<RestaurantFoodItem> ShowFoodItemsInRestaurant(Guid restaurantId);
    }
}