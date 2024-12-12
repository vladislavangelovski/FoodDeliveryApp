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
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Restaurant> entities;
        //string errorMessage = string.Empty;

        public RestaurantRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Restaurant>();
        }

        public Restaurant GetRestaurantDetails(BaseEntity id)
        {
            return entities
                .Include(z => z.FoodItems)
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        }
    }
}
