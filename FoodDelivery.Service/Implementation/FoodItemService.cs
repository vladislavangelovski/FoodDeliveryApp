using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Domain.DTO;
using FoodDelivery.Repository.Interface;
using FoodDelivery.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Service.Implementation
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IRepository<FoodItem> _foodItemRepository;
        private readonly IRepository<Restaurant> _restaurantRepository;

        public FoodItemService(IRepository<FoodItem> foodItemRepository, IRepository<Restaurant> restaurantRepository)
        {
            _foodItemRepository = foodItemRepository;
            _restaurantRepository = restaurantRepository;
        }

        public void AddFoodItemToRestaurant(AddFoodItemToRestaurantDTO addFoodItemToRestaurantDTO)
        {
            Restaurant restaurant = _restaurantRepository.Get(addFoodItemToRestaurantDTO.RestaurantId);
            FoodItem newFoodItem = new FoodItem()
            {
                Id = Guid.NewGuid(),
                Name = addFoodItemToRestaurantDTO.Name,
                Price = addFoodItemToRestaurantDTO.Price,
                Description = addFoodItemToRestaurantDTO.Description,
                Image = addFoodItemToRestaurantDTO.ImageUrl,
                Category = addFoodItemToRestaurantDTO.Category,
                Restaurant = restaurant,
                RestaurantId = addFoodItemToRestaurantDTO.RestaurantId
            };
            _foodItemRepository.Insert(newFoodItem);
        }

        public FoodItem CreateNewFoodItem(FoodItem foodItem)
        {
            return _foodItemRepository.Insert(foodItem);
        }

        public FoodItem DeleteFoodItem(Guid id)
        {
            var foodItem_to_delete = this.GetFoodItemById(id);
            return _foodItemRepository.Delete(foodItem_to_delete);
        }

        public FoodItem GetFoodItemById(Guid? id)
        {
            return _foodItemRepository.Get(id);
        }

        public List<FoodItem> GetFoodItems()
        {
            return _foodItemRepository.GetAll().ToList();
        }

        public List<FoodItem> ShowFoodItemsInRestaurant(Guid restaurantId)
        {
            return _foodItemRepository.GetAll().Where(z => z.RestaurantId == restaurantId).ToList();
        }

        public FoodItem UpdateFoodItem(FoodItem foodItem)
        {
            return _foodItemRepository.Update(foodItem);
        }
    }
}
