using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels
{
    public class FoodItem : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public string? Category { get; set; }
        public Guid RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}
