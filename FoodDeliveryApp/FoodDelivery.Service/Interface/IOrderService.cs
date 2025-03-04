﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodDelivery.Domain.DomainModels;

namespace FoodDelivery.Service.Interface
{
    public interface IOrderService
    {
        public List<Order> GetAllOrders();
        public Order GetOrderDetails(BaseEntity id);
    }
}
