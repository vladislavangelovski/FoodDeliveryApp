using FoodDelivery.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels
{
    public class Rating : BaseEntity
    {
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Value { get; set; }

        // Foreign key for Restaurant
        public Guid RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        // Foreign key for Customer
        public string? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
