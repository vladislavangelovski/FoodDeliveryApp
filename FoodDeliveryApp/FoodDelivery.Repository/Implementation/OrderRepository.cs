using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        //string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> GetAllOrders()
        {
            return entities
                .Include(z => z.FoodItemInOrders)
                .Include(z => z.Owner)
                .Include("FoodItemInOrders.OrderedFoodItem")
                .ToListAsync().Result;
        }

        public Order GetOrderDetails(BaseEntity id)
        {
            return entities
                .Include(z => z.FoodItemInOrders)
                .Include(z => z.Owner)
                .Include("FoodItemInOrders.OrderedFoodItem")
                .Include("FoodItemInOrders.OrderedFoodItem.Restaurant")
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        }
    }
}
