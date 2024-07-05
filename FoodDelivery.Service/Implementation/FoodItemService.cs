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
        private IRepository<RestaurantFoodItem> _restaurantFoodItemRepository;

        public FoodItemService(IRepository<FoodItem> foodItemRepository, IRepository<Restaurant> restaurantRepository, IRepository<RestaurantFoodItem> restaurantFoodItemRepository)
        {
            _foodItemRepository = foodItemRepository;
            _restaurantRepository = restaurantRepository;
            _restaurantFoodItemRepository = restaurantFoodItemRepository;
        }

        public void AddFoodItemToRestaurant(AddFoodItemToRestaurantDTO addFoodItemToRestaurantDTO)
        {
            FoodItem newFoodItem = new FoodItem()
            {
                Id = Guid.NewGuid(),
                Name = addFoodItemToRestaurantDTO.Name,
                Price = addFoodItemToRestaurantDTO.Price,
                Description = addFoodItemToRestaurantDTO.Description,
                Image = addFoodItemToRestaurantDTO.ImageUrl
            };
            _foodItemRepository.Insert(newFoodItem);
            RestaurantFoodItem restaurantFoodItem = new RestaurantFoodItem()
            {
                Id = Guid.NewGuid(),
                FoodItemId = newFoodItem.Id,
                FoodItem = _foodItemRepository.Get(newFoodItem.Id),
                RestaurantId = addFoodItemToRestaurantDTO.RestaurantId,
                Restaurant = _restaurantRepository.Get(addFoodItemToRestaurantDTO.RestaurantId)
            };
            _restaurantFoodItemRepository.Insert(restaurantFoodItem);
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

        public List<RestaurantFoodItem> ShowFoodItemsInRestaurant(Guid restaurantId)
        {
            //var restaurant = _restaurantRepository.Get(restaurantId);
            //var allFoodItemsInRestaurant = restaurant.restaurantFoodItems.Where(z => z.RestaurantId == restaurantId).ToList();
            //return allFoodItemsInRestaurant;
            return _restaurantFoodItemRepository.GetAll().Where(z => z.RestaurantId == restaurantId).ToList();
        }

        public FoodItem UpdateFoodItem(FoodItem foodItem)
        {
            return _foodItemRepository.Update(foodItem);
        }
    }
}
