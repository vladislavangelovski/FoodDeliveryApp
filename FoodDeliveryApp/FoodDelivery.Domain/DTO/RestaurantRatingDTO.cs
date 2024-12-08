using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DTO
{
    public class RestaurantRatingDTO
    {
        public Guid RestaurantId { get; set; }
        public string? RestaurantName { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Value { get; set; }
    }
}
