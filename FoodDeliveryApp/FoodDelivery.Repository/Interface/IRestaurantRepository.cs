using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodDelivery.Domain.DomainModels;

namespace FoodDelivery.Repository.Interface
{
    public interface IRestaurantRepository
    {
        Restaurant GetRestaurantDetails(BaseEntity id);
    }
}
