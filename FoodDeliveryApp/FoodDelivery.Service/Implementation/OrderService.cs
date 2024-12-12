using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Repository.Interface;
using FoodDelivery.Service.Interface;

namespace FoodDelivery.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetOrderDetails(BaseEntity id)
        {
            return _orderRepository.GetOrderDetails(id);
        }
    }
}
