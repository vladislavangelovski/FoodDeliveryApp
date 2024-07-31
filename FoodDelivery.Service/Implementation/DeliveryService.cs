using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Domain.DTO;
using FoodDelivery.Repository.Interface;
using FoodDelivery.Service.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Service.Implementation
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRepository<DeliveryOrder> _deliveryOrderRepository;
        private readonly IRepository<FoodItem> _foodItemRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<FoodItemInOrder> _foodItemInOrderRepository;
        private readonly IRepository<Restaurant> _restaurantRepository;

        public DeliveryService(ICustomerRepository customerRepository, IRepository<DeliveryOrder> deliveryOrderRepository, IRepository<FoodItem> foodItemRepository, IRepository<Order> orderRepository, IRepository<FoodItemInOrder> foodItemInOrderRepository, IRepository<Restaurant> restaurantRepository)
        {
            _customerRepository = customerRepository;
            _deliveryOrderRepository = deliveryOrderRepository;
            _foodItemRepository = foodItemRepository;
            _orderRepository = orderRepository;
            _foodItemInOrderRepository = foodItemInOrderRepository;
            _restaurantRepository = restaurantRepository;
        }

        public DeliveryOrder AddFoodItemToDelivery(string customerId, AddToDeliveryDTO model)
        {
            if (customerId != null)
            {
                var loggedInCustomer = _customerRepository.Get(customerId);

                var customerDelivery = loggedInCustomer?.DeliveryOrder;

                var selectedFoodItem = _foodItemRepository.Get(model.SelectedFoodItemId);
                var RestaurantOrderedFromId = selectedFoodItem.RestaurantId;

                if (selectedFoodItem != null && customerDelivery != null)
                {
                    customerDelivery?.FoodItemInDeliveries?.Add(new FoodItemInDelivery
                    {
                        FoodItem = selectedFoodItem,
                        FoodItemId = selectedFoodItem.Id,
                        DeliveryOrder = customerDelivery,
                        DeliveryOrderId = customerDelivery.Id,
                        Quantity = model.Quantity,
                        Restaurant = _restaurantRepository.Get(RestaurantOrderedFromId)
                    });

                    return _deliveryOrderRepository.Update(customerDelivery);
                }
            }
            return null;
        }

        public bool DeleteFromDelivery(string customerId, Guid? Id)
        {
            if (customerId != null)
            {
                var loggedInCustomer = _customerRepository.Get(customerId);


                var foodItem_to_delete = loggedInCustomer?.DeliveryOrder?.FoodItemInDeliveries.First(z => z.FoodItemId == Id);

                loggedInCustomer?.DeliveryOrder?.FoodItemInDeliveries?.Remove(foodItem_to_delete);

                _deliveryOrderRepository.Update(loggedInCustomer.DeliveryOrder);

                return true;

            }

            return false;
        }

        public DeliveryDTO GetDeliveryDetails(string customerId)
        {
            if(customerId != null && !customerId.IsNullOrEmpty())
            {
                var loggedInCustomer = _customerRepository.Get(customerId);
                var allFoodItems = loggedInCustomer?.DeliveryOrder?.FoodItemInDeliveries?.ToList();
                var totalPrice = 0.0;
                var restaurantsOrderedFrom = new List<Restaurant>();

                foreach(var item in allFoodItems)
                {
                    totalPrice += Double.Round((item.Quantity * item.FoodItem.Price), 2);
                    //restaurantsOrderedFrom.Add(_restaurantRepository.Get(item.RestaurantId));
                    if (!restaurantsOrderedFrom.Contains(item.Restaurant))
                    {
                        restaurantsOrderedFrom.Add(_restaurantRepository.Get(item.RestaurantId));
                    }
                }
                var model = new DeliveryDTO
                {
                    AllFoodItems = allFoodItems,
                    TotalPrice = totalPrice,
                    RestaurantsOrderedFrom = restaurantsOrderedFrom
                };
                return model;
            }
            return new DeliveryDTO
            {
                AllFoodItems = new List<FoodItemInDelivery>(),
                TotalPrice = 0.0,
                RestaurantsOrderedFrom = null
            };
        }

        public AddToDeliveryDTO GetFoodItemInfo(Guid Id)
        {
            var selectedFoodItem = _foodItemRepository.Get(Id);
            if(selectedFoodItem != null)
            {
                var model = new AddToDeliveryDTO
                {
                    SelectedFoodItemId = selectedFoodItem.Id,
                    SelectedFoodItemName = selectedFoodItem.Name,
                    Quantity = 1
                };
                return model;
            }
            return null;
        }

        public bool OrderFoodItems(string customerId)
        {
            if(customerId != null)
            {
                var loggedInCustomer = _customerRepository.Get(customerId);

                var customerDelivery = loggedInCustomer?.DeliveryOrder;
                int TimeToPrepareMultipleFoodItems = 0;

                Order customerOrder = new Order
                {
                    Id = Guid.NewGuid(),
                    Owner = loggedInCustomer,
                    OwnerId = customerId
                };

                _orderRepository.Insert(customerOrder);

                List<FoodItemInOrder> itemInOrder = new List<FoodItemInOrder>();
                var itemList = customerDelivery?.FoodItemInDeliveries?.Select(z => new FoodItemInOrder
                {
                    Id = Guid.NewGuid(),
                    Order = customerOrder,
                    OrderId = customerOrder.Id,
                    FoodItemId = z.FoodItemId,
                    OrderedFoodItem = z.FoodItem,
                    Quantity = z.Quantity
                }).ToList();

                itemInOrder.AddRange(itemList);

                foreach (var item in itemInOrder)
                {
                    _foodItemInOrderRepository.Insert(item);
                }

                customerDelivery.FoodItemInDeliveries.Clear();

                _deliveryOrderRepository.Update(customerDelivery);


                return true;
            }
            return false;
        }
    }
}
