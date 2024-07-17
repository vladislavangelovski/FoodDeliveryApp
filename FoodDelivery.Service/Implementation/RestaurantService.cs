using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Domain.DTO;
using FoodDelivery.Domain.Identity;
using FoodDelivery.Repository.Interface;
using FoodDelivery.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Service.Implementation
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepository;
        private readonly IRepository<Rating> _ratingRepository;
        private readonly ICustomerRepository _customerRepository;

        public RestaurantService(IRepository<Restaurant> restaurantRepository, IRepository<Rating> ratingRepository, ICustomerRepository customerRepository)
        {
            _restaurantRepository = restaurantRepository;
            _ratingRepository = ratingRepository;
            _customerRepository = customerRepository;
        }

        public Restaurant CreateNewRestaurant(Restaurant restaurant)
        {
            return _restaurantRepository.Insert(restaurant);
        }

        public Restaurant DeleteRestaurant(Guid id)
        {
            var restaurant = this.GetRestaurantById(id);
            return _restaurantRepository.Delete(restaurant);
        }

        public Restaurant GetRestaurantById(Guid? id)
        {
            return _restaurantRepository.Get(id);
        }

        public List<Restaurant> GetRestaurants()
        {
            return _restaurantRepository.GetAll().ToList();
        }

        public void RateRestaurant(string customerId, RestaurantRatingDTO viewModel)
        {
           
            Rating existingRating = _ratingRepository.GetAll().FirstOrDefault(z => z.RestaurantId == viewModel.RestaurantId && z.CustomerId == customerId);
            if (existingRating != null)
            {
                // Update existing rating
                existingRating.Value = viewModel.Value;
                _ratingRepository.Update(existingRating);
            }
            else
            {
                // Add new rating
                var newRating = new Rating
                {
                    RestaurantId = viewModel.RestaurantId,
                    CustomerId = customerId,
                    Value = viewModel.Value
                };
                _ratingRepository.Insert(newRating);
            }
            
            var average = Average(viewModel.RestaurantId);
            var restaurant = _restaurantRepository.Get(viewModel.RestaurantId);

            restaurant.Rating = average;

            _restaurantRepository.Update(restaurant);
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            return _restaurantRepository.Update(restaurant);
        }
        public double Average(Guid restId)
        {
            List<Rating> ratingList = _ratingRepository.GetAll().Where(z => z.RestaurantId == restId).ToList();

            var sum = 0.0;
            var totalNum = ratingList.Count;
            if(totalNum > 0)
            {
                foreach (Rating rating in ratingList)
                {
                    sum += rating.Value;
                }
                return sum / totalNum;
            }
            else
            {
                return 0;
            }

        }
    }
}
