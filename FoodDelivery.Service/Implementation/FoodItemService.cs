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
    public class FoodItemService : IFoodItemService
    {
        private readonly IRepository<FoodItem> _foodItemRepository;

        public FoodItemService(IRepository<FoodItem> foodItemRepository)
        {
            _foodItemRepository = foodItemRepository;
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

        public FoodItem UpdateFoodItem(FoodItem foodItem)
        {
            return _foodItemRepository.Update(foodItem);
        }
    }
}
