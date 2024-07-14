using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Domain.DTO;
using FoodDelivery.Repository.Interface;
using FoodDelivery.Service.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
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

        public DeliveryService(ICustomerRepository customerRepository, IRepository<DeliveryOrder> deliveryOrderRepository, IRepository<FoodItem> foodItemRepository, IRepository<Order> orderRepository, IRepository<FoodItemInOrder> foodItemInOrderRepository)
        {
            _customerRepository = customerRepository;
            _deliveryOrderRepository = deliveryOrderRepository;
            _foodItemRepository = foodItemRepository;
            _orderRepository = orderRepository;
            _foodItemInOrderRepository = foodItemInOrderRepository;
        }

        public DeliveryOrder AddFoodItemToDelivery(string customerId, AddToDeliveryDTO model)
        {
            if (customerId != null)
            {
                var loggedInCustomer = _customerRepository.Get(customerId);

                var customerDelivery = loggedInCustomer?.DeliveryOrder;

                var selectedFoodItem = _foodItemRepository.Get(model.SelectedFoodItemId);

                if (selectedFoodItem != null && customerDelivery != null)
                {
                    customerDelivery?.FoodItemInDeliveries?.Add(new FoodItemInDelivery
                    {
                        FoodItem = selectedFoodItem,
                        FoodItemId = selectedFoodItem.Id,
                        DeliveryOrder = customerDelivery,
                        DeliveryId = customerDelivery.Id,
                        Quantity = model.Quantity
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

                foreach(var item in allFoodItems)
                {
                    totalPrice += Double.Round((item.Quantity * item.FoodItem.Price), 2);
                }
                var model = new DeliveryDTO
                {
                    AllFoodItems = allFoodItems,
                    TotalPrice = totalPrice
                };
                return model;
            }
            return new DeliveryDTO
            {
                AllFoodItems = new List<FoodItemInDelivery>(),
                TotalPrice = 0.0
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

                var totalPrice = 0.0;

                for (int i = 1; i <= itemList.Count(); i++)
                {
                    var item = itemList[i - 1];
                    totalPrice += item.Quantity * item.OrderedFoodItem.Price;
                }

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
